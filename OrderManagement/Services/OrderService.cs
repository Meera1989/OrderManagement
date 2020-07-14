using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Interface;
using OrderManagement.Models.Common;
using OrderManagement.Models.Membership;
using OrderManagement.Models.Payment;
using OrderManagement.Models.Products;

namespace OrderManagement.Services
{
    public class OrderService:IOrderService
    {
        private readonly IMemberService _memberService;
        private readonly IProductService _productService;

        public OrderService(IMemberService memberService,IProductService productService)
        {
            _memberService = memberService;
            _productService = productService;
        }

        public async Task<OrderResponse> ProcessOrder(OrderRequest request)
        {

            var invoiceRequest = ProcessRequest(request);
            var response = await Checkout(invoiceRequest);
            if(response.IsSuccess)
            {
                var invoicePackingSlip = GeneratePackingSlip(response);
                //SendNotificationEmailToUser(invoicePackingSlip); -- if type is product
            }
            return response;
        }



        private Invoice ProcessRequest(OrderRequest request)
        {
            Invoice invoice = new Invoice();
            invoice.ProductId = request.ProductId;
            invoice.MemberId =  request.MemberId;
            invoice.PaymentTypeId = request.PaymentTypeId;
            invoice.OrderDate = DateTime.Now;

            if (request.PaymentTypeId == PaymentType.Membership || request.PaymentTypeId == PaymentType.Upgrade)
                invoice.MemberId = _memberService.AddUpdateMember(request.MemberInfo, (request.PaymentTypeId == PaymentType.Upgrade ? false:true));
               
            invoice.ShippingId = _memberService.GetShippingInfoByMemberId(request.MemberId);

            //Create Transaction 
            //GetProductDetail(request.ProductId)
            // check if Product is LearningSki Video then add new transaction for the same ordernumber/invoice number 
            return invoice;
        }

        private String GeneratePackingSlip(OrderResponse response)
        {
            //Read the Packing Slip Template
            // Replace the tokens with actual data
            // generate Packing slip
            return "Thanks {Member} for the payment.";
        }

        private async Task<OrderResponse> Checkout(Invoice request)
        {

            if (request.PaymentTypeId == PaymentType.Product)
            {
                request.Commission = GetAgentCommission(request.ProductId);
            }

            //Hardcoding for now
            OrderResponse response = new OrderResponse()
            {
                OrderId = 1,
                OrderNo = "A001",
                IsSuccess = true
            };
            return response;
        }


       

        private double GetAgentCommission(int ProductId)
        {    
            var unitCost = _productService.GetProduct(ProductId).UnitPrice;
            return unitCost * 5 / 100;
        }

       
        private ValidationResult ValidateMemberRequest(Member request)
        {
             ValidationResult validationResult = new ValidationResult();
            validationResult.ErrorCode = ErrorCode.InvalidRequest;

            if (string.IsNullOrEmpty(request.Address1))
                validationResult.Message = "Primary Address is required.";

            else if (string.IsNullOrEmpty(request.Email))
                validationResult.Message = "Email is required.";

            else if (string.IsNullOrWhiteSpace(request.Phone))
                validationResult.Message = "Phone no is required.";
            else
            {
                validationResult.IsSuccess = true;
                validationResult.Message = "";
            }
            return validationResult;
        }

    }
}
