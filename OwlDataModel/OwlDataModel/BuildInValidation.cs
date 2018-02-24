using System;
using System.Collections.Generic;

namespace ValidationFunctions
{
    public class BuildInValidation : ValidationBase
    {

        public const string LENGTH = "length";

        public bool MinLength(Dictionary<string,object> Entity,string Propertey, Dictionary<string, Object> Addtional)
        {
            if (!Entity.ContainsKey(Propertey))
                return false;
            if (Entity[Propertey] is null)
                return false;
            if(Entity[Propertey] is string)
                return Entity[Propertey].ToString().Length >= Convert.ToInt64(Addtional[LENGTH]);
            return false;
        }

        public bool MaxLength(Dictionary<string, object> Entity,string Propertey, Dictionary<string, Object> Addtional)
        {
            if (!Entity.ContainsKey(Propertey))
                return false;
            if (Entity[Propertey] is null)
                return true;
            if (Entity[Propertey] is string)
                return Entity[Propertey].ToString().Length <= Convert.ToInt64(Addtional[LENGTH]);
            return false;
        }

        public override void RegisterFunctions(ValidationManager ValidationManager)
        {
            ValidationManager.Add("MinLength", MinLength);
            ValidationManager.Add("MaxLength", MaxLength);
        }
    }
}
