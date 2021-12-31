using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Services;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAttributeController : ControllerBase
    {
        private ICustomerAttributeService services;

        public CustomerAttributeController(ICustomerAttributeService services)
        {
            this.services = services;
        }

        [HttpGet]
        public Task<IEnumerable<CustomerAttribute>> getAll()
        {
            return services.getAll();
        }

        [HttpGet("{id}")]
        public Task<CustomerAttribute> getOne(int id)
        {
            return services.getOne(id);
        }

        [HttpPost]
        public Task<CustomerAttribute> create(CustomerAttribute newCust)
        {
            return services.createCustomerAttribute(newCust);
        }

        [HttpPut]
        public Task<CustomerAttribute> edit(CustomerAttribute editCust)
        {
            return services.editCustomerAttribute(editCust);
        }

        [HttpDelete("{id}")]
        public Task<CustomerAttribute> delete(int id)
        {
            return services.revomeCustomerAttribute(id);
        }
    }
}
