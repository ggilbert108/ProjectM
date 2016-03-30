namespace Graph
{
    public class GetNode<T> : INode
    {
        private DataPin<T> dataOut;
        
        public GetNode(Scope scope, string key)
        {
            dataOut = new DataPin<T>(this, false);

            T data = (T)(scope.Get(key));
            dataOut.SetData(data);
        }

        public void PrepareToExecute()
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public Pin[] GetInPins()
        {
            return new Pin[0];
        }

        public Pin[] GetOutPins()
        {
            return new Pin[] {dataOut};
        }
    }
}