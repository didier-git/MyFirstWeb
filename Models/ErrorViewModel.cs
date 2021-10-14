using System;

namespace MyFirstWeb.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public bool ShowRequestIdV2() {

            return !string.IsNullOrEmpty(RequestId);
        
        }
    }
}
