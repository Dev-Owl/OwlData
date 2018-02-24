using System;
using System.Collections.Generic;
using System.Text;

namespace OwlDataModel
{
    public class StringProperty : ModelProperty
    {
        public StringProperty(ModelDefinition ParentModel) : base(ParentModel)
        {
        }

        public override bool RequiredPropertyHasAValue()
        {
            try
            {
                var convertedValue = Convert.ToString(this.ParentModel.Entity[this.Name]);
                return !string.IsNullOrEmpty(convertedValue);
            }
            catch(KeyNotFoundException Ex)
            {

            }
            catch (InvalidCastException Ex)
            {

            }
            catch (Exception Ex)
            {
                throw;
            }
            return false;
        }
    }
}
