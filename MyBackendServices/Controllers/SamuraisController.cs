using Microsoft.AspNetCore.Mvc;
using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBackendServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamuraiBLL _samuraiBLL;
        public SamuraisController(ISamuraiBLL samuraiBLL)
        {
            _samuraiBLL = samuraiBLL;
        }

        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiDTO>> Get()
        {
            var samurais = await _samuraiBLL.ReadAsync();
            return samurais;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SamuraisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
