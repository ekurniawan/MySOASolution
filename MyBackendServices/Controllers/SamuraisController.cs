using FluentValidation;
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
        private readonly IValidator<SamuraiCreateDTO> _validatorSamuraiCreate;
        private readonly IValidator<SamuraiUpdateDTO> _validatorSamuraiUpdate;

        public SamuraisController(ISamuraiBLL samuraiBLL, IValidator<SamuraiCreateDTO> validatorSamuraiCreate,
            IValidator<SamuraiUpdateDTO> validatorSamuraiUpdate)
        {
            _samuraiBLL = samuraiBLL;
            _validatorSamuraiCreate = validatorSamuraiCreate;
            _validatorSamuraiUpdate = validatorSamuraiUpdate;
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
        public async Task<IActionResult> Get(int id)
        {
            var samurai = await _samuraiBLL.ReadAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }
            return Ok(samurai);
        }

        [HttpGet("withquotes")]
        public async Task<IEnumerable<SamuraiWithQuotesDTO>> GetWithQuotes()
        {
            var samurais = await _samuraiBLL.ReadWithQuotesAsync();
            return samurais;
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<IActionResult> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var validatorResult = await _validatorSamuraiCreate.ValidateAsync(samuraiCreateDTO);
                if (!validatorResult.IsValid)
                {
                    Helpers.Extensions.AddToModelState(validatorResult, ModelState);
                    return BadRequest(ModelState);
                }
                var result = await _samuraiBLL.CreateAsync(samuraiCreateDTO);
                return CreatedAtAction(nameof(Get), new { id = result.SamuraiId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SamuraisController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SamuraiUpdateDTO samuraiUpdateDTO)
        {
            try
            {
                var validatorResult = await _validatorSamuraiUpdate.ValidateAsync(samuraiUpdateDTO);
                if (!validatorResult.IsValid)
                {
                    Helpers.Extensions.AddToModelState(validatorResult, ModelState);
                    return BadRequest(ModelState);
                }

                var result = await _samuraiBLL.UpdateAsync(id, samuraiUpdateDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _samuraiBLL.DeleteAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
