using System.Collections.Generic;

namespace Graph
{
    public class Scope
    {
        private Dictionary<string, object> values;
        private Scope childScope;

        public Scope()
        {
            values = new Dictionary<string, object>();
            childScope = null;
        }

        public void Set(string key, object value)
        {
            if (values.ContainsKey(key))
            {
                values[key] = value;
            }
            else
            {
                childScope?.Set(key, value);
            }
        }

        public object Get(string key)
        {
            return values.ContainsKey(key) ? values[key] : childScope?.Get(key);
        }

        public void SetChildScope(Scope child)
        {
            childScope = child;
        }
    }
}