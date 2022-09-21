using Dapper;
using Npgsql;
using Domain;
namespace Services;
public class QouteServices
{
    private string _connectionString;
    public QouteServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=ExamApi;User Id=postgres;Password=882003421sb.;";
    }

    public async Task<List<Quote>> GetQuotes()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            var response = await connection.QueryAsync<Quote>($"select * from Quote ;");
            return response.ToList();
        }
    }


    public async Task<int> AddQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string? sql = $"Insert into Quote (Author,Quotetext,CategoryId) VAlUES ('{quote.Author}','{quote.Quotetext}',{quote.CategoryId})";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> DeleteQuote(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from Quote where Id = '{id}';";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> UpdateQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"UPDATE Quote SET Author = '{quote.Author}', CategoryId = '{quote.CategoryId}' WHERE Id = {quote.Id};";
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
    public async Task<int> GetAllQuotesByCategory(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))

        {
            string sql = ($"select * from Quote where CategoryId ={id} ;");
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }

    public async Task<int> GetRandom(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = ($"select * from quote order by random() Limit 1 ;");
            var response = await connection.ExecuteAsync(sql);
            return response;
        }
    }
}

