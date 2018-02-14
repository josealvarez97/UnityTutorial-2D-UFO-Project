using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // I need a reference to the player
    public GameObject PlayerReference;

    private Vector3 CameraOffsetFromPlayer;
    

	// Use this for initialization
	void Start () {
        //PlayerReference = GetComponent<GameObject>(); Does not work because it is not a component of this object.

        CameraOffsetFromPlayer = PlayerReference.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        // No idea why the code below does not work...
        // transform.position.Set(PlayerReference.transform.position.x, PlayerReference.transform.position.y,transform.position.z);

        transform.position = PlayerReference.transform.position - CameraOffsetFromPlayer;

    }

}
