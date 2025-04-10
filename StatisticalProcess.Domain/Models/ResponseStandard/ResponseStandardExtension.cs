using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalProcess.Domain.Models
{
    public static class ResponseStandardExtension
    {
        public static ResponseStandard<TModel> SetSuccess<TModel>(this ResponseStandard<TModel> response)
        {
            response.Success = true;
            return response;
        }

        public static ResponseStandard<TModel> AddMessage<TModel>(this ResponseStandard<TModel> response, string Message)
        {
            response.Messages.Add(Message);
            return response;
        }

        public static ResponseStandard<TModel> AddMessages<TModel>(this ResponseStandard<TModel> response, List<string> Messages)
        {
            response.Messages.AddRange(Messages);
            return response;
        }

        public static ResponseStandard<TModel> SetData<TModel>(this ResponseStandard<TModel> response, TModel data)
        {
            response.Data = data;
            return response;
        }
    }
}
