using System;
using System.Collections.Generic;

namespace OwlDataModel
{
    public class DecimalProperty : ModelProperty
    {
        public DecimalProperty(ModelDefinition ParentModel) : base(ParentModel)
        {
        }

        public override bool RequiredPropertyHasAValue()
        {
            try
            {
                decimal convertedValue = Convert.ToDecimal(this.ParentModel.Entity[this.Name]);
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
