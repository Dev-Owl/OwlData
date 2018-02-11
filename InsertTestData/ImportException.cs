using System;
using System.Collections.Generic;
using System.Text;

namespace OwlData
{
    public class ImportException : Exception
    {
        public ImportException(string Message):base( Message)
        {

        }
    }
}
