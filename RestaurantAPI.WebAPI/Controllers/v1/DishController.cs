using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Dish;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DishController : BaseApiController
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;

        public DishController(IDishService service, IMapper mapper)
        {
            _dishService = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(SaveDishViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                await _dishService.Add(vm);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(SaveDishViewModel vm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _dishService.Update(vm, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var dishes = await _dishService.GetAll();
                if (dishes == null || dishes.Count == 0)
                {
                    return NoContent();
                }
                return Ok(dishes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var dish = await _dishService.GetById(id);
                if (dish == null)
                {
                    return NoContent();
                }
                return Ok(dish);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
