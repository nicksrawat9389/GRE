using GRE.Shared.DTOs.ContactSupport;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Services.ContactSupport
{
    public interface IContactSupportService
    {
        Task<JsonModel> CreateContactSupportAsync(ContactSupportDto contactSupportDto);
        Task<JsonModel> UpdateContactSupportAsync(ContactSupportDto contactSupportDto);

    }
}
