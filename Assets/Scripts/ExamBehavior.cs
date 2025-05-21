using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class ExamBehavior : MonoBehaviour, IDamagable
{
   
    public int health,damage;
    //public Image healthBar;
    //public GameObject hbar;
    private PlayerHealth player;
    private int maxHealth;
    private enum state{attack,chase,idle,dead};
    public float visionRange,attackRange;
    private NavMeshAgent navMeshAgent;
    state currentState;
    Animator animator;
    bool isAttacking =false;
    public AnimationClip attackAnimation,deathAnimation;
    private IEnumerator routine;

    //public GameObject nightvis;
    //public Material normalMaterial;
    //public Material highlightMaterial;
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        maxHealth = health;
        currentState = state.idle;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       // if (renderers.Length == 0) return;

        //bool isNightVision = nightvis.activeInHierarchy;
        //Material targetMaterial = isNightVision ? highlightMaterial : normalMaterial;

        /*
        if (isNightVision)
        {
            hbar.SetActive(true);
        }
        else
        {
            hbar.SetActive(false);
        }
        

        // Apply material to all parts
        foreach (var rend in renderers)
        {
            rend.material = targetMaterial;
        }
        */


        switch (currentState)
        {
            case state.idle:
                navMeshAgent.SetDestination(transform.position);
                animator.SetTrigger("Idle");
                if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < visionRange)
                {
                    currentState = state.idle;
                }
                break;
                /*
            case state.chase:
                navMeshAgent.SetDestination(PlayerMovement.Instance.transform.position);
                if (health < maxHealth / 2)
                {
                    navMeshAgent.speed = 5;
                    animator.SetTrigger("Run");
                }
                else
                {
                    animator.SetTrigger("Walk");
                    navMeshAgent.speed = 1;
                }
                if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) > visionRange * 1.5f)
                {
                    currentState = state.idle;
                }
                else if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) <= attackRange)
                {
                    currentState = state.attack;
                }
                break;
            case state.attack:
                animator.SetTrigger("Attack");
                Quaternion quaternion = Quaternion.LookRotation(PlayerMovement.Instance.transform.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternion, 1);
                if (!isAttacking)
                {
                    isAttacking = true;
                    routine = Attack();
                    StartCoroutine(routine);
                }
                break;
            case state.dead:
                break;
                */
        }
    }

    IEnumerator Attack(){
        navMeshAgent.SetDestination(transform.position);
        yield return new WaitForSeconds(attackAnimation.length);
        isAttacking = false;
        if(Vector3.Distance(transform.position,PlayerMovement.Instance.transform.position)<=attackRange+.1f){
            player.TakeDamage(damage);
        }else{
            currentState = state.chase;
        }
    }

    IEnumerator Die()
    {
       // if (Time.timeScale != 0)
       // {
        currentState = state.dead;
        navMeshAgent.SetDestination(transform.position);
        Destroy(this.GetComponent<Collider>());
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(deathAnimation.length);
        Destroy(this.gameObject);
       // }
    }

    public void TakeDamage(int damage)
    {
        //health-=damage;
        //healthBar.fillAmount = ((float)health / maxHealth);
        if(health<=0 && Time.timeScale > 0){
            if(routine!=null){StopCoroutine(routine);}
            routine = Die();
            StartCoroutine(routine);
        }
    }
}
