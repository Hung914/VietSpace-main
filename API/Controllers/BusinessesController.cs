using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Exceptions;
using Application.Businesses;
using Application.Dtos;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BusinessesController : BaseApiController
    { 
        public BusinessesController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<ActionResult<List<BusinessDto>>> GetBusinesses()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessDto>> GetBusiness(Guid id)
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
        public async Task<IActionResult> CreateBusiness(Business business)
        {
            try 
            {
                if(business is null){
                    return NotFound();
                }
                var result = await Mediator.Send(new Create.Command {Business = business});
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                //TODO: log exception
                return NotFound();
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBusiness(Guid id, BusinessDto business)
        {
            
            try
            {
                if(business is null){
                    return NotFound();
                }
                business.Id = id;
                var result = await Mediator.Send(new Edit.Command {Business = business});

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                //TODO: log exception
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(Guid id)
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