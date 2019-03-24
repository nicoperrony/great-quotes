using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using QuotesApi.Models;

namespace QuotesApi.Services
{
  public class QuoteService
  {
    private readonly IMongoCollection<Quote> _collection;

    public QuoteService(IConfiguration config)
    {
      var client = new MongoClient(config.GetConnectionString("GreatQuoteDb"));
      var database = client.GetDatabase("great-quotes");
      _collection = database.GetCollection<Quote>("quotes");
    }

    public List<Quote> Get()
    {
      return _collection.Find(Quote => true).ToList();
    }

    public Quote Get(string id)
    {
      return _collection.Find<Quote>(Quote => Quote.Id == id).FirstOrDefault();
    }

    public Quote Create(Quote Quote)
    {
      _collection.InsertOne(Quote);
      return Quote;
    }

    public void Update(string id, Quote QuoteIn)
    {
      _collection.ReplaceOne(Quote => Quote.Id == id, QuoteIn);
    }

    public void Remove(Quote QuoteIn)
    {
      _collection.DeleteOne(Quote => Quote.Id == QuoteIn.Id);
    }

    public void Remove(string id)
    {
      _collection.DeleteOne(Quote => Quote.Id == id);
    }
  }
}