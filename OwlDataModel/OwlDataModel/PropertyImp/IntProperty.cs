using System;
using System.Collections.Generic;

namespace OwlDataModel
{
    public class IntProperty : ModelProperty
    {
        public IntProperty(ModelDefinition ParentModel) : base(ParentModel)
        {
        }

        public override bool RequiredPropertyHasAValue()
        {
            try
            {
                Int64 convertedValue = Convert.ToInt64(this.ParentModel.Entity[this.Name]);
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
