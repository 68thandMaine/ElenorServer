using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElenorServer.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public MessagesController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody]Messages message)
        {
            try
            {
                //if (message.IsObjectNull())
                //{
                //    _logger.LogError("The message object sent from the client is null.");
                //    return BadRequest("The message object is null.");
                //}

                if (!ModelState.IsValid)
                {
                    _logger.LogError("The message object sent from the client is invalid.");
                    return BadRequest("The message object is invalid.");
                }

                _repository.Messages.CreateMessage(message);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMessage action: {ex.Message}.");
                return StatusCode(500, "Internal server erro.r");
            }
        }

        [HttpGet]
        public IActionResult GetAllMessages()
        {
            try
            {
                var messages = _repository.Messages.GetAllMessages();
                _logger.LogInfo($"Returned all messages from the database.");
                return Ok(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMessages action: {ex.Message}.");
                return StatusCode(509, "Internal server error.");
            }
        }
    }
}
