using ChatApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController (IChat chat) : ControllerBase
    {
        private readonly IChat _chat = chat;



    }
}
