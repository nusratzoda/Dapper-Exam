using Dapper;
using Npgsql;
using Domain;
namespace Services;
public class QouteServices
{
    private DataContext.DataContext _context;

    public QouteServices(DataContext.DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<Quote>>> GetQuotes()
    {
        await using var connection = _context.CreateConnection();

        var response = await connection.QueryAsync<Quote>($"select * from Quote;");
        return new Response<List<Quote>>(response.ToList());

    }
    public async Task<Response<Quote>> ADDQuote(Quote quote)
    {

        using var connection = _context.CreateConnection();
        {
            try
            {

                var sql = $"Insert into Quote (Author,Quotetext,CategoryId) VAlUES (@Author,@Quotetext,@CategoryId) returning id";
                var result = await connection.ExecuteScalarAsync<int>(sql, new { quote.Author, quote.Quotetext, quote.CategoryId });
                quote.Id = result;
                return new Response<Quote>(quote);
            }

            catch (Exception ex)
            {
                return new Response<Quote>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<Quote>> DeleteQuote(int id)
    {

        using var connection = _context.CreateConnection();
        {
            string sql = $"delete from Quote where Id = '{id}';";
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return new Response<Quote>(System.Net.HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new Response<Quote>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<Quote>> UpdateQuote(Quote quote)
    {

        using var connection = _context.CreateConnection();
        {
            string sql = $"UPDATE Quote SET Author = '{quote.Author}', CategoryId = '{quote.CategoryId}' WHERE Id = {quote.Id};";
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return new Response<Quote>(System.Net.HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new Response<Quote>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<Quote>> GetAllQuotesByCategory(int id)
    {
        using var connection = _context.CreateConnection();
        {
            string sql = ($"select * from Quote where CategoryId ={id} ;");
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return new Response<Quote>(System.Net.HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new Response<Quote>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<Quote>> GetRandom(int id)
    {
        using var connection = _context.CreateConnection();
        {
            string sql = ($"select * from quote order by random() Limit 1 ;");
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return new Response<Quote>(System.Net.HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return new Response<Quote>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    public async Task<Response<List<QuoteWithCategoruDto>>> GetQuoteWithCategory(int categoryId)
    {
        using var connection = _context.CreateConnection();
        {
            var response = await connection.QueryAsync<QuoteWithCategoruDto>($"select q.id,q.author,q.quotetext,c.categoryname from quote as q join categories as c on q.categoryid = c.id; ");
            return new Response<List<QuoteWithCategoruDto>>(response.ToList());
        }
    }
}