﻿using AutoMapper;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MIR.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class FormService : ServiceBase<IsotopeOrderingDbContext, Form>, IFormService {
        private readonly IMapper _mapper;

        public FormService(IsotopeOrderingDbContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public async Task<T> Get<T>(FormType formType) {
            return await _mapper.ProjectTo<T>(_context.Forms.Where(x => x.Type == formType)).SingleAsync();
        }

        public async Task<T?> GetCustomerForm<T>(int customerId, int customerFormId) where T : class {
            return await _mapper.ProjectTo<T>(_context.CustomerForms.Where(x => x.Id == customerFormId && x.CustomerId == customerId))
                .SingleOrDefaultAsync();
        }

        public async Task<T?> GetCustomerForm<T>(Guid formIdentifier) where T : class {
            return await _mapper.ProjectTo<T>(_context.CustomerForms.Where(x => x.FormIdentifier == formIdentifier && x.Status == CustomerFormStatus.AwaitingCustomerSupervisorApproval))
                .SingleOrDefaultAsync();
        }

        public async Task<T?> GetCustomerForm<T>(int customerFormId) where T : class {
            return await _mapper.ProjectTo<T>(_context.CustomerForms.Where(x => x.Id == customerFormId))
                .SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetCustomerForms<T>() {
            return await _mapper.ProjectTo<T>(_context.CustomerForms.Include(x => x.Customer)).ToListAsync();
        }

        public async Task<List<T>> GetCustomerForms<T>(int customerId) {
            return await _mapper.ProjectTo<T>(_context.CustomerForms.Include(x => x.Customer).Where(x => x.CustomerId == customerId)).ToListAsync();
        }

        public async Task<List<T>> GetCustomerForms<T>(CustomerFormStatus status) {
            return await _mapper.ProjectTo<T>(_context.CustomerForms.Include(x => x.Customer).Where(x => x.Status == status)).ToListAsync();
        }

        public async Task<CustomerFormStatus> GetInitiationFormStatus(int customerId) {
            CustomerFormStatus? status = await _context.CustomerForms
                .Include(x => x.Form)
                .Where(x => x.CustomerId == customerId && x.Form.Type == FormType.Initiation)
                .Select(x => x.Status)
                .FirstOrDefaultAsync();
            return status.GetValueOrDefault(CustomerFormStatus.New);
        }

        public async Task<int> SubmitCustomerForm(CustomerForm form) {
            if (form.Id != 0) {
                EntityEntry<CustomerForm> entry = _context.Attach(form);
                entry.Property(x => x.FormData).IsModified = true;
                entry.Property(x => x.Status).IsModified = true;
            }
            else {
                _context.CustomerForms.Add(form);
            }
            await _context.SaveChangesAsync();
            return form.Id;
        }

        public async Task UpdateCustomerFormStatus(int customerFormId, CustomerFormStatus status) {
            CustomerForm form = await _context.CustomerForms.FindAsync(customerFormId);
            form.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
