using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotator : MonoBehaviour {

	void Start() {
   
}
	void Update () {
		transform.Rotate (new Vector3(Time.deltaTime * 0,0,-1f));
	}
}
