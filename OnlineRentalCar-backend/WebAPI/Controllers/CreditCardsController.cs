using Business.Abstract;
using Core.Utilities.Business;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICustomerCreditCardService _customerCreditCardService;
        private readonly ICreditCardService _creditCardService;

        public CreditCardsController(ICustomerCreditCardService customerCreditCardService, ICreditCardService creditCardService)
        {
            _customerCreditCardService = customerCreditCardService;
            _creditCardService = creditCardService; 
        }

        [HttpPost("getcreditcardsbycustomerid")]
        public IActionResult GetCreditCardsByCustomerId([FromBody] int customerId)
        {
            var result = _customerCreditCardService.GetSavedCreditCardsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    [HttpPost("registercreditcard")]
    public IActionResult RegisterCreditCard(CreditCard creditCard)
    {
      
      Trace.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
      var result = _creditCardService.Add(creditCard);
      if (result.Success)
      {
        return Ok(result);
      }

      return BadRequest(result);
    }

    [HttpPost("savecreditcard")]
        public IActionResult SaveCreditCard(CustomerCreditCardModel customerCreditCardModel)
        {
      Trace.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

      var result = _customerCreditCardService.SaveCustomerCreditCard(customerCreditCardModel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletecreditcard")]
        public IActionResult DeleteCreditCard(CustomerCreditCardModel customerCreditCardModel)
        {
            var result = _customerCreditCardService.DeleteCustomerCreditCard(customerCreditCardModel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
