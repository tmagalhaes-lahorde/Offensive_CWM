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
            new GoToZone(User,Animator, Agent),

            new Sequence(new List<Nodes>
            {
               new CheckHealth(User,Animator),
               new CheckAmmo(User,Animator),

               new FieldOfView(User,Animator),
               new Selector(new List<Nodes>
               {
                   new Sequence(new List<Nodes>
                   {
                       new RandBehaviour(User),
                       new AttackTarget(User,Animator),
                   }),

                   new FleeTarget(User,Animator,Agent),
                   

               })
            }),

            new Sequence(new List<Nodes>
            {
                new FOVKit(User,Animator),
                new SearchItems(User,Animator),
            }),
            
            new Sequence(new List<Nodes>
            {
                new FOVAmmo(User,Animator),
                new SearchItems(User,Animator),
            }),

            new Explore(User,Animator),


        }) ;

        return root;
    }
}
