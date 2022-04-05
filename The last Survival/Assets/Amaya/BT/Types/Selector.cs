using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SIMILAR TO THE SELECTOR BUT IT'LL RETURN THE STATE IMMEDIATLY AFTER THE EVALUATION

namespace BehaviourTree
{
    public class Selector : Nodes
    {
        public Selector() : base() { }
        public Selector(List<Nodes> children) : base(children) { }

        public override NodesState Evaluate()
        {

            foreach (Nodes node in Children)
            {
                switch (node.Evaluate())
                {
                    case NodesState.FAILURE:
                        continue;

                    case NodesState.SUCCESS:
                        state = NodesState.SUCCESS;
                        return state;

                    case NodesState.RUNNING:
                        state = NodesState.RUNNING;
                        return state;

                    default:
                        continue;
                }
            }

            state = NodesState.FAILURE;
            return state;
        }

    }
}

