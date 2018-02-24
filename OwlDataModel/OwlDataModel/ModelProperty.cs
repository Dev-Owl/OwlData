using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidationFunctions;
using System.Linq;

namespace OwlDataModel
{
    public enum PropertyType
    {
        String  = 0,
        Int     = 1,
        Deciaml = 2,
        Bool    = 3,
        Object  = 4,
    }

    public abstract class ModelProperty
    {
        public string Name { get; set; }

        public bool Required { get; set; } = false;

        public PropertyType Type { get; set; } = PropertyType.String;

        public List<ValidationFunction> ValidationFunctions { get; set; }

        public float Score { get; internal set; }

        internal ModelDefinition ParentModel;

        public ModelProperty(ModelDefinition ParentModel)
        {
            this.ParentModel = ParentModel;
            ValidationFunctions = new List<ValidationFunction>();
        }

        public void ResetPropertyScore()
        {
            this.Score = 0F;
        }

        public void CalculateScore()
        {
            try
            {
                var validationManager = ValidationManager.GetActiveValidationManager();
                var propertyValue = ParentModel.Entity[Name];
                List<float> validationScoreList = new List<float>();
                Parallel.For(0, ValidationFunctions.Count, index =>
                 {
                     var currentFunction = ValidationFunctions[index];
                     if (validationManager.KnownFunctions.CheckFunctionExistsAndExecute(currentFunction, propertyValue))
                         validationScoreList.Add(currentFunction.Score);
                     else
                         validationScoreList.Add(0F);
                 });
                Score = validationScoreList.Average();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public abstract bool RequiredPropertyHasAValue();
    }
}
