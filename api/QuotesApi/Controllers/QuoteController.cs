using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models;
using QuotesApi.Services;

namespace QuotesApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuotesController : ControllerBase
  {
    private readonly QuoteService _service;

    public QuotesController(QuoteService QuoteService)
    {
      _service = QuoteService;
    }

    [HttpGet]
    public ActionResult<List<Quote>> Get()
    {
      return _service.Get();
    }

    [HttpGet("{id:length(24)}", Name = "GetQuote")]
    public ActionResult<Quote> Get(string id)
    {
      var Quote = _service.Get(id);

      if (Quote == null)
      {
        return NotFound();
      }

      return Quote;
    }

    [HttpPost]
    public ActionResult<Quote> Create(Quote Quote)
    {
      _service.Create(Quote);

      return CreatedAtRoute("GetQuote", new { id = Quote.Id.ToString() }, Quote);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Quote QuoteIn)
    {
      var Quote = _service.Get(id);

      if (Quote == null)
      {
        return NotFound();
      }

      _service.Update(id, QuoteIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var Quote = _service.Get(id);

      if (Quote == null)
      {
        return NotFound();
      }

      _service.Remove(Quote.Id);

      return NoContent();
    }
  }
}