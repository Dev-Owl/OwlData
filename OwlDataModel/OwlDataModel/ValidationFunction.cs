using System;
using System.Collections.Generic;
using System.Text;

namespace OwlDataModel
{
    public class ValidationFunction
    {
        public string FunctionName { get; set; }

        public Dictionary<string, object> OptionalParameter { get; set; } = new Dictionary<string, object>();

        public float Score { get; set; }

    }
}
