using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createSomeFeatureEntityCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            
            return Ok(result);
        }
    }

}