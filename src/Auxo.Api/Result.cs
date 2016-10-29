using System.Net;
using Auxo.Core;
using Auxo.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Auxo.Api
{
    public static class Result
    {
        public static IActionResult Factory(HttpStatusCode code, object data)
        {
            var messages = Locator.Service<IMessageHandler<Message>>();
            if (messages.HasMessages())
                return new ObjectResult(messages.Messages()) { StatusCode = (int) HttpStatusCode.BadRequest }; 
            return new ObjectResult(data) {
                StatusCode = (int) code
            };
        }
        public static IActionResult Factory() => Factory(HttpStatusCode.NoContent, null);
    }
}
