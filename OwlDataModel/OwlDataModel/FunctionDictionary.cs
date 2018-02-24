using OwlDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationFunctions
{
    public class FunctionDictionary : Dictionary<string, Func<object, Dictionary<string, object>, bool>>
    {
        public bool CheckFunctionExistsAndExecute(ValidationFunction FunctionToExecute,object ValueForFunction)
        {
            if (ContainsKey(FunctionToExecute.FunctionName))
                return ExecuteFunction(FunctionToExecute, ValueForFunction);
            return false;
        }

        private bool ExecuteFunction(ValidationFunction FunctionToExecute, object ValueForFunction)
        {
            return this[FunctionToExecute.FunctionName].Invoke(ValueForFunction, FunctionToExecute.OptionalParameter);
        } 
    }
}
