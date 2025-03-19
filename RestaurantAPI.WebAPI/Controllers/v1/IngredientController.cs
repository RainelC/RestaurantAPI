using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class IngredientController : BaseApiController
    {
        private readonly IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredient)
        {
            _ingredientService = ingredient;
        }   

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(SaveIngredientViewModel vm)
        {
            try { 
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _ingredientService.Add(vm);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(SaveIngredientViewModel)))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, SaveIngredientViewModel vm)
        {
            try 
            { 
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _ingredientService.Update(vm, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(IngredientViewModel)))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var ingredients = await _ingredientService.GetAll();

                if (ingredients == null || ingredients.Count == 0)
                {
                    return NoContent();
                }
                return Ok(ingredients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(SaveIngredientViewModel)))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ingredient = await _ingredientService.GetById(id);

                if (ingredient == null)
                {
                    return NoContent();
                }
                return Ok(ingredient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
