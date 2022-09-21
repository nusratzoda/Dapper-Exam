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


    public async Task<string> AddQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            try

            {
                string? sql = $"Insert into Quote (Author,Quotetext,CategoryId) VAlUES ('{quote.Author}','{quote.Quotetext}',{quote.CategoryId})";

                {
                    var response = await connection.ExecuteAsync(sql);
                    return "Error";
                }
            }
            catch (Exception ex)

            {
                return $"Vary bad{ex.Message}";
            }

    }
    public async Task<string> DeleteQuote(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from Quote where Id = '{id}';";
            try
            {

                var response = await connection.ExecuteAsync(sql);
                return "Error";
            }

            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";

            }
        }
    }
    public async Task<string> UpdateQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"UPDATE Quote SET Author = '{quote.Author}', CategoryId = '{quote.CategoryId}' WHERE Id = {quote.Id};";
            try
            {
                var response = await connection.ExecuteAsync(sql);
                return $"Error";
            }

            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";

            }
        }
    }
    public async Task<string> GetAllQuotesByCategory(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))

        {
            string sql = ($"select * from Quote where CategoryId ={id} ;");
            try
            {

                var response = await connection.ExecuteAsync(sql);
                return "Error";
            }

            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";
            }
        }
    }

    public async Task<string> GetRandom(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            string sql = ($"select * from quote order by random() Limit 1 ;");
            try
            {

                var response = await connection.ExecuteAsync(sql);
                return "Error";
            }
            catch (Exception ex)
            {
                return $"Vary bad{ex.Message}";
            }

        }
    }
    public async Task<List<QuoteWithCategoruDto>> GetQuoteWithCategory(int categoryId)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            var response = await connection.QueryAsync<QuoteWithCategoruDto>($"select q.id,q.author,q.quotetext,c.categoryname from quote as q join categories as c on q.categoryid = c.id; ");
            return response.ToList();
        }
    }
}