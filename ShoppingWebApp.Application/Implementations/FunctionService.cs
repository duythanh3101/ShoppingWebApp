using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.System;
using ShoppingWebApp.Data.Entities;
using ShoppingWebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebApp.Application.Implementations
{
    public class FunctionService : IFunctionService
    {
        private IAsyncRepository<Function, string> _functionRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public FunctionService(IAsyncRepository<Function, string> functionRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _functionRepository = functionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            var query = _functionRepository.FindAll();
            return query.ProjectTo<FunctionViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public List<FunctionViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
