using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for GraphIfNode.xaml
    /// </summary>
    public partial class IfGraphNode : GraphNode
    {
        public IfGraphNode() : base()
        {
            InitializeComponent();
            SetNode(new IfNode());
        }

        protected override Ellipse[] GetInPins()
        {
            return new Ellipse[] {ExecutionIn, ConditionIn};
        }

        protected override Ellipse[] GetOutPins()
        {
            return new Ellipse[] {ExecutionTrueOut, ExecutionFalseOut};
        }

        #region Event Handlers

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SetDragArea(Draggable);
            WirePins();
        }
        
        #endregion
    }
}
