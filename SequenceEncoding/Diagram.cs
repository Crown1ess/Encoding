using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SequenceEncoding
{
    public abstract class Diagram
    {
        //think about this 2 properties:
        public int TempX { get; set; }
        public int TempY { get; set; }
        public int StepX { get; set; } = 10;
        public int StepY { get; set; } = 10;
        public int VariableChangesToNegative = -1;
    }
    
}
