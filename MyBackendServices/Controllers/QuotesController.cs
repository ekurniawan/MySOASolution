using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MySOASolution.BLL.DTOs;
using MySOASolution.BLL.Interface;

namespace MyBackendServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteBLL _quoteBLL;
        private readonly IValidator<QuoteCreateDTO> _validatorQuoteCreate;
        private readonly IValidator<QuoteUpdateDTO> _validatorQuoteUpdate;

        public QuotesController(IQuoteBLL quoteBLL, IValidator<QuoteCreateDTO> validatorQuoteCreate,
            IValidator<QuoteUpdateDTO> validatorQuoteUpdate)
        {
            _quoteBLL = quoteBLL;
            _validatorQuoteCreate = validatorQuoteCreate;
            _validatorQuoteUpdate = validatorQuoteUpdate;
        }

        // GET: api/<QuotesController>
        [HttpGet]
        public async Task<IEnumerable<QuoteDTO>> Get()
        {
            var quotes = await _quoteBLL.ReadAsync();
            return quotes;
        }

        // GET api/<QuotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var quote = await _quoteBLL.ReadAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        // POST api/<QuotesController>
        [HttpPost]
        public async Task<IActionResult> Post(QuoteCreateDTO quoteCreateDTO)
        {
            var validatorResult = _validatorQuoteCreate.Validate(quoteCreateDTO);
            if (!validatorResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validatorResult, ModelState);
                return BadRequest(ModelState);
            }

            var quote = await _quoteBLL.CreateAsync(quoteCreateDTO);
            return CreatedAtAction(nameof(Get), new { id = quote.QuoteId }, quote);
        }

        //PUT api/<QuotesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, QuoteUpdateDTO quoteUpdateDTO)
        {
            var validatorResult = _validatorQuoteUpdate.Validate(quoteUpdateDTO);
            if (!validatorResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validatorResult, ModelState);
                return BadRequest(ModelState);
            }

            var result = await _quoteBLL.UpdateAsync(id, quoteUpdateDTO);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //DELETE api/<QuotesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _quoteBLL.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
