using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectTarget = target.transform.position;
        navMeshAgent.speed = 1f;
        navMeshAgent.SetDestination(vectTarget);
    }
}
