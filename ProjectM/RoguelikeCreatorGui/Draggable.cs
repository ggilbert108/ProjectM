using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace RoguelikeCreatorGui
{
    public abstract class Draggable : UserControl
    {
        private Canvas canvas;
        private Rectangle dragArea;

        private Point grabPoint;

        protected Draggable()
        {
            grabPoint = new Point(-1, -1);
            dragArea = null;
        }

        protected void SetDragArea(Rectangle area)
        {
            dragArea = area;
            dragArea.MouseDown += DragAreaOnMouseDown;
            canvas.MouseMove += DragAreaOnMouseMove;
            canvas.MouseUp += DragAreaOnMouseUp;
        }

        public void SetCanvas(Canvas canvas)
        {
            this.canvas = canvas;
        }

        #region Event Handlers

        protected void DragAreaOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            grabPoint = e.GetPosition(this);
        }

        protected void DragAreaOnMouseMove(object sender, MouseEventArgs e)
        {
            if (Math.Abs(grabPoint.X - (-1)) < 0.01 && Math.Abs(grabPoint.Y - (-1)) < 0.01)
                return;

            var canvasPoint = e.GetPosition(canvas);
            var setPoint = canvasPoint - grabPoint;

            SetCurrentValue(Canvas.TopProperty, setPoint.Y);
            SetCurrentValue(Canvas.LeftProperty, setPoint.X);
        }

        private void DragAreaOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            grabPoint = new Point(-1, -1);
        }

        #endregion
    }
}