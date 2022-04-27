using ExamTrainer.Models;
using ExamTrainer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamTrainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_questionService.GetById(id));
            }
            catch (Exception)
            {
                return NotFound("The Question you are searching can not be found");
            }
        }

        [HttpGet("{id:int}/Anwsers")]
        public IActionResult GetByIdWithAnwsers(int id)
        {
            try
            {
                return Ok(_questionService.GetByIdWithAnwsers(id));
            }
            catch (Exception)
            {
                return NotFound("The Question you are searching can not be found");
            }
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_questionService.GetAll());

        [HttpPost]
        public IActionResult Create(Question question)
        {
            try
            {
                return Ok(_questionService.Create(question));
            }
            catch (Exception)
            {
                return BadRequest("Error on Creating Question entity");
            }
        }

        [HttpPut]
        public IActionResult Update(Question question)
        {
            try
            {
                return Ok(_questionService.Update(question));
            }
            catch (Exception)
            {
                return BadRequest("Error updating Question Entity");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Question question)
        {
            try
            {
                _questionService.Delete(question);
                return Ok("deleted");
            }
            catch (Exception)
            {
                return BadRequest("error deleting quastion entity");
            }
        }

        [HttpGet("Search/{searchText}")]
        public IActionResult Search(string searchText)
        {
            try
            {
                return Ok(_questionService.SearchByText(searchText));
            }
            catch (Exception)
            {
                return BadRequest("Error searching Question by Text");
            }
        }

    }
}
