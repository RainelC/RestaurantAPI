using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.Services;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Table;

namespace RestaurantAPI.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TableController : BaseApiController
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(SaveTableViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _tableService.Add(vm);
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
        public async Task<IActionResult> Update(SaveTableViewModel vm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _tableService.Update(vm, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(TableViewModel)))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var tables = await _tableService.GetAll();

                if (tables == null || tables.Count == 0)
                {
                    return NoContent();
                }
                return Ok(tables);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(SaveTableViewModel)))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var table = await _tableService.GetById(id);

                if (table == null)
                {
                    return NoContent();
                }
                return Ok(table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = (typeof(OrderViewModel)))]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetTableOrden(int id)
        //{
        //    try
        //    {
        //        var orders = await _tableService.GetTableOrdenAsync(id);

        //        if (orders == null || orders.Count == 0)
        //        {
        //            return NoContent();
        //        }
        //        return Ok(orders);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

    }
}
