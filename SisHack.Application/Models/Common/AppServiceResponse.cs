using Newtonsoft.Json;
using SisHack.Application.Interfaces;

namespace SisHack.Application.Models.Common
{
    public class AppServiceResponse<T> : IAppServiceResponse where T : class
    {
        #region Public Constructors

        public AppServiceResponse(T data, string message, bool sucess)
        {
            Data = data;
            Message = message;
            Success = sucess;
        }

        #endregion Public Constructors

        #region Public Properties

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        #endregion Public Properties

    }
}