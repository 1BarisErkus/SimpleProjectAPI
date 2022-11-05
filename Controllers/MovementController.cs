using Microsoft.AspNetCore.Mvc;
using SimpleProjectAPI.Data;
using SimpleProjectAPI.Models;

namespace SimpleProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : Controller
    {
        private IAppRepository _appRepository;
        public MovementController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [HttpGet]
        public IActionResult GetMovements(int id)
        {
            var movements = _appRepository.GetMovements(id).ToList();
            return Ok(movements);
        }

        /*[HttpGet("search")]
        public IActionResult GetMovementsByFilter(string txt)
        {
            var movements = _appRepository.GetMovementsByFilter(txt);
            return Ok(movements);
        }*/

        [HttpPost("add")]
        public IActionResult Add(Movement movement)
        {
            try
            {
                _appRepository.Add(movement);
                _appRepository.SaveAll();
                return Ok(movement);
            }
            catch (Exception)
            {
                return BadRequest("Beklenmedik bir hatayla karşılaşıldı.");
                //Hata mesajı spesifikleştirilebilir.
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(Movement movement)
        {
            _appRepository.Delete(movement);
            _appRepository.SaveAll();
            return Ok(movement);
        }

        [HttpPut]
        public IActionResult Update(Movement movement)
        {
            _appRepository.Update(movement);
            _appRepository.SaveAll();
            return Ok(movement);
        }

    }
}
