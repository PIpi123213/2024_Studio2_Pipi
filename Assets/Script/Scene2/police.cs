using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();




    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
