using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // I need a reference to the player
    public GameObject PlayerReference;

    private Vector3 CameraOffsetFromPlayer;


    // Pinch to Zoom Code
    public float perspectiveZoomSpeed = .2f;
    public float orthographicZoomSpeed = .2f;

    private Camera cameraReference;


    // Use this for initialization
    void Start () {
        //PlayerReference = GetComponent<GameObject>(); Does not work because it is not a component of this object.

        CameraOffsetFromPlayer = PlayerReference.transform.position - transform.position;

        cameraReference = GetComponent<Camera>();
        
    }


    void Update()
    {

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 prevTouchZeroPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 prevTouchOnePosition = touchOne.position - touchOne.deltaPosition;


            float touchesDistance = (touchZero.position - touchOne.position).magnitude;
            float prevTouchesDistance = (prevTouchZeroPosition - prevTouchOnePosition).magnitude;

            //float pinchToZoomMagnitude = touchesDistance - prevTouchesDistance;
            // greater distance than before, zoom in.
            // less distance than before, zoom out


            // It's better in the following way.
            float pinchToZooomMagnitude = prevTouchesDistance - touchesDistance;
            // greater than before, negative result. Zoom in. (Reduce the field of view or the size of the camera).
            // less than before, positive result. Zoom out. (Increment field of view or the size of the camera).
            // Since we want to reduce the field of view or the size of the camera, this is the correct way to substract the two values.



            if (cameraReference.orthographic)
            {
                float newSize = cameraReference.orthographicSize + pinchToZooomMagnitude * orthographicZoomSpeed; // is speed the right wording here..? Maybe it should be...
                cameraReference.orthographicSize = Mathf.Max(newSize, 50f); // we don't want negatives. Shouldn't we clamp here as well?



            }
            else // is not orthographic
            {
                cameraReference.fieldOfView += pinchToZooomMagnitude * perspectiveZoomSpeed; // what if the numbers are off...?
                cameraReference.fieldOfView = Mathf.Clamp(cameraReference.fieldOfView, 50f, 179.9f);

            }

        }
    }

    // Update is called once per frame
    void LateUpdate () {

        // No idea why the code below does not work...
        // transform.position.Set(PlayerReference.transform.position.x, PlayerReference.transform.position.y,transform.position.z);

        transform.position = PlayerReference.transform.position - CameraOffsetFromPlayer;

    }

}
