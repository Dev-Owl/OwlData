using System;
using System.Collections.Generic;
using System.Text;

namespace OwlDataModel.DTO
{
    public class ModelPropertyDTO
    {
        public string Name { get; set; }

        public bool Required { get; set; } = false;

        public PropertyType Type { get; set; } = PropertyType.String;

        public List<ValidationFunction> ValidationFunctions { get; set; }
    }
}
