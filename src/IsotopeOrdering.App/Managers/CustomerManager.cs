using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class CustomerManager : ICustomerManager {
        private readonly ILogger<CustomerManager> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;
        private readonly IUserService _userService;
        private readonly IIsotopeOrderingAuthorizationService _authorization;
        private readonly IEventManager _eventService;

        public CustomerManager(ILogger<CustomerManager> logger,
            IMapper mapper,
            ICustomerService service,
            IUserService userService,
            IIsotopeOrderingAuthorizationService authorization,
            IEventManager eventService) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _userService = userService;
            _authorization = authorization;
            _eventService = eventService;
        }

        public async Task<ApplicationResult> Edit(CustomerDetailModel model) {
            var validator = new CustomerDetailModelValidator();
            ValidationResult result = await validator.ValidateAsync(model);
            if (result.IsValid) {
                try {
                    Customer customer = _mapper.Map<Customer>(model);
                    int id = await _service.Update(customer);
                    return ApplicationResult.Success("Customer updated successfully", id);
                }
                catch (Exception ex) {
                    _logger.LogError(ex, "Failed to update customer");
                    return ApplicationResult.Error(ex);
                }
            }
            return ApplicationResult.Error(result);
        }

        public async Task<CustomerDetailModel?> Get(int id) {
            bool isAdmin = await _authorization.AuthorizeAsync(Policies.AdminPolicy);
            //user is admin
            if (isAdmin) {
                return await _service.Get<CustomerDetailModel>(id);
            }
            CustomerItemModel? customer = await _service.GetCurrentCustomer<CustomerItemModel>();
            if (customer == null) {
                return null;
            }
            //if a child customer is requesting their profile
            if (customer.IsChild && customer.Id == id) {
                return await _service.Get<CustomerDetailModel>(id);
            }
            //if parent is requesting their profile or their children's
            if (!customer.IsChild) {
                if (customer.Id == id) {
                    return await _service.Get<CustomerDetailModel>(id);
                }
                else {
                    return await _service.GetChild<CustomerDetailModel>(customer.Id, id);
                }
            }
            //bad request return no customer profile
            return null;
        }

        public async Task<List<CustomerItemModel>> GetList() {
            bool isAdmin = await _authorization.AuthorizeAsync(Policies.AdminPolicy);
            //user is an admin
            if (isAdmin) {
                return await _service.GetList<CustomerItemModel>();
            }
            CustomerItemModel? customer = await _service.GetCurrentCustomer<CustomerItemModel>();
            //customer not found, return empty list
            if (customer == null) {
                return new List<CustomerItemModel>();
            }
            //customer found but is a child of another customer, just show them their customer record
            if (customer.IsChild) {
                return new List<CustomerItemModel>() { customer };
            }
            //customer found and is a parent, return their record and their children
            else {
                List<CustomerItemModel> children = await _service.GetChildrenList<CustomerItemModel>(customer.Id);
                children.Add(customer);
                return children;
            }
        }

        public async Task<CustomerItemModel> InitializeCustomerForCurrentUser() {
            CustomerItemModel? customer = await GetCurrentCustomer();
            if (customer != null) {
                return customer;
            }
            return await Create();
        }

        public async Task<CustomerItemModel?> GetCurrentCustomer() {
            return await _service.GetCurrentCustomer<CustomerItemModel>();
        }

        public async Task<CustomerItemModel?> GetItem(int id) {
            return await _service.Get<CustomerItemModel>(id);
        }

        public async Task<List<CustomerItemModel>> GetListForOrder() {
            return await _service.GetListForOrder<CustomerItemModel>();
        }

        private async Task<CustomerItemModel> Create() {
            IUser user = _userService.User;
            _logger.LogInformation("Creating new customer for {user}", user);
            Customer newCustomer = _mapper.Map<Customer>(user);
            int id = await _service.Create(newCustomer);
            await _eventService.CreateEvent(EntityEventType.Customer, id, Events.Customer.Created);
            _logger.LogInformation("New customer created {id}", id);
            return await _service.Get<CustomerItemModel>(id);
        }
    }
}
