using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Dtos;
using Application.Phones;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhonesController : BaseApiController
    {
        public PhonesController(IMediator mediator) : base(mediator){}

        [HttpGet]
        public async Task<ActionResult<List<PhoneDto>>> GetPhones()
        {
            return await Mediator.Send(new Lists.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneDto>> GetPhone(Guid id)
        {
            try{
                var result = await Mediator.Send(new Details.Command{Id = id});
                if(result is null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
    
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePhone(Phone phone)
        {
            try{
                if(phone is null)
                {
                    return NotFound();
                }
                var result = await Mediator.Send(new Create.Command{Phone = phone});
                return Ok(result);

            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhone(Guid id, Phone phone)
        {
            try{
                if(phone is null)
                {
                    return NotFound();
                }
                phone.Id = id;
                var result = await Mediator.Send(new Edit.Command{Phone = phone});
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhone(Guid id)
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