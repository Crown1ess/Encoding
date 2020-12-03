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
            TempY = 105;

            DrawAlongX(finishedDiagram, StepX * 4);

            //определенные точки надо сделать, чтобы они по игреку перемещались только до нужной точки
            //надо еще добавить проверку скольки был равен предыдущий tempY
            //разделение по x делаем по 20, а по Y - 5
            for(int i = 2; i < binaryCup.Count; i += 2)
            {
                if (binaryCup[i] == "0" && binaryCup[i - 1] == "0")
                {
                    if(TempY == 105)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }else if(TempY == 110)
                    {
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }else if(TempY == 95)
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
                    if (TempY == 105)
                    {
                        DrawAlongY(finishedDiagram, StepY, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 110)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 95)
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
                    if (TempY == 105)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 110)
                    {
                        DrawAlongY(finishedDiagram, StepY * 2, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 95)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 90)
                    {
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                }
                else if (binaryCup[i] == "0" && binaryCup[i - 1] == "1")
                {
                    if (TempY == 105)
                    {
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 110)
                    {
                        DrawAlongY(finishedDiagram, StepY - 5, VariableChangesToNegative);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 95)
                    {
                        DrawAlongY(finishedDiagram, StepY);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                    else if (TempY == 90)
                    {
                        DrawAlongY(finishedDiagram, StepY + 5);
                        DrawAlongX(finishedDiagram, StepX * 4);
                    }
                }
            }
        }
    }
}
