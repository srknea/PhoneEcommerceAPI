﻿using Microsoft.EntityFrameworkCore;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Repository.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Brand> GetSingleBrandByIdWithModelAsync(int modelId)
        {
            return await _context.Brands.Include(x => x.Models).Where(x => x.Id == modelId).SingleOrDefaultAsync(x => x.Id == modelId);

        }
    }
}
