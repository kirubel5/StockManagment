﻿using Microsoft.AspNetCore.Mvc;
using StockManagment.Application.Vouchers.Commands.CreateVoucher;
using StockManagment.Application.Vouchers.Commands.UpdateVoucher;
using StockManagment.Application.Vouchers.Commands.DeleteVoucher;
using StockManagment.Application.Vouchers.Queries.GetVoucher;
using System.Threading.Tasks;

namespace StockManagment.Presentation.Controllers
{

    public class VoucherController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<VoucherDto>> Get([FromQuery] GetVoucherQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateVoucherCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(string code, UpdateVoucherCommand command)
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
            await Mediator.Send(new DeleteVoucherCommand { Code = code });

            return NoContent();
        }
    }
}
