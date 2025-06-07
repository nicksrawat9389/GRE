using GRE.Domain.Models.ContactSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Application.Interfaces.Repository.SupportContact
{
    public interface IContactSupportRepository
    {
        Task<bool> AddContactSupport(ContactSupportModel contactSupport);
        Task<bool> UpdateContactSupport(ContactSupportModel contactSupport);
        Task<bool> ContactSupportExist(int contactSupportId);
    }
}
