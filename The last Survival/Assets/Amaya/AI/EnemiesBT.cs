using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class EnemiesBT : TreeBuild
{
    public Transform User;
    public Animator Animator;
    protected override Nodes SetupTree()
    {
        Nodes root = new Selector(new List<Nodes>
        {
            new GoToZone(User,Animator),
            new Sequence(new List<Nodes>
            {
                new Explore(User,Animator),
                new Selector(new List<Nodes>
                {
                    new Sequence(new List<Nodes>
                    {
                        new FieldOfView(User,Animator),
                        new Selector(new List<Nodes>
                        {
                            new Sequence (new List<Nodes>
                            {
                                new RandBehaviour(User,Animator),
                                new AttackTarget(User,Animator),
                            }),
                            new FleeTarget(User,Animator),
                        }),
                    }),
                    new SearchItems(User,Animator),
                }),
            }),

        }) ;

        return root;
    }
}
