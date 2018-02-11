using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationFunctions
{
    public class ValidationManager
    {
        public Dictionary<string,Func<dynamic,string,Dictionary<string,object>, bool>> KnownFunctions { get; }
        
        public ValidationManager()
        {
            KnownFunctions = new Dictionary<string, Func<dynamic, string, Dictionary<string,object>, bool>>();
        }

        public void Add(string Name, Func<dynamic, string, Dictionary<string, Object>, bool> Function)
        {
            if (!KnownFunctions.ContainsKey(Name))
                KnownFunctions.Add(Name, Function);
            else
                KnownFunctions[Name] = Function;
        }
    }
}
