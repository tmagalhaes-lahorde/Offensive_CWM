using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Sequence : Nodes
    {
        public Sequence() : base() { }
        public Sequence(List<Nodes> children) : base(children) { }

        public override NodesState Evaluate()
        {
            bool AnyChildIsRunning = false;

            foreach (Nodes node in Children)
            {
                switch (node.Evaluate())
                {
                    case NodesState.FAILURE:
                        state = NodesState.FAILURE;
                        return state;

                    case NodesState.SUCCESS:
                        continue;

                    case NodesState.RUNNING:
                        AnyChildIsRunning = true;
                        continue;

                    default:
                        state = NodesState.SUCCESS;
                        return state;
                }
            }

            state = AnyChildIsRunning ? NodesState.RUNNING : NodesState.SUCCESS;
            return state;
        }

    }
}
