using System;
using System.Collections.Generic;

namespace OwlDataModel
{
    public class ModelDefinition
    {
        public string Name { get; set; }

        public List<ModelProperty> Properties { get; set; }

        public ModelDefinition()
        {
            Properties = new List<ModelProperty>();
        }
    }
}
