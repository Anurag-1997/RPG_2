using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Layer
{
    WalkableArea=6,
    Enemy=7,
    raycastEndStop=-1
}
public class CameraRaycast : MonoBehaviour
{
    public Layer[] layerProps = { Layer.WalkableArea, Layer.Enemy };
    public Camera cam;
    RaycastHit hit;
    public RaycastHit m_hit { get { return hit; } }
    Layer layerHit;
    public Layer m_layerHit { get { return layerHit; } }
    public float maxRayDistance = 100;

    private void Update()
    {
        foreach (Layer item in layerProps) //Look for and return priority layerhit
        {
            var r_hit = RaycastForLayer (item);
            if(r_hit.HasValue)
            {
                hit = r_hit.Value;
                layerHit = item;
                return;
                
            }
        }
        hit.distance = maxRayDistance;
        layerHit = Layer.raycastEndStop; 
    }
    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,maxRayDistance,layerMask))
        {
            return hit;
        }
        return null;
    }
}
