using ExamTrainer.Models;
using ExamTrainer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamTrainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
 
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_examService.GetById(id));
            }
            catch (Exception)
            {
                return NotFound("The Exam you are searching can not be found");
            }
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_examService.GetAll());

        [HttpPost]
        public IActionResult Create(Exam exam)
        {
            try
            {
                return Ok(_examService.Create(exam));
            }
            catch (Exception)
            {
                return BadRequest("Error on Creating Exam entity");
            }
        }
        
        [HttpPut]
        public IActionResult Update(Exam exam)
        {
            try
            {
                return Ok(_examService.Update(exam));
            }
            catch (Exception)
            {
                return BadRequest("Error updating Exam Entity");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Exam exam)
        {
            try
            {
                _examService.Delete(exam);
                return Ok("deleted");
            }
            catch (Exception)
            {
                return BadRequest("error deleting exam entity");
            }
        }

        [HttpGet("{id:int}/Questions")]
        public IActionResult getExamWithQuestions(int id)
        {
            try
            {
                return Ok(_examService.GetWithQuestions(id));
            }
            catch (Exception)
            {
                return NotFound("Exam entity not found");
            }
        }

        [HttpGet("{id:int}/Questions/Anwsers")]
        public IActionResult getExamWithQuestionsWithAnwesers(int id)
        {
            try
            {
                return Ok(_examService.GetWithQuestionsWithAnwesers(id));
            }
            catch (Exception)
            {
                return NotFound("Exam entity not found");
            }
        }

        [HttpGet("Search/{searchText}")]
        public IActionResult Search(string searchText)
        {
            try
            {
                return Ok(_examService.SearchByText(searchText));
            }
            catch (Exception)
            {
                return BadRequest("Error searching Exam by Text");
            }
        }

    }
}
