using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Graph;

namespace RoguelikeCreatorGui
{
    /// <summary>
    /// Interaction logic for ActionGraphNode.xaml
    /// </summary>
    public partial class ActionGraphNode : GraphNode
    {
        private Ellipse[] inPins;

        public ActionGraphNode(string methodName, string typeName, string assemblyName)
        {
            InitializeComponent();

            string fullname = assemblyName + "." + typeName+ ", " + assemblyName;
            Type type = Type.GetType(fullname);
            MethodInfo method = Type.GetType(fullname).GetMethod(methodName);
            SetNode(ActionNode.GetActionNode(method));

            Title.Text = methodName;
        }

        protected override Ellipse[] GetInPins()
        {
            return inPins;
        }

        protected override Ellipse[] GetOutPins()
        {
            return new Ellipse[] {ExecutionOut};
        }

        #region Event Handlers

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SetDragArea(Draggable);

            int numParams = ActionNode.NumParams();
            inPins = new Ellipse[numParams + 1];
            inPins[0] = ExecutionIn;
            
            for (int i = 0; i < numParams; i++)
            {
                inPins[i + 1] = GetParamPin();
            }
        }

        #endregion

        #region Helper

        private Ellipse GetParamPin()
        {
            Ellipse paramPin = new Ellipse();
            paramPin.Width = 15;
            paramPin.Height = 15;
            paramPin.Margin = new Thickness(0, 10, 0, 0);
            paramPin.Fill = Brushes.White;
            paramPin.Stroke = Brushes.Black;

            InputStack.Children.Add(paramPin);

            return paramPin;
        }

        private ActionNode ActionNode
        {
            get { return (ActionNode) Node; }
        }

        #endregion
    }
}
