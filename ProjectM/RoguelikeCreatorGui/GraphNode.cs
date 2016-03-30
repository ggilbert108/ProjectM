using System;
using System.Windows.Controls;
using System.Windows.Shapes;
using Graph;

namespace RoguelikeCreatorGui
{
    public abstract class GraphNode : Draggable
    {
        protected INode Node;
        public event EventHandler<Pin> InPinClicked;
        public event EventHandler<Pin> OutPinClicked;

        protected GraphNode()
        {
        }

        protected void SetNode(INode node)
        {
            this.Node = node;
        }

        protected void WirePins()
        {
            Ellipse[] inPins = GetInPins();
            for (int i = 0; i < inPins.Length; i++)
            {
                int index = i; //because i changes, and the closure would use the changed value
                inPins[i].MouseDown += (sender, args) =>
                {
                    InPinClicked?.Invoke(this, Node.GetInPins()[index]);
                };
            }

            Ellipse[] outPins = GetOutPins();
            for (int i = 0; i < outPins.Length; i++)
            {
                int index = i;
                outPins[i].MouseDown += (sender, args) =>
                {
                    OutPinClicked?.Invoke(this, Node.GetOutPins()[index]);
                };
            }
        }

        protected abstract Ellipse[] GetInPins();
        protected abstract Ellipse[] GetOutPins();
    }
}