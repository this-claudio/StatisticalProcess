namespace StatisticalProcess.Domain.Models
{
    public static class ResponseStandardExtension
    {
        public static ResponseStandard<TModel> SetSuccess<TModel>(this ResponseStandard<TModel> response, bool success)
        {
            response.Success = success;
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

        public static ResponseStandard<TModel> AddData<TModel>(this ResponseStandard<TModel> response, TModel data)
        {
            response.Data = data;
            return response;
        }
    }
}
