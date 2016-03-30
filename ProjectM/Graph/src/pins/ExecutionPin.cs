namespace Graph
{
    public class ExecutionPin : Pin
    {
        public ExecutionPin(INode owner, bool isInput) : base(owner, isInput)
        {

        }

        public override void Send()
        {
            if (Connected == null) return;
            if (IsInput) return;

            Connected.Owner.PrepareToExecute();
            Connected.Owner.Execute();
        }
    }
}