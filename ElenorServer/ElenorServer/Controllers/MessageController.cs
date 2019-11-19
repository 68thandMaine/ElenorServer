using System;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.DataTransferObjects;
using AutoMapper;
using System.Collections.Generic;
using Entities.DataTransferObjects.Message;
using Entities.Models;

namespace ElenorServer.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ILoggerManager _logger; // This is the logger dependency. I'm having issues getting the logger to work in the test file.
        private IRepositoryWrapper _repository; // This is the repository dependency
        private IMapper _mapper;

        public MessageController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody]MessageForCreationDto message)
        {
            try
            {
                if (message == null)
                {
                    _logger.LogError("The message object sent from the client is null");
                    return BadRequest("The message object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("The message object sent from the client is invalid.");
                    return BadRequest("The message object is invalid.");
                }
                var messageEntity = _mapper.Map<Message>(message);
                _repository.Message.CreateMessage(messageEntity);
                _repository.Save();
                var createdMessage = _mapper.Map<MessageDto>(messageEntity);
                return CreatedAtRoute("MessageById", new { id = createdMessage.Id }, createdMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside CreateMessage action: {ex.Message}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var messages = _repository.Message.GetAllMessages();
                _logger.LogInfo($"Returned all Message from the database.");
                var messagesResult = _mapper.Map<IEnumerable<MessageDto>>(messages);
                return Ok(messagesResult);
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

                if (message == null)
                {
                    _logger.LogError($"Message with id: {id}, has not been found in the database.");
                    return NotFound();
                }
                _logger.LogInfo($"Returned message with id: {id}");
                var messageResult = _mapper.Map<MessageDto>(message);
                return Ok(messageResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetMessageById action: {ex.Message}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(Guid id)
        {
            try
            {
                var message = _repository.Message.GetMessageById(id);
                if (message == null)
                {
                    _logger.LogError($"Message with id {id} was not found in the database.");
                    return NotFound();
                }
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

        [HttpPut("{id}")]
        public IActionResult UpdateMessage(Guid id, [FromBody]MessageDto message)
        {
            try
            {
                if (message == null)
                {
                    _logger.LogError("Message object from the client is null.");
                    return BadRequest("Message object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Message object sent from client");
                    return BadRequest("Invalid Message object");
                }

                var messageEntity = _repository.Message.GetMessageById(id);
                if (messageEntity == null)
                {
                    _logger.LogError($"Message with id: {id} was not found in the db");
                    return NotFound();
                }
                _mapper.Map(message, messageEntity);
                _repository.Message.UpdateMessage(messageEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
