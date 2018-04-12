using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Death : MonoBehaviour
{
    private Transform goal;
    NavMeshAgent agent;
    
    // **********************************************************************************************************************

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.Find("Player").transform;
        agent.destination = goal.position;
    }//END: Start()

    // **********************************************************************************************************************

    // Update is called once per frame
    void Update ()
    {
        agent.destination = goal.position;
	}//END: Update()

    // **********************************************************************************************************************

}//END: Death Class
