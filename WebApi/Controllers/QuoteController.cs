namespace WebApi;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private QouteServices _quoteservices;
    public QuoteController()
    {
        _quoteservices = new QouteServices();
    }
    [HttpGet("GetQuotes")]
    public async Task<List<Quote>> GetQuotes()
    {
        return await _quoteservices.GetQuotes();
    }
    [HttpPost("AddQuote")]
    public async Task<int> AddQuote(Quote quote)
    {
        return await _quoteservices.AddQuote(quote);
    }
    [HttpPut("UpdateQuote")]
    public async Task<int> UpdateQuote(Quote quote)
    {
        return await _quoteservices.UpdateQuote(quote);
    }
    [HttpDelete("DeleteQuote")]
    public async Task<int> DeleteQuote(int id)
    {
        return await _quoteservices.DeleteQuote(id);
    }
    [HttpGet("GetAllQuotesByCategory")]
    public async Task<int> GetAllQuotesByCategory(int id)
    {
        return await _quoteservices.GetAllQuotesByCategory(id);
    }
    [HttpGet("GetRandom")]
    public async Task<int> GetRandom(int id)
    {
        return await _quoteservices.GetRandom(id);
    }
}