using System;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;

namespace ElenorServer.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileContentController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public ProfileContentController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody]ProfileContent profileContent)
        {
            try
            {
                //if(profileContent.IsObjectNull())
                //{
                //    _logger.LogError("The profile content sent from the client is invalid");
                //    return BadRequest("The profile content object is invalid.");
                //}

                if (!ModelState.IsValid)
                {
                    _logger.LogError("The profile content sent from the client is invalid");
                    return BadRequest("The profile content object is invalid.");
                }
                _repository.Profile.CreateProfile(profileContent);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProfile action: {ex.Message}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var Profile = _repository.Profile.GetProfileContent();
                return Ok(Profile);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong when returning the profile content: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("${id}")]
        public IActionResult DeleteMessage(Guid id)
        {
            try
            {
                var profile = _repository.Profile.GetProfileContent();

                _repository.Profile.DeleteProfile(profile[0]);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong when deleting the profile: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
