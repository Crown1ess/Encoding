using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SequenceEncoding
{
    public interface IDrawable
    {
        public void DrawAlongX(ObservableCollection<Item> insertInformation, int stepX);
        public void DrawAlongY(ObservableCollection<Item> insertInformation, int stepY);
        public void DrawAlongY(ObservableCollection<Item> insertInformation, int stepY, int variableChangesToNegative);
        public void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram);
    }
}
