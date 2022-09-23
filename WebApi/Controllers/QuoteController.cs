namespace WebApi;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    // private QouteServices _quoteservices;
    // public QuoteController()
    // {
    //     _quoteservices = new QouteServices();
    // }
    private QouteServices _quoteService;
    public QuoteController(QouteServices quoteService)
    {
        _quoteService = quoteService;
    }
    [HttpGet("GetQuotes")]
    public async Task<Response<List<Quote>>> GetQuotes()
    {
        return await _quoteService.GetQuotes();
    }
    [HttpPost("ADDQuote")]
    public async Task<Response<Quote>> ADDQuote(Quote quote)
    {
        return await _quoteService.ADDQuote(quote);
    }
    [HttpPut("UpdateQuote")]
    public async Task<Response<Quote>> UpdateQuote(Quote quote)
    {
        return await _quoteService.UpdateQuote(quote);
    }
    [HttpDelete("DeleteQuote")]
    public async Task<Response<Quote>> DeleteQuote(int id)
    {
        return await _quoteService.DeleteQuote(id);
    }
    [HttpGet("GetAllQuotesByCategory")]
    public async Task<Response<Quote>> GetAllQuotesByCategory(int id)
    {
        return await _quoteService.GetAllQuotesByCategory(id);
    }
    [HttpGet("GetRandom")]
    public async Task<Response<Quote>> GetRandom(int id)
    {
        return await _quoteService.GetRandom(id);
    }
    [HttpGet("GetQuoteWithCategory")]
    public async Task<Response<List<QuoteWithCategoruDto>>> GetQuoteWithCategory(int id)
    {
        return await _quoteService.GetQuoteWithCategory(id);
    }
}