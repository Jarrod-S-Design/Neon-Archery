using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTrail : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.GetComponent<TrailRenderer> ().enabled = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			this.GetComponent<TrailRenderer> ().enabled = false;
		}
		this.transform.position = Input.mousePosition;
	}
}
