using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float detectArea = 20f;
    public float attackArea = 10f;
    public Color colorDetectArea = Color.blue;
    public Color colorAttackArea = Color.red;
    public EnemyStatus enemyStatus = 0;

    public Transform target;
    public Transform enemyHead;
    public NavMeshAgent agent;
    [SerializeField] Animator animator = null;
    [SerializeField] Shoot shoot;
    [SerializeField] LayerMask playerLayer = 0;
    private Transform thisTransform;
    private float delayRandom = 3f;
    private float timecontrol = 0;
    readonly int velocityHash = Animator.StringToHash("velocity");
    readonly int isAttackHash = Animator.StringToHash("isAttack");
    private readonly int isDeadHash = Animator.StringToHash("isDead");
    
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHead = transform.Find("EnemyHead");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameEventController.AddEnemy(this);
       
    }
    private void Update()
    {
        thisTransform = transform;
        timecontrol += Time.deltaTime;

        if (enemyStatus != EnemyStatus.Dead)
        {
            ControlStatus();    
        }
        else
        {
            agent.isStopped = true;
        }
        
        animator.SetFloat(velocityHash, agent.velocity.magnitude);
        animator.SetBool(isAttackHash, enemyStatus == EnemyStatus.Attack);
        animator.SetBool(isDeadHash, enemyStatus == EnemyStatus.Dead);

    }

    private void ControlStatus()
    {
        float playerdDistance = Vector3.Distance(target.position, thisTransform.position);
        if (playerdDistance < attackArea && IsPlayerVisible())
        {
            enemyStatus = EnemyStatus.Attack;
        }
        else if (playerdDistance < detectArea && IsPlayerVisible())
        {
            enemyStatus = EnemyStatus.Follow;
        }
        else if (timecontrol > delayRandom  && agent.hasPath == false)
        {
            enemyStatus = EnemyStatus.Search;
        }

        if (enemyStatus == EnemyStatus.Search)
        {
            RandomDestination();
        }
        else if (agent.hasPath)
        {
            timecontrol = 0;
        }
        
        if (enemyStatus == EnemyStatus.Follow)
        {
            agent.SetDestination(target.position);
        }
        else if (enemyStatus != EnemyStatus.Attack)
        {
            enemyStatus = EnemyStatus.Search;
        }

        if (enemyStatus == EnemyStatus.Attack)
        {
            agent.isStopped = true;
            Attack();
        }
        else
        {
            enemyStatus = EnemyStatus.None;
            agent.isStopped = false;
        }
    }

    private void RandomDestination()
    {
        Vector3 ran = (Random.insideUnitSphere * Random.Range(10f, 20f)) + thisTransform.position;
        agent.SetDestination(ran);
        timecontrol = 0;
    }

    private void Attack()
    {
        Vector3 targetPos = target.position;
        targetPos.y = 0;
        transform.LookAt(targetPos);
        
    }

    private float TargetAngle()
    {
        Vector3 frontDirection = thisTransform.forward;
        Vector3 playerDirection = (target.position - thisTransform.position).normalized;
        return Vector3.Angle(frontDirection, playerDirection);
    }

    private bool IsPlayerVisible()
    {
        thisTransform = transform;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = thisTransform.position;
        bool seePlayer = false;

        Physics.Raycast(pos, (target.position - pos).normalized, out hit, detectArea);

        if (hit.collider)
        {
            seePlayer = hit.collider.gameObject.CompareTag("Player");
        }
        Debug.Log(seePlayer && TargetAngle() < 60f);
        return   seePlayer && TargetAngle() < 60f;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = colorDetectArea;
        Gizmos.DrawSphere(transform.position, detectArea);
        Gizmos.color = colorAttackArea;
        Gizmos.DrawSphere(transform.position, attackArea);
        //Debug.DrawRay(enemyHead.position, enemyHead.forward, Color.red);
    }

    private void OnDestroy()
    {
        GameEventController.RemoveEnemy(this);
    }
}

public enum EnemyStatus
{
    None,
    Search,
    Follow,
    Attack,
    Dead,
}
