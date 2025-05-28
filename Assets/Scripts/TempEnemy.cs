using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class TempEnemy : MonoBehaviour
{
    private PlayerHealth player;
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 playerPos = target.transform.position;
        if (target)
        {
            agent.SetDestination(target.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
            animator.SetTrigger("Idle");
        }

        if ((pos - playerPos).magnitude <= .7)
        {
            //player.TakeDamage(35);
            target.GetComponent<PlayerHealth>().TakeDamage(35);
        }
    }
}
