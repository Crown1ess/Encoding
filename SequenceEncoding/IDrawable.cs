using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SequenceEncoding
{
    public interface IDrawable
    {
        public abstract void DrawAlongX(ObservableCollection<Item> insertInformation, int stepX);
        public abstract void DrawAlongY(ObservableCollection<Item> insertInformation, int stepY);
        public abstract void DrawAlongY(ObservableCollection<Item> insertInformation, int stepY, int variableChangesToNegative);
        public abstract void DrawDiagram(List<string> binaryCup, ObservableCollection<Item> finishedDiagram);
    }
}
