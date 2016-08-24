using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Models;

namespace ProductDemoApplication.Servieces
{
  public interface IProduct
    {
        List<ProductCreateEditModel> GetProduct();
        ProductCreateEditModel GetCreatedProduct(ProductCreateEditModel objProduct);
        ProductCreateEditModel ShowEditedProduct(int?id);
        ProductCreateEditModel GetDetailedProduct(int? id);
        ProductCreateEditModel ShowDeletedProduct(int? id);
        ProductCreateEditModel GetDeletedProduct(int id, ProductCreateEditModel objproduct);

    }
}
