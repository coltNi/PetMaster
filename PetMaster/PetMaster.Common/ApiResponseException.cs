using System;
using System.Net;

namespace PetMaster.Common
{
    public class ApiResponseException : Exception
    {
        public HttpStatusCode ResponseStatusCode { get; }

        public ApiResponseException(HttpStatusCode responseStatusCode, string errorMsg) : base(errorMsg)
        {
            ResponseStatusCode = responseStatusCode;
        }
    }

}
