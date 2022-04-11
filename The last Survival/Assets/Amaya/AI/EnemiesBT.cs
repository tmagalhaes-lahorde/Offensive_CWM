using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class EnemiesBT : TreeBuild
{
    public Transform User;
    public Animator Animator;
    public NavMeshAgent Agent;
    public static float fovRange = 20f;
    public static int NbAmmo = 50;

    protected override Nodes SetupTree()
    {
        Nodes root = new Selector(new List<Nodes>
        {
            //new GoToZone(User,Animator),
            //new Sequence(new List<Nodes>
            //{
                //new Explore(User,Animator),
               // new Selector(new List<Nodes>
               //{
                    new Sequence(new List<Nodes>
                    {
                        new FieldOfView(User,Animator),
                        new Selector(new List<Nodes>
                        {
                            new Sequence (new List<Nodes>
                            {
                                new RandBehaviour(),
                                new AttackTarget(User,Animator),
                            }),
                            new FleeTarget(User,Animator,Agent),
                        }),
                    //}),
                   // new SearchItems(User,Animator),
                //}),
            }),

        }) ;

        return root;
    }
}
