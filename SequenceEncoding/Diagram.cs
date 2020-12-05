using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SequenceEncoding
{
    public abstract class Diagram
    {
        public int TempX { get; set; } = 0;
        public int TempY { get; set; } = 110;

        public int StepX = 10;
        public int StepY = 20;

        public const int VariableChangesToNegative = -1;

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
    }
    
}
