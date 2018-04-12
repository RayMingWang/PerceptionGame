using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPerspective : MonoBehaviour
{
    private AudioSource m_audioPrompt;
    private Camera m_playerCamera;

    bool perspectiveTriggered = false;

    private const float MAX_VECTOR_DIFFERENCE = 0.08f;
    private const float MAX_POSITIONAL_DIFFERENCE = 0.05f;

    // **********************************************************************************************************************

	// Use this for initialization
	void Start ()
    {
        m_playerCamera = GameObject.Find("Player Camera").GetComponent<Camera>();
        m_audioPrompt = GameObject.Find("PromptAudio").GetComponent<AudioSource>();
	}//END: Start()

    // **********************************************************************************************************************

    // Update is called once per frame
    void Update ()
    {
		
	}//END: Update()

    // **********************************************************************************************************************

    private void OnTriggerStay(Collider other)
    {
        float vectorAngleDifference = CheckVectorDifference(m_playerCamera.GetComponent<Transform>().forward);
        float vectorPositionalDifference = CheckPositionalDifference(m_playerCamera.GetComponent<Transform>().position);

        if((vectorAngleDifference < MAX_VECTOR_DIFFERENCE) && (vectorPositionalDifference < MAX_POSITIONAL_DIFFERENCE))
        {
            m_audioPrompt.Play();
            perspectiveTriggered = true;
        }
    }//END: OnTriggerStay()

    // **********************************************************************************************************************

    private void OnTriggerExit(Collider other)
    {
        perspectiveTriggered = false;

    }//END: OnTriggerExit()

    // **********************************************************************************************************************

    public float CheckVectorDifference(Vector3 playerCameraForward)
    {
        float vectorDifference = 0;

        vectorDifference = (playerCameraForward - this.transform.forward).magnitude;

        //Print "vectorDifference" to Console for Debugging Purposes
        print("Forward Vector Difference =  " + vectorDifference);

        return vectorDifference;
    }//END: CheckVectorDifference()

    // **********************************************************************************************************************

    public float CheckPositionalDifference(Vector3 playerCameraPostion)
    {
        float positionalDifference = 0;

        positionalDifference = (playerCameraPostion - this.transform.position).magnitude;

        //Print "positionalDifference" to Console for Debugging Purposes
        print("Positional Difference =  " + positionalDifference);

        return positionalDifference;
    }//END: CheckPositionalDifference()

    // **********************************************************************************************************************

}//END: CheckPerspective Class
