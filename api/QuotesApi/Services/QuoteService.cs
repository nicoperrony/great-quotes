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

    public Quote Create(Quote quoteIn)
    {
      _collection.InsertOne(quoteIn);
      return quoteIn;
    }

    public void Update(Quote quoteIn)
    {
      _collection.ReplaceOne(Quote => Quote.Id == quoteIn.Id, quoteIn);
    }

    public void Remove(string id)
    {
      _collection.DeleteOne(Quote => Quote.Id == id);
    }
  }
}