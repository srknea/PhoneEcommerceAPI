using AutoMapper;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Core.UnitOfWork;
using PhoneEcommerce.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Services
{
    public class VersionService : GenericService<Core.Model.Version>, IVersionService
    {
        public VersionService(IGenericRepository<Core.Model.Version> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}