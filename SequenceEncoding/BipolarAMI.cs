using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SequenceEncoding
{
    public class BipolarAMI : Diagram, IDrawable
    {
        public void DrawAlongX(ObservableCollection<Item> insertInformation, int stepX)
        {
            insertInformation.Add(new Item
            {
                From = new System.Drawing.Point(TempX, TempY),
                To = new System.Drawing.Point(TempX += stepX, TempY)

            });
        }

        public void DrawAlongY(ObservableCollection<Item> insertInformation, int stepY)
        {
            insertInformation.Add(new Item
            {
                From = new System.Drawing.Point(TempX, TempY),
                To = new System.Drawing.Point(TempX, TempY += stepY)

            });
        }

        public void DrawAlongY(ObservableCollection<Item> insertInformation, int stepY, int variableChangesToNegative)
        {
            insertInformation.Add(new Item
            {
                From = new System.Drawing.Point(TempX, TempY),
                To = new System.Drawing.Point(TempX, TempY += (stepY * variableChangesToNegative))

            });
        }

        public void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram)
        {
            TempX = 0;
            TempY = 100;
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
