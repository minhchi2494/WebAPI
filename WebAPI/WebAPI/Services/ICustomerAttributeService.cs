using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface ICustomerAttributeService
    {
        Task<IEnumerable<CustomerAttribute>> getAll();
        Task<CustomerAttribute> getOne(int id);
        Task<CustomerAttribute> createCustomerAttribute(CustomerAttribute newCust);
        Task<CustomerAttribute> editCustomerAttribute(CustomerAttribute editCust);
        Task<CustomerAttribute> revomeCustomerAttribute(int id);
    }
}
