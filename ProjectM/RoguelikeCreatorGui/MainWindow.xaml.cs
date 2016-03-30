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

namespace RoguelikeCreatorGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void CreateIfNode(object sender, RoutedEventArgs e)
        {
            var mousePosition = Mouse.GetPosition(MyCanvas);
            IfGraphNode graphNode = new IfGraphNode();
            MyCanvas.Children.Add(graphNode);
            SetNodeLoaded(graphNode);
        }

        private void CreateAddNode(object sender, RoutedEventArgs e)
        {
            ActionGraphNode graphNode = new ActionGraphNode("Add", "MMath", "MLibrary");
            MyCanvas.Children.Add(graphNode);
            SetNodeLoaded(graphNode);
        }

        #endregion

        private void SetNodeLoaded(GraphNode node)
        {
            node.Loaded += (o, args) =>
            {
                node.SetCanvas(MyCanvas);
            };
        }
    }
}
