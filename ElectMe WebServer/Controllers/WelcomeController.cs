using ElectMe_WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace ElectMe_WebServer.Controllers
{
    [ApiController]
    [Route("[welcome]")]
    public class WelcomeController
    {
    //     private readonly ILogger<WelcomeController> _logger;
    //     
    //     public WelcomeController(ILogger<WelcomeController> logger)
    //     {
    //         _logger = logger;
    //     }
    //     //
    //     // [HttpGet]
    //     // public EncryptionSuite GetEncryptionSuite()
    //     // {
    //     //     //todo: "Implement retrieve encryptionSuite" 
    //     //     return null;
    //     // }
    //     
    //     [HttpPost]
    //     [Route("/[newConnection]")]
    //     public KeyExchangeParameters PostNewConnection(EncryptionParameters parameters)
    //     {
    //         // todo: Implement post newConnection
    //         // todo: decryption using Web API private key
    //         // todo: generate shared key using "parameters"
    //         // todo: save the public key of the client device. When do you delete it though?
    //         // todo: send response back as???
    //         return null;
    //     }
    }
}