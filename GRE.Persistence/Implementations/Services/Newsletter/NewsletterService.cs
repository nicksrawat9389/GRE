using AutoMapper;
using Azure;
using GRE.Application.Interfaces.Repository.Newsletter;
using GRE.Application.Interfaces.Services.Newsletter;
using GRE.Domain.Models.Newsletter;
using GRE.Shared.DTOs.Newsletter;
using GRE.Shared.Enums;
using GRE.Shared.Messages;
using GRE.Shared.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Persistence.Implementations.Services.Newsletter
{
    public class NewsletterService : INewsletterService
    {
        JsonModel response = new();
        private IConfiguration _configuration;
        private INewsletterRepository _newsletterRepository;
        private IMapper _mapper;
        public NewsletterService(IConfiguration configuration,INewsletterRepository newsletterRepository,IMapper mapper) 
        {
            _mapper = mapper;

            _newsletterRepository = newsletterRepository;
            _configuration = configuration;
        }
        public async Task<JsonModel> AddNewsLetterAsync(NewsletterDto newsletterDto)
        {
            try

            {

                if (string.IsNullOrEmpty(newsletterDto?.PdfBase64) || string.IsNullOrEmpty(newsletterDto.PdfName))
                {
                    return response;
                }

                // Ensure file name is safe

                var fileName = Path.GetFileName($"{newsletterDto.PdfName}");

                string folder = Path.Combine(Directory.GetCurrentDirectory(), _configuration["GREDocs:NewsletterPath"]!);

                // Create directory if not exists
                var directoryPath = Path.GetDirectoryName(folder);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(folder, fileName);

                // Convert Base64 string to bytes and save the file

                byte[] fileBytes = Convert.FromBase64String(newsletterDto.PdfBase64);

                await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                var newspaper = _mapper.Map<NewsletterModel>(newsletterDto);
                bool result = await _newsletterRepository.CreateNewsLetter(newspaper);
                if (result)
                {
                    response.data = null;
                    response.StatusCode = (int)StatusCodeEnum.Success;
                    response.Message = SuccessMessages.NewsletterAddedSuccessfully;
                }
                else
                {
                    response.data = null;
                    response.StatusCode = (int)StatusCodeEnum.InternalServerError;
                    response.Message = ErrorMessages.InternalServerError;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;

        }

        public async Task<JsonModel> DeleteNewsLetterAsync(int newsletterId)
        {
            bool newsPaperExist = await _newsletterRepository.NewsletterExist(newsletterId);
            if (newsPaperExist)
            {
                var newsletterDeleted = await _newsletterRepository.DeleteNewsletter(newsletterId);
                if (newsletterDeleted)
                {
                    response.data = null;
                    response.StatusCode = (int)StatusCodeEnum.Success;
                    response.Message = SuccessMessages.NewsletterDeletedSuccessfully;
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
                response.Message = ErrorMessages.NewsletterNotFound;
            }
            return response;
        }

        public async Task<JsonModel> UpdateNewsLetterAsync(NewsletterDto newsletterDto)
        {
            try

            {

                if (string.IsNullOrEmpty(newsletterDto?.PdfBase64) || string.IsNullOrEmpty(newsletterDto.PdfName))
                {
                    return response;
                }

                // Ensure file name is safe
                bool newsPaperExist = await _newsletterRepository.NewsletterExist(newsletterDto.NewsletterId);
                if (newsPaperExist) {
                    var fileName = Path.GetFileName($"{newsletterDto.PdfName}");

                    string folder = Path.Combine(Directory.GetCurrentDirectory(), _configuration["GREDocs:NewsletterPath"]!);

                    // Create directory if not exists
                    var directoryPath = Path.GetDirectoryName(folder);

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string filePath = Path.Combine(folder, fileName);

                    // Convert Base64 string to bytes and save the file

                    byte[] fileBytes = Convert.FromBase64String(newsletterDto.PdfBase64);

                    await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                    var newspaper = _mapper.Map<NewsletterModel>(newsletterDto);
                    bool result = await _newsletterRepository.UpdateNewsLetter(newspaper);
                    if (result)
                    {
                        response.data = null;
                        response.StatusCode = (int)StatusCodeEnum.Success;
                        response.Message = SuccessMessages.NewsletterUpdatedSuccessfully;
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
                    response.Message = ErrorMessages.NewsletterNotFound;
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;

        }
            

    }
}
