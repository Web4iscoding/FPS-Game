using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : StateMachineBehaviour
{

    float timer;
    public float idleTime = 0f;

    Transform player;

    public float detectionAreaRadius = 18f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // initializing values
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // idle sequence
        timer += Time.deltaTime;
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (timer > idleTime)
        {
            animator.SetBool("isWalking", true);
        }

        if (distanceFromPlayer < detectionAreaRadius)
            animator.SetBool("isChasing", true);
    }
}
