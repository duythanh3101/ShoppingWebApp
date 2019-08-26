using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using ShoppingWebApp.Data.Enums;
using ShoppingWebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingWebApp.Application.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        IAsyncRepository<ProductCategory, int> _productCategoryRepository;
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryService(IAsyncRepository<ProductCategory, int> productCategoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
           var productCategory = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                 .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.FindAll(x => x.Name.Contains(keyword)
                || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider).ToList();
            else
                return GetAll();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.FindAll(x => x.ParentId == parentId && x.Status == Status.Active)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            var productCategory = _productCategoryRepository.FindById(id);
            return _mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategory);

        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            throw new NotImplementedException();
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _productCategoryRepository.FindById(sourceId);
            var target = _productCategoryRepository.FindById(targetId);
            if (source.SortOrder != target.SortOrder)
            {
                int tempOrder = source.SortOrder;
                source.SortOrder = target.SortOrder;
                target.SortOrder = tempOrder;
            }
            else
            {

            }
            

            source.ParentId = target.ParentId;

            _productCategoryRepository.Update(source);
            _productCategoryRepository.Update(target);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            _productCategoryRepository.Update(_mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm));
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _productCategoryRepository.FindById(sourceId);
            sourceCategory.ParentId = targetId;
            _productCategoryRepository.Update(sourceCategory);

            //Get all sibling
            var sibling = _productCategoryRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _productCategoryRepository.Update(child);
            }
        }
    }
}
