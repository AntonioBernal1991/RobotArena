using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyStates{GoToBase, AttackBase,ChasePlayer,AttackPlayer }

    public EnemyStates currentState;

    public float baseAttackDistance, playerAttackDistance;
    private float lastShootTime;
    public float shootRate;

    private Sight _sight;
    private Transform baseTransform;
    private NavMeshAgent agent;
    private Animator animator;
    public GameObject shootingPoint;

    public ParticleSystem fireEffect;
    public AudioSource shootshound;
   




    private void Awake()
    {
        _sight = GetComponent<Sight>();
        baseTransform = GameObject.FindWithTag("Base").transform;
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
    }

    //checks on wich state the Enemy Ai is , and sends a command.
    private void Update()
    {
      switch(currentState)
        {
            case EnemyStates.GoToBase:
                GoToBase();
                break;
            case EnemyStates.AttackBase:
                AttackBase();
                break;
            case EnemyStates.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyStates.AttackPlayer:
                AttackPlayer();
                break;
            default:

                break;
        }

        //Commands the enemy to aproach and attack the player base, if the player is closer, the enemy will attack him.
        void GoToBase()
        {
            animator.SetBool("shootbool", false);
            print("Ir la base Enemiga");
            agent.isStopped = false;
            agent.SetDestination(baseTransform.position);
            if (_sight.detectedTarget != null)
            {
                currentState =  EnemyStates.ChasePlayer;
                 
            }
            float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

            if ( distanceToBase < baseAttackDistance)
            {
                currentState = EnemyStates.AttackBase;
            }
        }

        //Commands the enemy to stop and attack the base.
        void AttackBase()
        {   
            
            print("Atacar la base Enemiga");
            agent.isStopped = true;
            LookAt(baseTransform.position);
            ShootTarget();
        }

        //Commands the Enemy to chase the player.
        void ChasePlayer()
        {
            animator.SetBool("shootbool", false);
            print("perseguir al jugador");
            if (_sight.detectedTarget == null)
            {
                GoToBase();
                return;
            }
            agent.isStopped = false;
            agent.SetDestination(_sight.detectedTarget.transform.position);
            float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
           
            if ( distanceToPlayer < playerAttackDistance)
            {
                currentState = EnemyStates.AttackPlayer;
            }
        }

        //Commands the enemy to attack the player when its close enough.
        void AttackPlayer()
        {
            print("Atacar al jugador");
            agent.isStopped = true;
            if (_sight.detectedTarget == null)
            {
                currentState =  EnemyStates.GoToBase;
                return;
            }
            LookAt(_sight.detectedTarget.transform.position);
            ShootTarget();
            float distanceToPlayer = Vector3.Distance(transform.position,
                _sight.detectedTarget.transform.position);
            if ( distanceToPlayer > playerAttackDistance*1*1f)
            {
                currentState = EnemyStates.ChasePlayer;
            }

          
        }
    }
    //Makes the enemy able to shoot
    void ShootTarget()
    {
        if (Time.timeScale > 0)
        {
            var timeSincelastshoot = Time.time - lastShootTime;
            if (timeSincelastshoot < shootRate)
            {
                return ;
            }

            lastShootTime = Time.time;
            var bullet = ObjectPool.SharedInstance.GetFirstPooledObject();
            bullet.layer = 3;
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.SetActive(true);
            shootshound.Play();
            fireEffect.Play();




        }
    }

   //Makes the enemy able to look at the player.
   void LookAt(Vector3 targetPos)
     {
        var directionToLook = Vector3.Normalize(targetPos - transform.position);
        directionToLook.y = 0;
        transform.parent.forward = directionToLook;
     }
    //Draw sphere to see where is the attack distance.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }




}
 