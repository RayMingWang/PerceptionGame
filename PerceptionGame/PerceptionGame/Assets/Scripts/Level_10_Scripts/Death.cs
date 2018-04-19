using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Death : MonoBehaviour
{
    private Transform m_goal;
    private NavMeshAgent m_agent;
    private float m_Force = 500.0f;
    private AudioSource mon;

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
        mon = GetComponent<AudioSource>();
    }//END: Start()

    // **********************************************************************************************************************

    // Update is called once per frame
    void Update ()
    {
        m_agent.destination = m_goal.position;
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
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
            mon.Stop();
            
            foreach(Collider col in colliderList)
            {
                col.enabled = false;
            }
        }//END: "if" the player and Death are both inside of the center Ring - Enable the WIN message
        else if(other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().Move((other.transform.position - this.transform.position).normalized * Time.deltaTime * m_Force);
        }
    }//END: OnTriggerEnter




}//END: Death Class
