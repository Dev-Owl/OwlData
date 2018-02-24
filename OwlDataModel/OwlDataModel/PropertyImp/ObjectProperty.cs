using System;
using System.Collections.Generic;

namespace OwlDataModel
{
    public class ObjectProperty : ModelProperty
    {
        public ObjectProperty(ModelDefinition ParentModel) : base(ParentModel)
        {
        }

        public override bool RequiredPropertyHasAValue()
        {
            try
            {
                object convertedValue = this.ParentModel.Entity[this.Name] as object;
                return convertedValue != null;
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
