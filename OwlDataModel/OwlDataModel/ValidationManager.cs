using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationFunctions
{
    public class ValidationManager
    {
        private static ValidationManager SharedValidationManager = null;

        public FunctionDictionary KnownFunctions { get; }
        
        public static ValidationManager GetActiveValidationManager()
        {
            if (SharedValidationManager == null)
            {
                SharedValidationManager = new ValidationManager();
                new BuildInValidation().RegisterFunctions(SharedValidationManager);
            }
            return SharedValidationManager;
        }

        public ValidationManager()
        {
            KnownFunctions =  new FunctionDictionary();
        }

        public void Add(string Name, Func<Dictionary<string, object>, string, Dictionary<string, Object>, bool> Function)
        {
            if (!KnownFunctions.ContainsKey(Name))
                KnownFunctions.Add(Name, Function);
            else
                KnownFunctions[Name] = Function;
        }

    }
}
