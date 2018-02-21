using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour {


    // BETTER TO HAVE THIS CODE IN CAMERA CONTROLLER
    // will keep it here and not delete the file to remind me of that...

 //   public float perspectiveZoomSpeed = .5f;
 //   public float orthographicZoomSpeed = .5f;

 //   private Camera cameraReference;
	//// Use this for initialization
	//void Start()
 //   {
 //       cameraReference = GetComponent<Camera>();
 //   }

 //   // Update is called once per frame
 //   void Update () {
		
 //       if (Input.touchCount == 2)
 //       {
 //           Touch touchZero = Input.GetTouch(0);
 //           Touch touchOne = Input.GetTouch(1);

 //           Vector2 prevTouchZeroPosition = touchZero.position - touchZero.deltaPosition;
 //           Vector2 prevTouchOnePosition = touchOne.position - touchOne.deltaPosition;


 //           float touchesDistance = (touchZero.position - touchOne.position).magnitude;
 //           float prevTouchesDistance = (prevTouchZeroPosition - prevTouchOnePosition).magnitude;

 //           //float pinchToZoomMagnitude = touchesDistance - prevTouchesDistance;
 //           // greater distance than before, zoom in.
 //           // less distance than before, zoom out


 //           // It's better in the following way.
 //           float pinchToZooomMagnitude = prevTouchesDistance - touchesDistance;
 //           // greater than before, negative result. Zoom in. (Reduce the field of view or the size of the camera).
 //           // less than before, positive result. Zoom out. (Increment field of view or the size of the camera).
 //           // Since we want to reduce the field of view or the size of the camera, this is the correct way to substract the two values.


            
 //           if (cameraReference.orthographic)
 //           {
 //               cameraReference.orthographicSize += pinchToZooomMagnitude * orthographicZoomSpeed; // is speed the right wording here..? Maybe it should be...
 //               cameraReference.orthographicSize = Mathf.Max(cameraReference.orthographicSize, .1f); // we don't want negatives. Shouldn't we clamp here as well?

 //           }
 //           else // is not orthographic
 //           {
 //               cameraReference.fieldOfView += pinchToZooomMagnitude * perspectiveZoomSpeed; // what if the numbers are off...?
 //               cameraReference.fieldOfView = Mathf.Clamp(cameraReference.fieldOfView, .1f, 179.9f);

 //           }


            

 //       }

	//}
}
