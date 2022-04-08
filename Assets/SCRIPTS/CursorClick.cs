using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorClick : MonoBehaviour
{
    CameraRaycast camRay;
    // Start is called before the first frame update
    void Start()
    {
        camRay = GetComponent<CameraRaycast>();
    }

    // Update is called once per frame
    void Update()
    {
        print(camRay.m_layerHit);
        print(camRay.m_hit);
    }
}
