using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEngine.AI;
public class Explore : Nodes
{
    private Transform _transform;
    private NavMeshAgent _agent;
    private NavMeshAgent _wayPointFollow;
    private Animator _animator;
    private float timerNextPos = 2f;
    public Explore(Transform transform, Animator animator,NavMeshAgent agent,NavMeshAgent wayPointFollow)
    {
        _transform = transform;
        _animator = animator;
        _agent = agent;
        _wayPointFollow = wayPointFollow;
    }

    public override NodesState Evaluate()
    {
        timerNextPos -= Time.deltaTime;

        if (timerNextPos <= 0)
        {
            int x = Random.Range(-50, 50);
            int z = Random.Range(-50, 50);

            _wayPointFollow.SetDestination(new Vector3(x + _wayPointFollow.transform.position.x, _wayPointFollow.transform.position.y, z + _wayPointFollow.transform.position.z));
            _agent.SetDestination(_wayPointFollow.transform.position);
            timerNextPos = 2f;
        }
        
        return NodesState.RUNNING;
    }
}
