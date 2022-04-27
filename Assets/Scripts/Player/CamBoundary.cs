using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoundary : MonoBehaviour
{
    private Camera MainCamera; //be sure to assign this in the inspector to your main camera

    // Use this for initialization
    void Start(){
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        if (viewPos.z > 26) viewPos.z = 26;
        if (viewPos.z < -12) viewPos.z = -12;
        if (viewPos.x > 43) viewPos.x = 43;
        if (viewPos.x < -43) viewPos.x = -43;

        transform.position = viewPos;
    }
}
