using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour 
{
	//shooting variables
	public GameObject arrowPrefab;
	public Transform arrowSpawn;
	public float arrowSpeed;

	public Vector3 onDownPos;
	public Vector3 onUPPos;
	private Vector3 lookAt;
	public Vector3 hit;
	private bool looking = false;

	public GameObject aimTrail;
	private Camera cam;

	void Start () 
	{
		cam = FindObjectOfType<Camera> ();
	}
		

	void FixedUpdate ()
	{
		// Clamp the transform
//		var tempY = this.transform.rotation.y;
		Mathf.Clamp (this.transform.rotation.y , 90, 90);
//		this.transform.rotation.y = tempY;
		// Draw a line from the camera to mouse position
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);



		Vector3 aim = transform.TransformDirection (Vector3.forward);
		// Get the position of the mouse/touch input when pressed down
		if (Input.GetMouseButtonDown(0))
		{
			looking = true;
			onDownPos = Input.mousePosition;
		}
		// Get the position of the mouse/touch input when released
		if (Input.GetMouseButtonUp(0))
		{
			looking = false;
			onUPPos = Input.mousePosition;
			//Fire Arrow
			GameObject GO = Instantiate (arrowPrefab, arrowSpawn.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (this.transform.forward * arrowSpeed, ForceMode.Impulse);
		}
		if (looking) 
		{
			lookAt = (Vector3)Input.mousePosition - onDownPos; 
			transform.LookAt (lookAt, Vector3.up);
		}
		Debug.DrawLine(onDownPos, onDownPos, Color.red);

	}

	void Update () 
	{
//		if (Input.GetMouseButtonDown(0))
//		{
//			startingPosition = cam.ScreenToWorldPoint (Input.mousePosition);
//		}
//		if (Input.GetMouseButtonDown(0))
//		{
//			looking = true;
//			onDownPos = Input.mousePosition;
//		}
//
//		if (Input.GetMouseButtonUp(0))
//		//ending position swipe delta
//		{
//			looking = false;
//			onUPPos = Input.mousePosition;
//
//			//Fire Arrow
//			GameObject GO = Instantiate (arrowPrefab, arrowSpawn.position, Quaternion.identity) as GameObject;
//			GO.GetComponent<Rigidbody> ().AddForce (this.transform.forward * arrowSpeed, ForceMode.Impulse);
//		}
//		if (looking) 
//		{
//			lookAt = (Vector2)Input.mousePosition - onDownPos; 
//			transform.LookAt (lookAt, Vector2.up);
//		}
//		Debug.DrawLine(onDownPos, onDownPos, Color.red);
	}
}
