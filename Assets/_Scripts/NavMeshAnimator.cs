using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAnimator : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public Life life;
    public EnemyFSM fsm;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
       
    }
    //Sets the speed and the movement animation of the enemy depending on wich  state it is.
    private void Update()
    {
        if (life.Amount <= 0||fsm.currentState == EnemyFSM.EnemyStates.AttackPlayer|| fsm.currentState == EnemyFSM.EnemyStates.AttackBase)
        {
            _agent.speed = 0; _animator.SetFloat("Velocity", 0);
        }
        else 
        {
            _agent.speed = 10;
            _animator.SetFloat("Velocity", _agent.velocity.magnitude);

        }
        
    }
        
}
