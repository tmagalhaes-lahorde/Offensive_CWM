using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public enum NodesState
    {
        RUNNING,
        SUCCESS,
        FAILURE

    }
    public class Nodes
    {
        protected NodesState state;

        public Nodes Parents;
        protected List<Nodes> Children = new List<Nodes>();

        public Nodes()
        {
            Parents = null;
        }

        public Nodes(List<Nodes> children)
        {
            foreach (Nodes child in children)
                _Attach(child);
        }

        private void _Attach(Nodes node)
        {
            node.Parents = this;
            Children.Add(node);
        }

        public virtual NodesState Evaluate() => NodesState.FAILURE;

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();
        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }


        public object GetData(string key)
        {
            object value = null;

            if (_dataContext.TryGetValue(key, out value))
                return value;

            Nodes node = Parents;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                    return value;

                node = node.Parents;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Nodes node = Parents;
            while (node != null)
            {
                bool cleared = node.ClearData(key);

                if (cleared)
                    return true;

                node = node.Parents;
            }
            return false;
        }
    }
}
