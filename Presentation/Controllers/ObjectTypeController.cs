using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.ObjectTypes.Commands.CreateObjectType;
using StockManagment.Application.ObjectTypes.Commands.DeleteObjectType;
using StockManagment.Application.ObjectTypes.Commands.UpdateObjectType;
using StockManagment.Application.ObjectTypes.Queries.GetObjectType;
using StockManagment.Presentation.Controllers;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ObjectTypeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ObjectTypeDto>> Get([FromQuery] GetObjectTypeQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateObjectTypeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(string code, UpdateObjectTypeCommand command)
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
            await Mediator.Send(new DeleteObjectTypeCommand { Code = code });

            return NoContent();
        }
    }
}
