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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderVM order)
        {
            order.OrderName = order.OrderName.ToTitleCase();
            await _service.Add(_mapper.Map<Order>(order));
            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Order order)
        {
            var result = await _service.GetById(id);
            if (result == null) return BadRequest();
            var result2 = await _service.GetById(order.Id);
            if (result2 == null) return BadRequest();

            order.OrderName = order.OrderName.ToTitleCase();
            await _service.Update(id, order);
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
            return Ok(_mapper.Map<OrderVM>(result));
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(_mapper.Map<List<OrderVM>>(await _service.GetAll()));

    }
}
