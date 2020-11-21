using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace SequenceEncoding
{
    public class NotReturnToZero : Diagram, IDrawable
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
        public void DrawAlongMinusY(ObservableCollection<Item> insertInformation, int stepY)
        {
            insertInformation.Add(new Item
            {
                From = new System.Drawing.Point(TempX, TempY),
                To = new System.Drawing.Point(TempX, TempY -= stepY)

            });
        }
        public void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram)
        {
            TempX = 0;
            TempY = 100;

            DrawAlongX(finishedDiagram, StepX);

            for (int i = 1; i < binaryCup.Count; i++)
            {
                if (binaryCup[i] == "0" && binaryCup[i - 1] == "0")
                {
                    DrawAlongX(finishedDiagram, StepX);

                }
                else if (binaryCup[i] == "0" && binaryCup[i - 1] == "1")
                {
                    DrawAlongMinusY(finishedDiagram, StepY);
                    DrawAlongX(finishedDiagram, StepX);
                }
                else if (binaryCup[i] == "1" && binaryCup[i - 1] == "1")
                {
                    DrawAlongX(finishedDiagram, StepX);
                }
                else if (binaryCup[i] == "1" && binaryCup[i - 1] == "0")
                {
                    DrawAlongY(finishedDiagram, StepY);
                    DrawAlongX(finishedDiagram, StepX);
                }
            }
        }
    
    }
}
