using ApiLayer.Core.Application.Featuers.CORS.Commands;
using ApiLayer.Core.Application.Featuers.CORS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await this.mediator.Send(new GetAllProductsQueryRequest());
            return Ok(data);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result=await this.mediator.Send(new GetProductQueryRequest(id));
            return result == null ? NotFound() : Ok(result); // yazılın bir algoritmayıda experjına çevirmek için daha az kod ggibi seçili tut ilgili algoritmayı ve solda bi buton çıkacak ona tıkla experjına tıkla
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var reslt = await this.mediator.Send(new DeleteProductCommandRequest(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }

    }
}
