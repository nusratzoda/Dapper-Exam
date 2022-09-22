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
    public async Task<Response<List<Quote>>> GetQuotes()
    {
        return await _quoteservices.GetQuotes();
    }
    [HttpPost("ADDQuote")]
    public async Task<Response<Quote>> ADDQuote(Quote quote)
    {
        return await _quoteservices.ADDQuote(quote);
    }
    [HttpPut("UpdateQuote")]
    public async Task<Response<Quote>> UpdateQuote(Quote quote)
    {
        return await _quoteservices.UpdateQuote(quote);
    }
    [HttpDelete("DeleteQuote")]
    public async Task<Response<Quote>> DeleteQuote(int id)
    {
        return await _quoteservices.DeleteQuote(id);
    }
    [HttpGet("GetAllQuotesByCategory")]
    public async Task<Response<Quote>> GetAllQuotesByCategory(int id)
    {
        return await _quoteservices.GetAllQuotesByCategory(id);
    }
    [HttpGet("GetRandom")]
    public async Task<Response<Quote>> GetRandom(int id)
    {
        return await _quoteservices.GetRandom(id);
    }
    [HttpGet("GetQuoteWithCategory")]
    public async Task<Response<List<QuoteWithCategoruDto>>> GetQuoteWithCategory(int id)
    {
        return await _quoteservices.GetQuoteWithCategory(id);
    }
}

