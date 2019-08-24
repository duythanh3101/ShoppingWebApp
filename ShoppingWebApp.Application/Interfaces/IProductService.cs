using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Utilities.DTOs;
using System.Collections.Generic;

namespace ShoppingWebApp.Application.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        ProductViewModel GetById(int id);

        void ImportExcel(string filePath, int categoryId);

        void Save();

        //void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);
    }
}
