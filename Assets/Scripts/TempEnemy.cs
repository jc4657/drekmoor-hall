using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
public class TempEnemy : MonoBehaviour
{
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
        if (target)
        {
            agent.SetDestination(target.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }
}
