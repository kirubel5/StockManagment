using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.Consignees.Commands.CreateConsignee;
using StockManagment.Application.Consignees.Commands.UpdateConsignee;
using StockManagment.Application.Consignees.Commands.DeleteConsignee;
using StockManagment.Application.Consignees.Queries.GetConsignee;
using System.Threading.Tasks;
using Application.ConsigneeLists.Queries.GetConsignees;
using Microsoft.AspNetCore.Authorization;

namespace StockManagment.Presentation.Controllers
{
    [Authorize]
    public class ConsigneeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ConsigneeDto>> Get([FromQuery] GetConsigneeQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ConsigneeList>> Get([FromQuery] GetConsigneesQuery query)
        {
            return await Mediator.Send(query);
        }

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
