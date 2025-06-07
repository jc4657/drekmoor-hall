using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Runtime.CompilerServices;

public class TempEnemy : MonoBehaviour
{
    private PlayerHealth player;
    public Transform target;
    private NavMeshAgent agent;

    public GameObject isReading;
    private Animator animator;
    public bool seen;
    private enum state {chase,idle};
    private float timer;
    Vector3 randDest;
    float x;
    float z;
    int idleTimer;

    state currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        seen = false;
        timer = 60.0f;
        currentState = state.idle;
        idleTimer = 240;
        x = Random.Range(transform.position.x + 5, transform.position.x - 5);
        z = Random.Range(transform.position.z + 5, transform.position.z - 5);
        randDest = new Vector3(x, transform.position.y, z);
    }

    void Update()
    {
        
        Vector3 pos = transform.position;
        Vector3 playerPos = target.transform.position;
        Ray ray = new Ray(pos, transform.forward);
        // if (target)
        // {
        switch (currentState)
        {
            case state.idle:
                animator.SetTrigger("Idle");
               
                idleTimer--;
                agent.SetDestination(randDest);
                if ((pos - randDest).magnitude <= 0.5 ||  Physics.Raycast(ray, 1) || idleTimer <= 0) //(pos - randDest).magnitude <= 0.5 || 
                {
                    x = Random.Range(pos.x - 5, pos.x + 5);
                    z = Random.Range(pos.z - 5, pos.z + 5);
                    randDest = new Vector3(x, pos.y, z);
                    idleTimer = 2400;
                }
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath)
                {
                Debug.Log("Agent stuck. Picking new destination.");
                        // Pick new destination 
                }
                //NavMeshPathStatus.PathPartial;
                if (seen == true)
                {
                    animator.SetTrigger("Chase");
                    currentState = state.chase;
                }
                break;
            case state.chase:
                animator.SetTrigger("Chase");
                agent.SetDestination(target.position);
                animator.SetFloat("Speed", agent.velocity.magnitude);
                if (seen == false)
                {
                    currentState = state.idle;
                }
                break;
        }

        Vector3 range = pos - playerPos;
        float view = Vector3.Angle(range, transform.forward);
        //if ((pos - playerPos).magnitude <= 15)
        if (((view <= -90 || view >= 90) && range.magnitude <= 5) || ((view <= -45 || view >= 45) && !Physics.Raycast(ray, range.magnitude - 1)) || isReading.activeInHierarchy) //((view <= -90 || view >= 90) && range.magnitude <= 15) || 
        {
            timer = 1200.0f;
            seen = true;
        }
        else if ((pos - playerPos).magnitude > 15 && (pos - playerPos).magnitude <= 70)
        {
            countDown();
        }
        

        // }



        if ((pos - playerPos).magnitude <= .7)
        {
            //player.TakeDamage(35);
            target.GetComponent<PlayerHealth>().TakeDamage(35);
        }
        
    }

    void countDown()
    {
        timer--;
        if (timer <= 0.0f)
        {
            seen = false;
            timer = 0.0f;
        }
    }
}
