using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonDeezNutzGottem : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        print("AAAAA");
        if (other.name == "RPGHeroHP")
        {
            animator.SetTrigger("Attack");
        }
    }

}
