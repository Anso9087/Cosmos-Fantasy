using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
   public Transform followTransform;
   public BoxCollider2D mapBounds;
   private float xMin, xMax, yMin, yMax;
   private float camX, camY;
   private float camOrthsize;
   private float cameraRatio;
   private Camera mainCam;

   private void Start(){
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax+camOrthsize)/ 2.0f;
   }

    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin+camOrthsize, yMax-camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin+camOrthsize, xMax-camOrthsize);
        this.transform.position = new Vector3(camX, 
        camY, followTransform.position.z);
    }
}
