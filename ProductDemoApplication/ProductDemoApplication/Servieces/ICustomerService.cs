using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Models;

namespace ProductDemoApplication.Servieces
{
   public interface ICustomerService
    {
        List<CustomoerCreateEditModel> GetCustomer();
        CustomoerCreateEditModel ShowEditedCustomer(int? id);
        CustomoerCreateEditModel GetEditedCustomer(CustomoerCreateEditModel objCustomers);      
        CustomoerCreateEditModel GetDetailedCustomer(int? id);
        CustomoerCreateEditModel ShowDeletedCustomer(int? id);
        CustomoerCreateEditModel GetDeletedCustomer(int id, CustomoerCreateEditModel objcust);
    }
}
