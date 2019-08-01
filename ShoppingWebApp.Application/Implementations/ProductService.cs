using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using ShoppingWebApp.Infrastructure.Interfaces;
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
    }
}
