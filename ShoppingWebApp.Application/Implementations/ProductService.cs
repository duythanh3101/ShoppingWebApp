using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using ShoppingWebApp.Data.Enums;
using ShoppingWebApp.Infrastructure.Interfaces;
using ShoppingWebApp.Utilities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingWebApp.Application.Implementations
{
    public class ProductService: IProductService
    {
        IAsyncRepository<Product, int> _productRepository;
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IAsyncRepository<Product, int> productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductViewModel Add(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            var lst = _productRepository.FindAll(x=>x.ProductCategory).ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider).ToList();
            return lst;
        }

        public ProductViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void ImportExcel(string filePath, int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            int totalRow = query.Count();

            query = query.OrderBy(x => x.DateCreated).
                Skip((page - 1) * pageSize).Take(pageSize);
            var data = query.ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider).ToList();

            var pagedResult = new PagedResult<ProductViewModel>
            {
                Results = data,
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalRow
            };
            return pagedResult;
        }
    }
}
