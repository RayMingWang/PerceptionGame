using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private Transform m_goal;
    private NavMeshAgent m_agent;

    [SerializeField]
    private bool m_playerInCenter;
    public bool m_PlayerInCenter
    {
        get { return m_playerInCenter; }
        set { m_playerInCenter = value; }
    }

    private GameObject m_YOUWIN_Canvas;

    // **********************************************************************************************************************

    // Use this for initialization
    void Start ()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_goal = GameObject.Find("Player").transform;
        m_agent.destination = m_goal.position;

        m_YOUWIN_Canvas = GameObject.Find("YouWin_Canvas");
        m_YOUWIN_Canvas.SetActive(false);
        m_playerInCenter = false;

    }//END: Start()

    // **********************************************************************************************************************

    // Update is called once per frame
    void Update ()
    {
        m_agent.destination = m_goal.position;
	}//END: Update()

    // **********************************************************************************************************************

    private void LateUpdate()
    {
        
    }



    // **********************************************************************************************************************


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && m_playerInCenter)
        {
            m_YOUWIN_Canvas.SetActive(true);
            Collider[] colliderList = this.GetComponents<Collider>();
            
            foreach(Collider col in colliderList)
            {
                col.enabled = false;
            }
        }//END: "if" the player and Death are both inside of the center Ring - Enable the WIN message
    }//END: OnTriggerEnter




}//END: Death Class
