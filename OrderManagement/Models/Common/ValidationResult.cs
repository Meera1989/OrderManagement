using System;
namespace OrderManagement.Models.Common
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}
