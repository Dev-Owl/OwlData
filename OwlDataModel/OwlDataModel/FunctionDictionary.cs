using OwlDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationFunctions
{
    public class FunctionDictionary : Dictionary<string,Func<Dictionary<string, object>,string, Dictionary<string, object>, bool>>
    {
        public bool CheckFunctionExistsAndExecute(ValidationFunction FunctionToExecute, Dictionary<string, object> Entity, string PropertyName)
        {
            if (ContainsKey(FunctionToExecute.FunctionName))
                return ExecuteFunction(FunctionToExecute, Entity, PropertyName);
            return false;
        }

        private bool ExecuteFunction(ValidationFunction FunctionToExecute, Dictionary<string, object> Entity, string PropertyName)
        {
            return this[FunctionToExecute.FunctionName].Invoke(Entity, PropertyName, FunctionToExecute.OptionalParameter);
        } 
    }
}
