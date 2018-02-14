using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {


	void Update () {

        // Good link to understand rotations with Euler's angles.
        //https://www.youtube.com/watch?v=q0jgqeS_ACM
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);		
	}
}
