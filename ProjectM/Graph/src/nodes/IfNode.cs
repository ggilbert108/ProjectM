namespace Graph
{
    public class IfNode : INode
    {
        private ExecutionPin executionIn;
        private ExecutionPin executionTrueOut;
        private ExecutionPin executionFalseOut;
        private DataPin<bool> conditionIn;

        public IfNode()
        {
            executionIn = new ExecutionPin(this, true);
            conditionIn = new DataPin<bool>(this, true);

            executionTrueOut = new ExecutionPin(this, false);
            executionFalseOut = new ExecutionPin(this, false);
        }

        public void PrepareToExecute()
        {
            conditionIn.Recieve();
        }

        public void Execute()
        {
            if (conditionIn.Data)
            {
                executionTrueOut.Send();
            }
            else
            {
                executionFalseOut.Send();
            }
        }

        public Pin[] GetInPins()
        {
            return new Pin[] {executionIn, conditionIn};
        }

        public Pin[] GetOutPins()
        {
            return new Pin[] {executionTrueOut, executionFalseOut};
        }
    }
}