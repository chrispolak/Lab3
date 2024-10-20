using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Man : MonoBehaviour
{
    public GameObject Target;
    public UnityEngine.AI.NavMeshAgent agent;
    public bool isWalking = true;
    public Animator animator;
    public GameObject targetFace;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

        animator.SetTrigger("WALK");
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            agent.destination = Target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        print("AAAAA");
        if(other.name == "Dragon" || other.name == "Red")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
            var lookPos = targetFace.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
