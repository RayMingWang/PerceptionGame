using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWalls : MonoBehaviour
{
    private const float SPEED = 10.0f;
    private float direction = 0.0f;
    public float Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    // **********************************************************************************************************************

    // Use this for initialization
    public virtual void Start ()
    {
       
	}//END: Start()
    // **********************************************************************************************************************

    // Update is called once per frame
    void Update ()
    {
		
	}//END: Update()
    // **********************************************************************************************************************

    //Fixed Update
    private void FixedUpdate()
    {
        transform.eulerAngles += Time.deltaTime * SPEED * new Vector3(0, direction * 1.0f, 0);
    }//END: FixedUpdate()
    // **********************************************************************************************************************

}//END: RotateWalls Class
