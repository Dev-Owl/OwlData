using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ValidationFunctions;

namespace OwlDataModel
{
    public class PropertyList : List<ModelProperty>
    {
        public float CalculateTotalScore()
        {
            return this.Average(property => property.Score);
        }

        public bool CheckAllRequiredPropertiesExists()
        {
            return this.Where(property => property.Required).All(requiredProperty => requiredProperty.RequiredPropertyHasAValue());
        }

        public void GenerateScoreForProperties()
        {
            this.ForEach(property => property.CalculateScore());
        }

        public void ResetScores()
        {
            this.ForEach(property => property.ResetPropertyScore());
        }
    }
}
