using Core.Application.Requests;
using ECommerce.Application.Abstractions.Storage;
using ECommerce.Application.Features.ProductImagesFile.Commands.ChangeShowcaseImage;
using ECommerce.Application.Features.ProductImagesFile.Commands.CreateProductImage;
using ECommerce.Application.Features.ProductImagesFile.Commands.DeleteProductImage;
using ECommerce.Application.Features.ProductImagesFile.Dtos;
using ECommerce.Application.Features.ProductImagesFile.Queries.GetProductImages;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Commands.DeleteProduct;
using ECommerce.Application.Features.Products.Commands.UpdateProduct;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Models;
using ECommerce.Application.Features.Products.Queries.GetByIdProduct;
using ECommerce.Application.Features.Products.Queries.GetListProduct;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
            ProductListModel productListModel = await Mediator.Send(getListProductQuery);
            return Ok(productListModel);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQuery getByIdProductQuery)
        {
            GetByIdProductDto getByIdProductDto = await Mediator.Send(getByIdProductQuery);
            return Ok(getByIdProductDto);
        }

        [HttpPost]
        //[/*Authorize(AuthenticationSchemes = "Admin")]*/
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createProductCommand)
        {
            CreatedProductDto result = await Mediator.Send(createProductCommand);
            return Created("", result);
        }

        [HttpPut]
        //[Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand updateProductCommand)
        {
            UpdatedProductDto result = await Mediator.Send(updateProductCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand deleteProductCommand)
        {
            DeletedProductDto result = await Mediator.Send(deleteProductCommand);
            return Ok(result);
        }

        [HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Upload([FromQuery] CreateProductImageCommand createProductImageCommand)
        {
            createProductImageCommand.Files = Request.Form.Files;
            CreatedProductImageDto createdProductImageDto = await Mediator.Send(createProductImageCommand);
            return Ok();
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQuery getProductImagesQuery)
        {
            List<GetProductImagesDto> getProductImagesDto = await Mediator.Send(getProductImagesQuery);
            return Ok(getProductImagesDto);
        }
        [HttpDelete("[action]/{id}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageCommand deleteProductImageCommand, [FromQuery] string imageId)
        {
            deleteProductImageCommand.ImageId = imageId;
            DeletedProductImageDto deletedProductImageDto = await Mediator.Send(deleteProductImageCommand);

            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommand changeShowcaseImageCommand)
        {
            ChangedShowcaseImageDto changedShowcaseImageDto = await Mediator.Send(changeShowcaseImageCommand);
            return Ok(changedShowcaseImageDto);
        }
    }
}