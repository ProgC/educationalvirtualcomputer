using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalVirtualComputer
{
    class MemoryVariable
    {
        public enum VariableType
        {
            Int, 
            Float,
            String
        }
        
        public string name;
        public VariableType type = VariableType.Int;        
        public int intValue = 0;
        public float floatValue = 0.0f;
        public string stringValue = " ";
        
        public MemoryVariable(string inName, VariableType inType)
        {
            name = inName;
            type = inType;
        }
    }
}
