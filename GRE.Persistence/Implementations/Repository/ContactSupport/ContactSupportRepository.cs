using Dapper;
using GRE.Application.Interfaces.Repository.SupportContact;
using GRE.Domain.Models.ContactSupport;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Repository.ContactSupport
{
    public class ContactSupportRepository : BaseRepository, IContactSupportRepository
    {
        private IConfiguration _configuration;

        public ContactSupportRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            
        }
        public async Task<bool> AddContactSupport(ContactSupportModel contactSupport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", contactSupport.Name, DbType.String);
            parameters.Add("@Email", contactSupport.Email, DbType.String);
            parameters.Add("@Phone", contactSupport.Phone, DbType.String);
            

            int result = await GetFirstOrDefaultAsync<int>("USP_AddSupportContact", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> ContactSupportExist(int contactSupportId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SupportId", contactSupportId, DbType.Int32);
            bool result = await GetFirstOrDefaultAsync<bool>("USP_ContactSipportExist", parameters, CommandType.StoredProcedure);
            return result;
        }

        public async Task<bool> UpdateContactSupport(ContactSupportModel contactSupport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SupportId", contactSupport.SupportId, DbType.Int32);

            parameters.Add("@Name", contactSupport.Name, DbType.String);
            parameters.Add("@Email", contactSupport.Email, DbType.String);
            parameters.Add("@Phone", contactSupport.Phone, DbType.String);


            int result = await GetFirstOrDefaultAsync<int>("USP_UpdateSupportContact", parameters, CommandType.StoredProcedure);
            return result > 0;
        }

    }
}
