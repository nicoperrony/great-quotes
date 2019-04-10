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

    /// <summary>
    /// Get all quotes
    /// </summary>
    /// <response code="200">All quote is returned</response>
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<List<Quote>> Get()
    {
      return _service.Get();
    }

    /// <summary>
    /// Get a specific quote
    /// </summary>
    /// <param name="id">identifier of the quote</param>
    /// <response code="200">Quote is returned</response>
    /// <response code="404">Quote is not found</response>  
    [HttpGet("{id:length(24)}", Name = "GetQuote")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<Quote> Get(string id)
    {
      var Quote = _service.Get(id);

      if (Quote == null)
      {
        return NotFound();
      }

      return Quote;
    }

    /// <summary>
    /// Create a quote
    /// </summary>
    /// <param name="quote">quote to create</param>
    /// <response code="201">Quote is created. The quote newly created is returned</response>
    /// <response code="400">Quote is incomplete</response>  
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public ActionResult<Quote> Create(Quote quote)
    {
      _service.Create(quote);

      return CreatedAtRoute("GetQuote", new { id = quote.Id.ToString() }, quote);
    }

    /// <summary>
    /// Update a quote
    /// </summary>
    /// <param name="quote">quote to update</param>
    /// <response code="204">Quote is updated</response>
    /// <response code="404">Quote is not found</response>  
    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Update(Quote quote)
    {
      var Quote = _service.Get(quote.Id);

      if (Quote == null)
      {
        return NotFound();
      }

      _service.Update(quote);

      return NoContent();
    }

    /// <summary>
    /// Delete a quote
    /// </summary>
    /// <param name="id">identifier of the quote to delete</param>
    /// <response code="204">Quote is deleted</response>
    /// <response code="404">Quote is not found</response>  
    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
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