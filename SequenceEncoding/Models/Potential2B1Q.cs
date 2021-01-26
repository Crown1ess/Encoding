using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SequenceEncoding
{
    public class Potential2B1Q : Diagram, IDrawable
    {
        public void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram)
        {
            TempX = 0;
            //definition of entry level
            if (binaryCup[1] == "0" && binaryCup[0] == "0")
            {
                TempY = 130;
                DrawAlongX(finishedDiagram, (StepX - 2) * 4);
            }
            else if (binaryCup[1] == "0" && binaryCup[0] == "1")
            {
                TempY = 90;
                DrawAlongX(finishedDiagram, (StepX - 2) * 4);
            }
            else if (binaryCup[1] == "1" && binaryCup[0] == "0")
            {
                TempY = 115;
                DrawAlongX(finishedDiagram, (StepX - 2) * 4);
            }
            else if (binaryCup[1] == "1" && binaryCup[0] == "1")
            {
                TempY = 105;
                DrawAlongX(finishedDiagram, (StepX - 2) * 4);
            }
            //drawing diagram
            for(int i = 3; i < binaryCup.Count; i += 2)
            {
                if (binaryCup[i] == "0" && binaryCup[i - 1] == "0")
                {
                    if(TempY == 130)
                    { 
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }else if(TempY == 115)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }else if(TempY == 105)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if(TempY == 90)
                    {
                        DrawAlongY(finishedDiagram, StepY * 2);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    
                }
                else if (binaryCup[i] == "1" && binaryCup[i - 1] == "1")
                {
                    if (TempY == 115)
                    {
                        DrawAlongY(finishedDiagram, StepY - 10, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 130)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 105)
                    {
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 90)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }  
                }
                else if (binaryCup[i] == "1" && binaryCup[i - 1] == "0")
                {
                    if (TempY == 115)
                    {
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 130)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 105)
                    {
                        DrawAlongY(finishedDiagram, StepY - 10);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 90)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                }
                else if (binaryCup[i] == "0" && binaryCup[i - 1] == "1")
                {
                    if (TempY == 115)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 130)
                    {
                        DrawAlongY(finishedDiagram, StepY * 2, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 105)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 90)
                    {
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                }
            }
        }
    }
}
