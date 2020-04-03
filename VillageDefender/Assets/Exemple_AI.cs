using UnityEngine;
using UnityEngine.AI;

public class Exemple_AI : MonoBehaviour
{

    public Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //renseigne la variable navMesh
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Va en direction de la cible
        agent.SetDestination(target.position);
    }
}
