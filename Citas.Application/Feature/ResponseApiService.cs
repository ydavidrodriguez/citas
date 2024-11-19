using Citas.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace Citas.Application.Feature
{
    public class ResponseApiService
    {
        public static IActionResult Response(int Statuscode, object Data = null, string message = null)
        {
            bool success = false;

            if (Statuscode >= 200 && Statuscode < 300)
                success = true;

            var result = new BaseResponseModel
            {

                StatusCode = Statuscode,
                Succes = success,
                Message = message,
                Data = Data
            };
            return new OkObjectResult(result);

        }

    }
}
