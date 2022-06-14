using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.LineItems.Commands.CreateLineItem;
using StockManagment.Application.LineItems.Commands.UpdateLineItem;
using StockManagment.Application.LineItems.Commands.DeleteLineItem;
using StockManagment.Application.LineItems.Queries.GetLineItem;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace StockManagment.Presentation.Controllers
{
    [Authorize]
    public class LineItemController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<LineItemDto>> Get([FromQuery] GetLineItemQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateLineItemCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(string code, UpdateLineItemCommand command)
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
            await Mediator.Send(new DeleteLineItemCommand { Code = code });

            return NoContent();
        }
    }
}
