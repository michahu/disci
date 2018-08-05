using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	void Start () {


		
	}
	
	void Update () {


        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime, 0f, Input.GetAxis("Vertical")*Time.deltaTime);

		
	}
}
