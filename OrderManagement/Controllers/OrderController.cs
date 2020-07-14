using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Interface;
using OrderManagement.Models.Common;
using OrderManagement.Models.Payment;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST api/values/
        //[HttpGet("ProcessOrder/{productId}/{memberId}")]
        public async Task<ActionResult> ProceesOrder([FromBody] OrderRequest request)
       // public async Task<ActionResult> ProceesOrder(int productId,int memberId)
        {
            //OrderRequest request = new OrderRequest()
            //{ 
              //  ProductId = productId,
                //MemberId = memberId
            //};
            var validationResult = new ValidationResult();
            if (Validate(validationResult, request).IsSuccess)
            {
                try
                {
                    var res = await _orderService.ProcessOrder(request);
                    return Ok(res);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                // return Ok("Success");
            }
            else
                return StatusCode((int)HttpStatusCode.BadRequest, validationResult);
          
        }

        private ValidationResult Validate(ValidationResult validationResult, OrderRequest request)
        {
            validationResult.IsSuccess = false;
            if (request == null)
            {
                validationResult.Message = "Invalid Request.";
                validationResult.ErrorCode = ErrorCode.InvalidRequest;
            }
            else if (request.ProductId == 0)
            {
                validationResult.Message = "ProductId is required.";
                validationResult.ErrorCode = ErrorCode.ProductRequired;
            }
            else if ((request.PaymentTypeId == PaymentType.Membership || 
            request.PaymentTypeId == PaymentType.Upgrade))                
                
            {
                if (request.MemberInfo == null
                || String.IsNullOrEmpty(request.MemberInfo?.Name))
                {
                    validationResult.Message = "Invalid Member Details.";
                    validationResult.ErrorCode = ErrorCode.MemberIdRequired;
                }
                else
                    validationResult.IsSuccess = true;
            }
            else if(request.MemberId == 0)
            {
                validationResult.Message = "MemberId is required.";
                validationResult.ErrorCode = ErrorCode.MemberIdRequired;
            }
            else
                validationResult.IsSuccess = true;
            return validationResult;
        }

       
    }
}
