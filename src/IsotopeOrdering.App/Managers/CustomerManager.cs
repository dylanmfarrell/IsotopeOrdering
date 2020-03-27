using AutoMapper;
using FluentValidation.Results;
using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class CustomerManager : ICustomerManager {
        private readonly ILogger<CustomerManager> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CustomerManager(ILogger<CustomerManager> logger, IMapper mapper, ICustomerService service, IUserService userService, IRoleService roleService) {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<ApplicationResult> EditCustomer(CustomerDetailModel model) {
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
            return ApplicationResult.Error(result.Errors);
        }

        public async Task<CustomerDetailModel> GetCustomer(int id) {
            return await _service.Get<CustomerDetailModel>(id);
        }

        public async Task<IEnumerable<CustomerItemModel>> GetList() {
            if (_roleService.UserRoles.Contains(UserRole.Admin.ToString())) {
                return await _service.GetList<CustomerItemModel>();
            }
            IUser currentUser = _userService.User;
            CustomerItemModel? customer = await _service.Get<CustomerItemModel>(currentUser.Email);
            if (customer == null || customer.ParentCustomerId.HasValue) {
                return Enumerable.Empty<CustomerItemModel>();
            }
            return await _service.GetChildrenList<CustomerItemModel>(customer.Id);
        }

        public async Task<CustomerItemModel> InitializeCustomerForCurrentUser() {
            IUser currentUser = _userService.User;
            CustomerItemModel? customer = await _service.Get<CustomerItemModel>(currentUser.Email);
            if (customer != null) {
                return customer;
            }
            _logger.LogInformation("Creating new customer for {user}", currentUser);
            Customer newCustomer = _mapper.Map<Customer>(currentUser);
            int id = await _service.Create(newCustomer);
            _logger.LogInformation("New customer created {id}", id);
            return await _service.Get<CustomerItemModel>(id);
        }
    }
}
