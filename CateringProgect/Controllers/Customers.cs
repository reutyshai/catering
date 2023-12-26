using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateringProgect.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        static int my_id = 1;
        private static List<Customer> customers = new List<Customer> { new Customer { id = my_id++, name = "reuven cohen", phone = "0527156392", adress = "ben ptachya 5 bb" } };
        // GET: api/<Customers>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        // GET api/<Customers>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customers.Find(c => c.id == id);
        }

        // POST api/<Customers>
        [HttpPost]
        public void Post([FromBody] Customer cust)
        {
            customers.Add(new Customer { id = my_id++, phone = cust.phone, adress = cust.adress, name = cust.name });
        }

        // PUT api/<Customers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer cust)
        {
            var customer=customers.Find(c => c.id == id);
            customer.name=cust.name;
            customer.phone=cust.phone;
            customer.adress=cust.adress;
        }

        // DELETE api/<Customers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customers.Remove(customers.Find(c => c.id == id));
            my_id--;
        }
    }
}
