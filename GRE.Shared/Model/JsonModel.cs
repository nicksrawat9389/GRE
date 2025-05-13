using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRE.Shared.Model
{
    public class JsonModel
    {
        public JsonModel()
        {
            
        }

        public JsonModel(object responseData, string message, int statusCode, string appError = "")
        {
            data = responseData;
            Message = message;
            StatusCode = statusCode;
            AppError = appError;

        }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public int expires_in { get; set; }
        public object data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        
        public string AppError { get; set; }

    }
    public class Meta
    {
        public Meta()
        {

        }
        public Meta(dynamic T, dynamic searchFilterModel)
        {
            try
            {
                TotalRecords = T != null && T.Count > 0 ? T[0].TotalRecords : 0;
                CurrentPage = searchFilterModel.pageNumber;
                PageSize = searchFilterModel.pageSize;
                DefaultPageSize = searchFilterModel.pageSize;
                TotalPages = Math.Ceiling(Convert.ToDecimal((T != null && T.Count > 0 ? T[0].TotalRecords : 0) / searchFilterModel.pageSize));
            }
            catch (Exception)
            {
            }
        }
        public decimal TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int DefaultPageSize { get; set; }
        public decimal TotalRecords { get; set; }
    }
}
