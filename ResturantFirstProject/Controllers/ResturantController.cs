using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantFirstProject.Extentions;
using ResturantFirstProject.Models;
using ResturantFirstProject.Services;
using ResturantFirstProject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturantFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _service;
        private readonly IMapper _mapper;
        public ResturantController(IResturantService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ResturntVM resturntVM)
        {
            resturntVM.Name = resturntVM.Name.ToTitleCase();
            await _service.Add(_mapper.Map<Restaurant>(resturntVM));
            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]Restaurant restaurant)
        {
            var result = await _service.GetById(id);
            if(result == null)return BadRequest();
            var result2 = await _service.GetById(restaurant.Id);
            if (result2 == null) return BadRequest();

            restaurant.Name = restaurant.Name.ToTitleCase();
            await _service.Update(id, restaurant);
            return Ok();
        }
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return BadRequest();
            await _service.Delete(id);
            return Ok();
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return BadRequest();
            return Ok(_mapper.Map<ResturntVM>(result));
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(_mapper.Map<List<ResturntVM>>(await _service.GetAll()));
            

    }
}
