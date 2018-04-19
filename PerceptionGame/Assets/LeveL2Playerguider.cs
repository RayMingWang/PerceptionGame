using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveL2Playerguider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 42)
        {
            transform.position = new Vector3(-42f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -42)
        {
            transform.position = new Vector3(42f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 42)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -42f);
        }
        if (transform.position.z < -42)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 42f);
        }
    }
}
