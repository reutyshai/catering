using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateringProgect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dishes : ControllerBase
    {
        static int my_id = 1;
        private static List<Dish> dishes = new List<Dish> { new Dish { id=my_id++,name= "salmon", price=20, sideDish="potato chips" } };
        // GET: api/<Dishes>
        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return dishes;
        }

        // GET api/<Dishes>/5
        [HttpGet("{id}")]
        public Dish Get(int id)
        {
            return dishes.Find(d => d.id == id);
        }
        [HttpGet("{price}")]
        public IEnumerable<Dish>  GetByPrice(int price)
        {
            return dishes.Where(d => d.price <= price);
        }
        // POST api/<Dishes>
        [HttpPost]
        public void Post([FromBody] Dish dish)
        {
            dishes.Add(new Dish(my_id++, dish.price, dish.name,dish.sideDish, dish.isSideDish));
        }

        // PUT api/<Dishes>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Dish dish)
        {
            var di=dishes.Find(d=>d.id == id);
            di.name= dish.name;
            di.price= dish.price;
            di.sideDish= dish.sideDish;
            di.isSideDish= dish.isSideDish;

        }

        // DELETE api/<Dishes>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dishes.Remove(dishes.Find(d => d.id == id));
            my_id--;
        }
    }
}
