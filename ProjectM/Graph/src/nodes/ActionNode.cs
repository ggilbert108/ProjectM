using System;
using System.Linq;
using System.Reflection;

namespace Graph
{
    public class ActionNode : INode
    {
        protected ExecutionPin ExecutionIn;
        protected ExecutionPin ExecutionOut;

        private Action function;

        public ActionNode(Action function)
        {
            this.function = function;
        }

        public ActionNode()
        {
            
        }

        public virtual void PrepareToExecute()
        {
            
        }

        public virtual void Execute()
        {
            function();
        }

        public virtual int NumParams()
        {
            return 0;
        }

        public static ActionNode GetActionNode(MethodInfo methodInfo, object owner = null)
        {
            var parameters = methodInfo.GetParameters();
            var paramTypes = (
                from param in parameters
                select param.ParameterType).ToArray();

            if (parameters.Length == 0)
            {
                return GetAction(methodInfo, owner);
            }

            string methodName = "GetAction" + parameters.Length;
            MethodInfo method = typeof (ActionNode).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo generic = method.MakeGenericMethod(paramTypes);

            return (ActionNode) generic.Invoke(null, new object[] {methodInfo, owner});
        }

        public virtual Pin[] GetInPins()
        {
            return new Pin[] {ExecutionIn};
        }

        public Pin[] GetOutPins()
        {
            return new Pin[] {ExecutionOut};
        }

        #region Get Action

        private static ActionNode GetAction(MethodInfo methodInfo, object owner)
        {
            Action action;
            if (owner == null)
            {
                action = (Action)Delegate.CreateDelegate(typeof(Action), methodInfo);
            }
            else
            {
                action = (Action)Delegate.CreateDelegate(typeof(Action), owner, methodInfo);
            }
            return new ActionNode(action);
        }

        private static ActionNode GetAction1<T1>(MethodInfo methodInfo, object owner)
        {
            Action<T1> action;
            if (owner == null)
            {
                action = (Action<T1>)Delegate.CreateDelegate(typeof(Action<T1>), methodInfo);
            }
            else
            {
                action = (Action<T1>) Delegate.CreateDelegate(typeof (Action<T1>), owner, methodInfo);
            }
            return new ActionNode<T1>(action);
        }

        private static ActionNode GetAction2<T1, T2>(MethodInfo methodInfo, object owner)
        {
            Action<T1, T2> action;
            if (owner == null)
            {
                action = (Action<T1, T2>) Delegate.CreateDelegate(typeof (Action<T1, T2>), methodInfo);
            }
            else
            {
                action = (Action<T1, T2>)Delegate.CreateDelegate(typeof(Action<T1, T2>), owner, methodInfo);
            }
            return new ActionNode<T1, T2>(action);
        }
        
        #endregion
    }

    #region Generic Variants

    public class ActionNode<T1> :  ActionNode
    {
        protected DataPin<T1> DataIn1;
        protected T1 Data1;

        private Action<T1> function;
        
        public ActionNode(Action<T1> function)
        {
            DataIn1 = new DataPin<T1>(this, true);
            this.function = function;
        }

        public ActionNode(){}

        public override void PrepareToExecute()
        {
            DataIn1.Recieve();
            Data1 = DataIn1.Data;
        }

        public override void Execute()
        {
            function(Data1);
        }

        public override int NumParams()
        {
            return 1;
        }

        public override Pin[] GetInPins()
        {
            return new Pin[] {ExecutionIn, DataIn1};
        }
    }

    public class ActionNode<T1, T2> : ActionNode<T1>
    {
        protected DataPin<T2> DataIn2;
        protected T2 Data2;

        private Action<T1, T2> function;

        public ActionNode(Action<T1, T2> function) : base(null)
        {
            DataIn2 = new DataPin<T2>(this, true);
            this.function = function;
        }

        public ActionNode(){}

        public override void PrepareToExecute()
        {
            base.PrepareToExecute();
            DataIn2.Recieve();
            Data2 = DataIn2.Data;
        }

        public override void Execute()
        {
            function(Data1, Data2);
        }

        public override int NumParams()
        {
            return 2;
        }

        public override Pin[] GetInPins()
        {
            return new Pin[] {ExecutionIn, DataIn1, DataIn2};
        }
    }

    #endregion
}