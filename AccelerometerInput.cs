using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {
	
	void Update() { 
         // Se misca obiectul pe axa X si Y
        transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
    }

}
