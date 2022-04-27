using ExamTrainer.Models;
using ExamTrainer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamTrainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnwserController : ControllerBase
    {
        private IAnwserService _anwserService;

        public AnwserController(IAnwserService anwserService)
        {
            this._anwserService = anwserService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_anwserService.GetById(id));
            }
            catch (Exception)
            {
                return NotFound("The Anwser you are searching can not be found");
            }
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_anwserService.GetAll());

        [HttpPost]
        public IActionResult Create(Anwser anwser)
        {
            try
            {
                return Ok(_anwserService.Create(anwser));
            }
            catch (Exception)
            {
                return BadRequest("Error on Creating Anwser entity");
            }
        }

        [HttpPut]
        public IActionResult Update(Anwser anwser)
        {
            try
            {
                return Ok(_anwserService.Update(anwser));
            }
            catch (Exception)
            {
                return BadRequest("Error updating Anwser Entity");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Anwser anwser)
        {
            try
            {
                _anwserService.Delete(anwser);
                return Ok("deleted");
            }
            catch (Exception)
            {
                return BadRequest("error deleting exam entity");
            }
        }


        [HttpGet("Search/{searchText}")]
        public IActionResult Search(string searchText)
        {
            try
            {
                return Ok(_anwserService.SearchByText(searchText));
            }
            catch (Exception)
            {
                return BadRequest("Error searching Anwser by Text");
            }
        }
    }
}
