using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateringProgect.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {
        static int my_id = 1;
        private static List<Order> orders = new List<Order> { new Order(my_id++,325, 100,true) };
        // GET: api/<Orders>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orders;
        }

        // GET api/<Orders>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return orders.Find(o=>o.Id==id);
        }
        [HttpGet("cust/{custId}")]
        public IEnumerable<Order> GetByCust(int id)
        {
            return orders.Where(o => o.CustomerId == id);
        }
        // POST api/<Orders>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            orders.Add(new Order(my_id++,order.CustomerId,order.quantity,order.IsSending));
        }

        // PUT api/<Orders>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
           var ord=orders.Find(o => o.Id == id);
            ord.quantity=order.quantity;
            ord.IsSending=order.IsSending;
            ord.CustomerId = order.CustomerId;
        }

        // DELETE api/<Orders>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orders.Remove(orders.Find(o => o.Id == id));
            my_id--;
        }
    }
}
