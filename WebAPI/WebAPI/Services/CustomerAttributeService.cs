using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Repository;
namespace WebAPI.Services
{
    public class CustomerAttributeService : ICustomerAttributeService
    {
        private CustomerAttributeContext context;

        public CustomerAttributeService(CustomerAttributeContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CustomerAttribute>> getAll()
        {
            var caList = context.CustomerAttributes.ToList();
            return caList;
        }


        public async Task<CustomerAttribute> getOne(int id)
        {
            var ca = context.CustomerAttributes.SingleOrDefault(c=>c.id.Equals(id));
            if (ca != null)
            {
                return ca;
            }
            else
            {
                return null;
            }
        }

        public async Task<CustomerAttribute> createCustomerAttribute(CustomerAttribute newCust)
        {
            context.CustomerAttributes.Add(newCust);
            context.SaveChanges();
            return newCust;
        }

        public async Task<CustomerAttribute> editCustomerAttribute(CustomerAttribute editCust)
        {
            var ca = context.CustomerAttributes.SingleOrDefault(c=>c.id.Equals(editCust.id));
            if (ca != null)
            {
                ca.attribute_master = editCust.attribute_master;
                ca.attribute_values_code = editCust.attribute_values_code;
                ca.description = editCust.description; 
                ca.short_name = editCust.short_name;
                ca.parent = editCust.parent;
                ca.effective_date = editCust.effective_date;    
                ca.valid_until = editCust.valid_until;
                context.SaveChanges();
                return editCust;
            } else
            {
                return null;
            }
        }

        public async Task<CustomerAttribute> revomeCustomerAttribute(int id)
        {
            var ca = context.CustomerAttributes.SingleOrDefault(c => c.id.Equals(id));
            if ( ca != null)
            {
                context.CustomerAttributes.Remove(ca);
                context.SaveChanges();
                return ca;
            }
            else { 
                return null;
            }
        }
    }
}
