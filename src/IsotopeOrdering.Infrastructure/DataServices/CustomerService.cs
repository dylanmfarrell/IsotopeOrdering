﻿using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MIR.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class CustomerService : ServiceBase<IsotopeOrderingDbContext, Customer>, ICustomerService {
        private readonly IMapper _mapper;

        public CustomerService(IsotopeOrderingDbContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<T?> GetCurrentCustomer<T>() where T : class {
            return await Get<T>(_context.UserService.User.EducationId);
        }

        public async Task<T?> Get<T>(string userId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.UserId == userId))
                .SingleOrDefaultAsync();
        }

        public async Task<T> Get<T>(int id) where T : class {
            T value = await _mapper.ProjectTo<T>(_context.Customers
                .Include(x => x.Documents)
                .Include(x => x.Addresses)
                .Include(x => x.Institutions)
                .Include(x => x.ItemConfigurations)
                    .ThenInclude(x => x.Item)
                .Where(x => x.Id == id)).SingleOrDefaultAsync();
            return value;
        }

        public async Task<List<T>> GetChildrenList<T>(int parentId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.ParentCustomerId == parentId))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<T>> GetList<T>() where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<T>> GetAddressListForOrder<T>(int customerId, int? parentCustomerId) where T : class {
            return await _mapper.ProjectTo<T>(_context.CustomerAddresses.Where(x => x.CustomerId == parentCustomerId.GetValueOrDefault(customerId)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetChild<T>(int parentId, int childId) where T : class {
            return await _mapper.ProjectTo<T>(_context.Customers.Where(x => x.Id == childId && x.ParentCustomerId.HasValue && x.ParentCustomerId.Value == parentId))
                .SingleOrDefaultAsync();
        }

        public async Task<List<T>> Search<T>(string search) where T : class {
            IQueryable<Customer> customers = _context.Customers.Where(x => x.Status == CustomerStatus.Initiated && (x.Contact.FirstName.ToLower().Contains(search.ToLower()) ||  x.Contact.LastName!.ToLower().Contains(search.ToLower())));
            return await _mapper.ProjectTo<T>(customers).ToListAsync();
        }
    }
}
