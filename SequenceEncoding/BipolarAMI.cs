using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SequenceEncoding
{
    public class BipolarAMI : Diagram, IDrawable
    {
        public void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram)
        {
            //TempX = 0;
            //TempY = 90;
            bool check = false;

            DrawAlongX(finishedDiagram, StepX);

            for(int i = 1; i < binaryCup.Count; i++)
            {
                if(binaryCup[i] == "0" && binaryCup[i - 1] == "0")
                {
                    DrawAlongX(finishedDiagram, StepX);
                }
                else if(binaryCup[i] == "0" && binaryCup[i - 1] == "1")
                {
                    if(check == false)
                    {
                        DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX);
                        check = true;
                    }else if(check == true)
                    {
                        DrawAlongY(finishedDiagram, StepY);
                        DrawAlongX(finishedDiagram, StepX);
                        check = false;
                    }
                    
                }
                else if(binaryCup[i] == "1" && binaryCup[i - 1] == "1")
                {
                    if (check == false)
                    {
                        DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                        DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX);
                        check = true;
                    }
                    else if (check == true)
                    {
                        DrawAlongY(finishedDiagram, StepY);
                        DrawAlongY(finishedDiagram, StepY);
                        DrawAlongX(finishedDiagram, StepX);
                        check = false;
                    }
                }
                else if(binaryCup[i] == "1" && binaryCup[i - 1] == "0")
                {
                    if (check == false)
                    {
                        DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX);
                        check = true;
                    }
                    else if (check == true)
                    {
                        DrawAlongY(finishedDiagram, StepY);
                        DrawAlongX(finishedDiagram, StepX);
                        check = false;
                    }
                }
            }
        }
    }
}
