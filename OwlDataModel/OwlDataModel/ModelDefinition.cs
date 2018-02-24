using OwlDataModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OwlDataModel
{
    public class ModelDefinition
    {
        public string Name { get; set; }

        public PropertyList Properties { get; set; }

        public Dictionary<string,object> Entity { get; set; }

        public ModelDefinition()
        {
            Properties = new PropertyList();
        }

        public void ResetScoreAndLoadNewEntity(Dictionary<string, object> NewEntity)
        {
            ResetScoreValues();
            Entity = NewEntity;
        }

        private void ResetScoreValues()
        {
            Properties.ResetScores();
        }

        public void CreateModelPropertyList(List<ModelPropertyDTO> PropertyDTOList)
        {
            foreach (var PropertyDTO in PropertyDTOList)
            {
                ModelProperty newProperty = null;
                #region Generate property object based on type
                switch (PropertyDTO.Type)
                {
                    case PropertyType.Bool:
                        newProperty = new BoolProperty(this);
                        break;
                    case PropertyType.Deciaml:
                        newProperty = new DecimalProperty(this);
                        break;
                    case PropertyType.Int:
                        newProperty = new IntProperty(this);
                        break;
                    case PropertyType.Object:
                        newProperty = new ObjectProperty(this);
                        break;
                    case PropertyType.String:
                        newProperty = new StringProperty(this);
                        break;
                }
                #endregion
                newProperty.Name = PropertyDTO.Name;
                newProperty.Required = PropertyDTO.Required;
                newProperty.Type = PropertyDTO.Type;
                if(PropertyDTO.ValidationFunctions != null)
                newProperty.ValidationFunctions = PropertyDTO.ValidationFunctions;
                Properties.Add(newProperty);
            }
        }
    }
}
