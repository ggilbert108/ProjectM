using System;

namespace Graph
{
    public abstract class Pin
    {
        public readonly INode Owner;
        public readonly bool IsInput;
        protected Pin Connected;

        protected Pin(INode owner, bool isInput)
        {
            Owner = owner;
            IsInput = isInput;
        }

        public void ConnectPins(Pin other)
        {
            if (other.IsInput == IsInput)
            {
                throw new Exception("Two pins that are both inputs or both outputs cannot be connected");
            }

            if (GetType() != other.GetType())
            {
                throw new Exception("Pins must be of the same type");
            }

            Connected = other;
            other.Connected = this;
        }

        public abstract void Send();

        public bool IsOutput
        {
            get { return !IsInput; }
        }
    }
}