using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BUILD THE TREE

namespace BehaviourTree
{
    public abstract class TreeBuild : MonoBehaviour
    {
        private Nodes _root = null;
        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate(); //search for a root, if there is one then it'll evaluate the entire tree constantly
        }

        protected abstract Nodes SetupTree();
    }
}
