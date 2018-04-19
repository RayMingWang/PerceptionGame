using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10_SolutionImage : MonoBehaviour
{
    [SerializeField]
    private Death m_death;

    // **********************************************************************************************************************

    // Use this for initialization
    void Start ()
    {
        GameObject go = GameObject.Find("Death");
        if (go != null)
        {
            m_death = go.GetComponent<Death>();
        }
	}//END: Start()

    // **********************************************************************************************************************

    // Update is called once per frame
    void Update ()
    {
		
	}//END: Update()

    // **********************************************************************************************************************

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            m_death.m_PlayerInCenter = true;
        }
    }//END: OnTriggerEnter()

    // **********************************************************************************************************************

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_death.m_PlayerInCenter = false;
        }
    }//END: OnTriggerExit()

}//END: Level10_SolutionImage Class
