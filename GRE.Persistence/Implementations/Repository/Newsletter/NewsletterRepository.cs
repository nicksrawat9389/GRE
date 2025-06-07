using Dapper;
using GRE.Application.Interfaces.Repository.Newsletter;
using GRE.Domain.Models.Newsletter;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace GRE.Persistence.Implementations.Repository.Newsletter
{
    public class NewsletterRepository : BaseRepository, INewsletterRepository
    {
        private readonly IConfiguration _configuration;
        public NewsletterRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateNewsLetter(NewsletterModel newsletter)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Title", newsletter.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@PdfFileName", newsletter.PdfName, DbType.String, ParameterDirection.Input);
            parameters.Add("@PublishedDate", newsletter.PublishedDate, DbType.Date, ParameterDirection.Input);
            int result = await GetFirstOrDefaultAsync<int>("USP_AddNewsletter", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> NewsletterExist(int newsletterId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NewsletterId", newsletterId, DbType.Int32, ParameterDirection.Input);
            bool result = await GetFirstOrDefaultAsync<bool>("USP_CheckNewsletterExist", parameters, CommandType.StoredProcedure);
            return result;
        }

        public async Task<bool> UpdateNewsLetter(NewsletterModel newsletter)
        {
            
                var parameters = new DynamicParameters();
            parameters.Add("@@NewsletterId", newsletter.NewsletterId, DbType.Int32, ParameterDirection.Input);

            parameters.Add("@Title", newsletter.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@PdfFileName", newsletter.PdfName, DbType.String, ParameterDirection.Input);
            parameters.Add("@PublishedDate", newsletter.PublishedDate, DbType.Date, ParameterDirection.Input);
            int result = await GetFirstOrDefaultAsync<int>("USP_UpdateNewsletter", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> DeleteNewsletter(int newsletterId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NewsletterId", newsletterId, DbType.Int32, ParameterDirection.Input);
            bool result = await GetFirstOrDefaultAsync<bool>("USP_DeleteNewsLetter", parameters, CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<NewsletterModel>> GetAllNewsletters()
        {
            var parameters = new DynamicParameters();
            var result = await QueryAsync<NewsletterModel>("USP_GetAllNewsletters", parameters,commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<NewsletterModel> GetNewslettersById(int newsLetterId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@NewsletterId", newsLetterId, DbType.Int32, ParameterDirection.Input);
            var result = await GetAsync<NewsletterModel>("USP_GetNewsetterById", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
