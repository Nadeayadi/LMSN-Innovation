using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LMSN_Innovation.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        // na- Endpoint pour gérer les erreurs globales
        [Route("/error")]
        public IActionResult HandleError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>(); // na- Récupérer les détails de l'exception
            var exception = context?.Error;

            // na- Logique pour renvoyer un message d'erreur standard
            return Problem(detail: exception?.Message, statusCode: 500); // na-Renvoyer une erreur 500 avec le message de l'exception
        }
    }
}
