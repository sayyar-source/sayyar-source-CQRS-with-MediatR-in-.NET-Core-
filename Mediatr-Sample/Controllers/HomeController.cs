using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mediatr_Sample.Models;
using Mediatr_Sample.Service.Commands;
using MediatR;
using Mediatr_Sample.Service.Queries;
using Mediatr_Sample.Service.Commands.Create;
using Mediatr_Sample.Service.Queries.FindAll;
using Mediatr_Sample.Service.Queries.FindById;

namespace Mediatr_Sample.Controllers
{
    [Route("api/{controller}")]
    public class HomeController : Controller
    {

        private readonly IMediator _mediator;
       
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand  createCustomerCommand )
        {
            CustomerDto customer = await _mediator.Send(createCustomerCommand);
         
            return Ok(customer.Id);
        }
        [HttpGet]
        [Route("findall")]
        public async Task<IActionResult> FindAll()
        {
            var customer =await _mediator.Send(new CustomerFindAllQuery());
            return Ok(customer);
        }
        [HttpGet]
        [Route("findbyid")]
        public async Task<IActionResult> FindCustomerById(int id)
        {
            var customer =await _mediator.Send(new FindCustomerByIdQuery { Id = id });
            return Ok(customer);
        }





    }
}
