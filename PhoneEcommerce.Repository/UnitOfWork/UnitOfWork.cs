﻿using PhoneEcommerce.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        // Mümkün oldukça async metotları kullanmaya çalışacağız.
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
