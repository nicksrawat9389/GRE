using AutoMapper;
using GRE.Application.Interfaces.Repository.SupportContact;
using GRE.Application.Interfaces.Services.ContactSupport;
using GRE.Domain.Models.ContactSupport;
using GRE.Shared.DTOs.ContactSupport;
using GRE.Shared.Enums;
using GRE.Shared.Messages;
using GRE.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.ContactSupport
{
    public class ContactSupportService : IContactSupportService
    {
        JsonModel response = new();
        private IMapper _mapper;
        private IContactSupportRepository _contactSupportRepository;
        public ContactSupportService(IContactSupportRepository contactSupportRepository,IMapper mapper) 
        {
            _contactSupportRepository = contactSupportRepository;
            _mapper = mapper;
        }

        public async Task<JsonModel> CreateContactSupportAsync(ContactSupportDto contactSupportDto)
        {
            if (contactSupportDto != null && !string.IsNullOrWhiteSpace(contactSupportDto.Name) && !string.IsNullOrWhiteSpace(contactSupportDto.Phone))
            {
                var contactsupport = _mapper.Map<ContactSupportModel>(contactSupportDto);
                var contactSupportAdded = await _contactSupportRepository.AddContactSupport(contactsupport);
                if (contactSupportAdded)
                {
                    response.data = null;
                    response.StatusCode = (int)StatusCodeEnum.Success;
                    response.Message = SuccessMessages.ContactSupportAddedSuccessfully;
                }
                else
                {
                    response.data = null;
                    response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                    response.Message = ErrorMessages.InternalServerError;
                }
            }
            else
            {
                response.data = null;
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.DataIsRequired;
            }
            return response;
        }

        public async Task<JsonModel> UpdateContactSupportAsync(ContactSupportDto contactSupportDto)
        {
            if (contactSupportDto != null && !string.IsNullOrWhiteSpace(contactSupportDto.Name) && !string.IsNullOrWhiteSpace(contactSupportDto.Phone))
            {
                var contactSupportExist = await _contactSupportRepository.ContactSupportExist(contactSupportDto.SupportId);
                if (contactSupportExist)
                {
                    var contactsupport = _mapper.Map<ContactSupportModel>(contactSupportDto);
                    var contactSupportAdded = await _contactSupportRepository.UpdateContactSupport(contactsupport);
                    if (contactSupportAdded)
                    {
                        response.data = null;
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.ContactSupportUpdatedSuccessfully;
                    }
                    else
                    {
                        response.data = null;
                        response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                        response.Message = ErrorMessages.InternalServerError;
                    }
                }
                else
                {
                    response.data = null;
                    response.StatusCode = (int)StatusCodeEnum.NotFound;
                    response.Message = ErrorMessages.ContactSupportNotFound;
                }
                
            }
            else
            {
                response.data = null;
                response.StatusCode = (int)StatusCodeEnum.BadRequest;
                response.Message = ErrorMessages.DataIsRequired;
            }
            return response;
        }
    }
}
