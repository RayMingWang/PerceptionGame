using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTrigger : MonoBehaviour {

    public AudioSource audio;
    public StatueSet statue;
    public float maxOpaque = 6f;

    private PlayerController player_controller;
    private Transform player = null;
    private Transform playercamera = null;
    
    private Vector3 defalutAngle;
    private float max_distance;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Transform>();
        playercamera = player.Find("Player Camera").GetComponentInChildren<Transform>();
        player_controller = other.GetComponent<PlayerController>();
        if (player_controller.fly_count==0)
        {
            
            max_distance = Vector3.Distance(player.position, this.transform.position);
            Debug.Log("Enter");
        }
        else
        {
            player = null;
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (player == null)
            return;
        float distance_multi=  (max_distance - Vector3.Distance(player.position, this.transform.position))/max_distance;
        this.transform.eulerAngles = player.eulerAngles + playercamera.eulerAngles;

        float angle_multi = Vector3.Distance(defalutAngle, playercamera.transform.forward);
        angle_multi = (0.2f - angle_multi / 2f)*maxOpaque;
        statue.SetPromptTransparency(angle_multi+ distance_multi*0.6f);
        //statue.SetPromptTransparency(1f);
        if (angle_multi + distance_multi * 0.6f > 0.7f)
        {
            if (player_controller.fly_count == 0)
            {
                player_controller.fly_count = 5;
                
                audio.Play();
            }

        }
        Debug.Log(playercamera.transform.forward);
        //Debug.Log(angle_multi*0.4 + distance_multi * 0.6f);
    }
    private void OnTriggerExit(Collider other)
    {
        player = null;
        statue.SetPromptTransparency(0);
        //Debug.Log("Exit");
    }
    void Start () {
        defalutAngle = statue.GetAngleByDist(transform.position);
        //Debug.Log(defalutAngle);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
