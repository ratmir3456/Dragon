using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animatronik : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private float distance;
    public Transform target;
    private Animator myAnimator;
        

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance > 10)
        {
            myAgent.enabled = false;
            myAnimator.Play ("Idle");
        }
        if (distance < 10 & distance > 1.5f)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.position);
            myAnimator.Play("Run");
        }
        if (distance <= 1.5f)
        {
            myAgent.enabled = false;
            myAnimator.Play("Attack");
        }
    }
}
