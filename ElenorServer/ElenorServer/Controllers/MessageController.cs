using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;
using Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElenorServer.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ILoggerManager _logger; // This is the logger dependency. I'm having issues getting the logger to work in the test file.
        private IRepositoryWrapper _repository; // This is the repository dependency

        public MessageController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody]Message message)
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

                _repository.Message.CreateMessage(message);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMessage action: {ex.Message}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var Messages = _repository.Message.GetAllMessages();
                _logger.LogInfo($"Returned all Message from the database.");
                return Ok(Messages);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMessage action: {ex.Message}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}", Name = "MessageById")]
        public IActionResult GetMessageById(Guid id)
        {
            try
            {
                var message = _repository.Message.GetMessageById(id);

                if (message.Id.Equals(Guid.Empty))
                {
                    _logger.LogError($"Message with id: {id}, has not been found in the database.");
                    return NotFound();
                }

                else
                {
                    _logger.LogInfo($"Returned message with id: {id}");
                    return Ok(message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetMessageById action: {ex.Message}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("${id}")]
        public IActionResult DeleteMessage(Guid id)
        {
            try
            {
                var message = _repository.Message.GetMessageById(id);
                //if (message.IsEmptyObject())
                //{
                //    _logger.LogError($"Message with id {id}, has not been found in the database");
                //    return NotFound();
                //}
                _repository.Message.DeleteMessage(message);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMessage action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
