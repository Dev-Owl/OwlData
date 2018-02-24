using System;
using System.Collections.Generic;

namespace OwlDataModel
{
    public class BoolProperty : ModelProperty
    {
        public BoolProperty(ModelDefinition ParentModel) : base(ParentModel)
        {
        }

        public override bool RequiredPropertyHasAValue()
        {
            try
            {
                bool convertedValue = Convert.ToBoolean(this.ParentModel.Entity[this.Name]);
                return true;
            }
            catch (KeyNotFoundException Ex)
            {

            }
            catch (InvalidCastException Ex)
            {

            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }
    }
}
