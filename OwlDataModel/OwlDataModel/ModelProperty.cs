using System;
using System.Collections.Generic;
using System.Text;

namespace OwlDataModel
{
    public enum PropertyType
    {
        String  = 0,
        Int     = 1,
        Deciaml = 2,
        Bool    = 3,
        Object  = 4,
        Any     = 5
    }

    public class ModelProperty
    {
        public string Name { get; set; }

        public bool Required { get; set; } = false;

        public PropertyType Type { get; set; } = PropertyType.Any;

        public List<ValidationFunction> ValidationFunctions { get; set; }

        public float Score { get; set; }

    }
}
