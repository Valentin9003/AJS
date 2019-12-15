using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJS.Web.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ErrorMessage { get; set; }

        public string InformationMessage { get; set; }
        public override string ToString()
        {
            return $"{StatusCode} {StatusMessage}" + Environment.NewLine
                 + $"{ErrorMessage}" + Environment.NewLine +
                   $"{InformationMessage}";
        }
    }
}