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
    public class ResturantMenuController : ControllerBase
    {
        private readonly IResturantMenuService _service;
        private readonly IMapper _mapper;
        public ResturantMenuController(IResturantMenuService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ResturantMenuVM restaurantMenuVM)
        {
            restaurantMenuVM.MealName = restaurantMenuVM.MealName.ToTitleCase();
            await _service.Add(_mapper.Map<RestaurantMenu>(restaurantMenuVM));
            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]RestaurantMenu resturantMenu)
        {
            var result = await _service.GetById(id);
            if (result == null) return BadRequest();
            var result2 = await _service.GetById(resturantMenu.Id);
            if (result2 == null) return BadRequest();

            resturantMenu.MealName = resturantMenu.MealName.ToTitleCase();
            await _service.Update(id, resturantMenu);
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
            return Ok(result);
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(_mapper.Map<List<ResturantMenuVM>>(await _service.GetAll()));

    }
}
