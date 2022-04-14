using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class EnemiesBT : TreeBuild
{
    public Transform User;
    public Transform Player;
    public Animator Animator;
    public NavMeshAgent Agent;
    public NavMeshAgent WpFollow;
    public Zone Zone;
    public static float fovRange = 20f;
    public static int NbAmmo = 50;
    public AudioSource ShootEnnemie;
    public AudioClip ShootClipEnnemie;

    protected override Nodes SetupTree()
    {
        Nodes root = new Selector(new List<Nodes>
        {
            new GoToZone(User,Animator,Agent,WpFollow,Zone),

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
                       new AttackTarget(User,Animator,ShootEnnemie,ShootClipEnnemie),
                   }),

                   new FleeTarget(User,Animator,Agent),
                   

               })
            }),

            new Sequence(new List<Nodes>
            {
                new FOVKit(User,Animator),
                new SearchItems(User,Animator,Agent),
            }),
            
            new Sequence(new List<Nodes>
            {
                new FOVAmmo(User,Animator),
                new SearchItems(User,Animator,Agent),
            }),

            new Explore(User,Animator,Agent,WpFollow),


        }) ;

        return root;
    }
}
