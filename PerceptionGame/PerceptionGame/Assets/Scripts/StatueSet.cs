using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueSet : MonoBehaviour
{
    public GameObject Prompt;

    Material prompt_material;

    public void SetPromptTransparency(float a)
    {
        if(a>=0f)
            prompt_material.color = new Color(1.0f, 1.0f, 1.0f, a);
    }

    public Vector3 GetAngleByDist(Vector3 distance)
    {

        return Vector3.Normalize(transform.Find("Refe").GetComponentInChildren<Transform>().position - distance);
        //return Vector3.Normalize(transform.position-distance);
    }


    public void Start()
    {

        prompt_material = Prompt.GetComponent<MeshRenderer>().material;
        SetPromptTransparency(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
