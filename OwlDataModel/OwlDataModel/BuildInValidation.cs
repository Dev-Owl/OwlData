using System;
using System.Collections.Generic;

namespace ValidationFunctions
{
    public class BuildInValidation : ValidationBase
    {

        public const string LENGTH = "length";

        public bool MinLength(object Value, Dictionary<string, Object> Addtional)
        {
            if(Value is null)
                return false;
            if(Value is string)
                return Value.ToString().Length >= Convert.ToInt64(Addtional[LENGTH]);
            return false;
        }

        public bool MaxLength(object Value, Dictionary<string, Object> Addtional)
        {
            if (Value is null)
                return true;
            if (Value is string)
                return Value.ToString().Length <= Convert.ToInt64(Addtional[LENGTH]);
            return false;
        }

        public override void RegisterFunctions(ValidationManager ValidationManager)
        {
            ValidationManager.Add("MinLength", MinLength);
            ValidationManager.Add("MaxLength", MaxLength);
        }
    }
}
