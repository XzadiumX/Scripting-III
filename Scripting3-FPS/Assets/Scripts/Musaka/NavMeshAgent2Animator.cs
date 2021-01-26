using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshAgent2Animator : MonoBehaviour
{
    Animator cmpAnimator;
    NavMeshAgent cmpAgent;

    public float interpolationSpeed = 5;
    float animatorSpeed;

    private void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
        cmpAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float agentSpeed = cmpAgent.velocity.magnitude;
        animatorSpeed = Mathf.MoveTowards(animatorSpeed, agentSpeed, interpolationSpeed * Time.deltaTime);
        cmpAnimator.SetFloat("speed", animatorSpeed);
    }
}
