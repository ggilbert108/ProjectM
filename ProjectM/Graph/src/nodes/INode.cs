using System.Collections.Generic;

namespace Graph
{
    public interface INode
    {
        void PrepareToExecute();
        void Execute();

        Pin[] GetInPins();
        Pin[] GetOutPins();
    }
}