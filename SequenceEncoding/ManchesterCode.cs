using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SequenceEncoding
{
    public class ManchesterCode : Diagram, IDrawable
    { 
        public void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram)
        {
            TempX = 0;
            TempY = 100;

            DrawAlongX(finishedDiagram, StepX - 4);
            DrawAlongY(finishedDiagram, StepY);
            DrawAlongX(finishedDiagram, StepX + 4);

            for(int i = 1; i < binaryCup.Count; i++)
            {
                if(binaryCup[i] == "0" && binaryCup[i - 1] == "0")
                {
                    DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                    DrawAlongX(finishedDiagram, StepX - 4);
                    DrawAlongY(finishedDiagram, StepY);
                    DrawAlongX(finishedDiagram, StepX + 4);
                }
                else if(binaryCup[i] == "1" && binaryCup[i - 1] == "1")
                {                
                    DrawAlongY(finishedDiagram, StepY);
                    DrawAlongX(finishedDiagram, StepX + 4);
                    DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                    DrawAlongX(finishedDiagram, StepX - 4);
                }
                else if(binaryCup[i] == "1" && binaryCup[i - 1] == "0")
                {
                    DrawAlongX(finishedDiagram, StepX - 4);
                    DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                    DrawAlongX(finishedDiagram, StepX + 4);
                }
                else if (binaryCup[i] == "0" && binaryCup[i - 1] == "1")
                {
                    DrawAlongX(finishedDiagram, StepX - 4);
                    DrawAlongY(finishedDiagram, StepY);
                    DrawAlongX(finishedDiagram, StepX + 4);
                }
            }
        }
    }
}
