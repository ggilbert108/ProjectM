namespace Graph
{
    public class DataPin<T> : Pin
    {
        public T Data { get; private set; }

        public DataPin(INode owner, bool isInput) : base(owner, isInput)
        {

        }

        public override void Send()
        {
            if (Connected == null) return;
            if (IsInput) return;

            DataPin<T> connected = Connected as DataPin<T>;
            connected.Data = Data;
        }

        public void Recieve()
        {
            if (Connected == null) return;
            if (IsOutput) return;

            Connected.Send();
        }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}