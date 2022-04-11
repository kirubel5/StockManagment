using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.Persons.Commands.CreatePerson;
using StockManagment.Application.Persons.Commands.UpdatePerson;
using StockManagment.Application.Persons.Commands.DeletePerson;
using StockManagment.Application.Persons.Queries.GetPerson;
using System.Threading.Tasks;
using Application.PersonLists.Queries.GetPersonsQuery;

namespace StockManagment.Presentation.Controllers
{

    public class PersonController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PersonDto>> Get([FromQuery] GetPersonQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<PersonList>> Get([FromQuery] GetPersonsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePersonCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(string code, UpdatePersonCommand command)
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
            await Mediator.Send(new DeletePersonCommand { Code = code });

            return NoContent();
        }
    }
}
