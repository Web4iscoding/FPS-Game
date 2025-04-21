using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieChasingState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chaseSpeed = 6f;

    public float stopChasingDistance = 21;
    public float attackingDistance = 2.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // adjusting chase speed based on difficulty and mode
        if (SelectMode.Instance.mode == SelectMode.Mode.Battle || SelectMode.Instance.mode == SelectMode.Mode.Tutorial)
            chaseSpeed = 6f;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Easy)
            chaseSpeed = 4f;
        else if (Difficulty.Instance.currentDiff == Difficulty.Difficulties.Medium)
            chaseSpeed = 6f;
        else
            chaseSpeed = 8f;

        // stop walking sequence
        animator.SetBool("isWalking", false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = chaseSpeed;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // chasing sequence
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        if (distanceFromPlayer > stopChasingDistance)
            animator.SetBool("isChasing", false);

        int random = UnityEngine.Random.Range(1, 3);
        if (random == 1 && distanceFromPlayer < attackingDistance)
            animator.SetBool("isAttacking", true);
        else if(distanceFromPlayer < attackingDistance)
            animator.SetBool("isAttacking_alt", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // follow player
        agent.SetDestination(animator.transform.position);
    }
}
