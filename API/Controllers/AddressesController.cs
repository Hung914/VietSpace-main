using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Addresses;
using Application.Dtos;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AddressesController : BaseApiController
    {
        public AddressesController(IMediator mediator) : base(mediator){}
        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> GetAddresses()
        {
            return HandleResult(await Mediator.Send(new Lists.Query()));
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetAddress(Guid id)
        {
            try 
            {
                var result = await Mediator.Send(new Details.Command{Id = id});
                if(result is null){
                    return NotFound();
                }
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                //TODO: log exception
                return NotFound();
            }


        }             

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Address address)
        {
            try 
            {
                if(address is null){
                    return NotFound();
                }
                var result = await Mediator.Send(new Create.Command {Address = address});
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                //TODO: log exception
                return NotFound();
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddress(Guid id, Address address)
        {
            
            try
            {
                if(address is null){
                    return NotFound();
                }
                address.Id = id;
                var result = await Mediator.Send(new Edit.Command {Address = address});

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                //TODO: log exception
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {

            try 
            {
                var result = await Mediator.Send(new Delete.Command {Id = id});
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                //TODO: log exception
                return NotFound();
            }
        }
        
    }
}