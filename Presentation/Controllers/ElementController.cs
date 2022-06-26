using Application.ElementLists.Queries.GetElements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters;
using StockManagment.Application.Elements.Commands.CreateElement;
using StockManagment.Application.Elements.Commands.DeleteElement;
using StockManagment.Application.Elements.Commands.UpdateElement;
using StockManagment.Application.Elements.Queries.GetElement;
using System.Threading.Tasks;

namespace StockManagment.Presentation.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(AuthorizeActionFilter))]
    public class ElementController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ElementDto>> Get([FromQuery] GetElementQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ElementList>> Get([FromQuery] GetElementsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateElementCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(string code, UpdateElementCommand command)
        {
            if (code != command.Code)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string code)
        {
            await Mediator.Send(new DeleteElementCommand { Code = code });

            return NoContent();
        }
    }
}
