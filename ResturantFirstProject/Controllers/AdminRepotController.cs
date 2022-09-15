using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantFirstProject.Models;
using ResturantFirstProject.Services;
using System.Threading.Tasks;

namespace ResturantFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRepotController : ControllerBase
    {
        private readonly IReportService _service;
        public AdminRepotController(IReportService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAll/GetReport")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet]
        [Route("GetAll/WriteReportToCSV")]
        public async Task<IActionResult> WriteToCSV() 
        {
            await _service.PrintToFile();

          return  Ok("Done");
        } 
    }
}
