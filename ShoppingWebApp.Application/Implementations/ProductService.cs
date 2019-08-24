using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using ShoppingWebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.Implementations
{
    public class ProductService: IProductService
    {
        IAsyncRepository<Product, string> _productRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IAsyncRepository<Product, string> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
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
            throw new NotImplementedException();
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
