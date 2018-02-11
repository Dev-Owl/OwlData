using System;
using System.Collections.Generic;
using System.Text;

namespace OwlDataModel
{
    public class ValidationFunction
    {
        public string FunctionName { get; set; }

        public List<object> OptionalParameter { get; set; } = new List<object>();

        public float Score { get; set; }
    }
}
