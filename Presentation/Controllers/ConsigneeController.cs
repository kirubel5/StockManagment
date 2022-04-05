using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.Consignees.Commands.CreateConsignee;
using StockManagment.Application.Consignees.Commands.UpdateConsignee;
using StockManagment.Application.Consignees.Commands.DeleteConsignee;
using StockManagment.Application.Consignees.Queries.GetConsignee;
using System.Threading.Tasks;

namespace StockManagment.Presentation.Controllers
{

    public class ConsigneeController : ApiControllerBase
    {
       

        [HttpPost]
        public async Task<ActionResult> Create(CreateConsigneeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(string code, UpdateConsigneeCommand command)
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
            await Mediator.Send(new DeleteConsigneeCommand { Code = code });

            return NoContent();
        }
    }
}
