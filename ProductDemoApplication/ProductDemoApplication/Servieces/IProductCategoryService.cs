using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Models;

using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Servieces
{
   public interface IProductCategoryService
    {
        List<ProductCategoryCreateEditModel> GetCategory();
        ProductCategoryCreateEditModel GetCreatedCategory(ProductCategoryCreateEditModel objProductCategory);
        ProductCategoryCreateEditModel ShowEditedCategory(int? id);
        ProductCategoryCreateEditModel GetEditedCategory(ProductCategoryCreateEditModel objProductCategory);
        ProductCategoryCreateEditModel GetDetailsCategory(int? id);
        ProductCategoryCreateEditModel ShowDeletedCategory(int? id);
        ProductCategoryCreateEditModel GetDeletedCategory(int id, ProductCategoryCreateEditModel objProductCategory);
    }
}
