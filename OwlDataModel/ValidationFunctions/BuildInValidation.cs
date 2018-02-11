using System;
using System.Collections.Generic;

namespace ValidationFunctions
{
    public class BuildInValidation : ValidationBase
    {
        public bool NullOrEmpty(dynamic Entity, string Property, Dictionary<string,Object> Addtional)
        {
            if(Object.ReferenceEquals(null, Entity))
            {
                return string.IsNullOrEmpty(Entity[Property]);
            }
            return false;
        }

        public bool NotNullOrEmpty(dynamic Entity, string Property, Dictionary<string, Object> Addtional)
        {
            if (Entity != null)
            {
                return !string.IsNullOrEmpty(Entity[Property]);
            }
            return false;
        }

        public bool MinLength(dynamic Entity, string Property, Dictionary<string, Object> Addtional)
        {
            if(Entity != null)
            {
                var value = Entity[Property];
                int length = 0;
                if(Addtional != null)
                {
                    if(Addtional.ContainsKey("length"))
                    {
                        length = Convert.ToInt32(Addtional["length"]);
                    }
                }
                return Convert.ToString(value).Length >= length;
            }
            return false;
        }

        public override void RegisterFunctions(ValidationManager ValidationManager)
        {
            ValidationManager.Add("NullOrEmpty", NullOrEmpty);
            ValidationManager.Add("NotNullOrEmpty", NotNullOrEmpty);
            ValidationManager.Add("MinLength", MinLength);
        }
    }
}
