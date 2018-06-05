using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour 
{
	//https://youtu.be/L0tl0CwPYIc?t=3053


	///Variables
	// Points on the bow to draw the string from
	[SerializeField] private LineRenderer bowStringLeft;
	[SerializeField] private LineRenderer bowStringRight;
	// Projectile prefab to instantiate when this ones fired, COME UP WITH A BETTER WAY TO DO THIS PLEASE!
	[SerializeField] private GameObject energyBall;
	// The maximum distance you can draw the arrow back
	[SerializeField] private float maxStretch = 3.0f;
	private float maxStretchSqr;
	// Wether or not the mouse is pressed down
	private bool clickedOn;
	// Rays for finding distance from the arrow to the bow
	private Ray rayToMouse;
	private Ray leftBowStringRay;
	// Bow object, transform, and collider information
	private GameObject bowObject;
	private Transform bowTransform;
	private float circleRadius;
	[SerializeField] private float firingSpeed;
	// Variables for manipulating the projectiles rigidbody
	private bool fireArrow;
	[SerializeField] private GameObject currentBall;


	void Awake ()
	{
//		spring = GetComponent <SpringJoint2D> ();
		bowObject = GameObject.FindWithTag("Bow");
		bowTransform = bowObject.transform;
	}

	// Use this for initialization
	void Start () 
	{
		LineRendererSetup ();
		rayToMouse = new Ray (bowTransform.position, Vector3.zero);
		leftBowStringRay = new Ray (bowStringLeft.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
		circleRadius = circle.radius;
	}

	// Update is called once per frame
	void Update () 
	{
		if (clickedOn) 
		{
			Dragging ();
			LineRendererUpdate ();
		}
		if (fireArrow) 
		{
			ReleaseMouse ();
		}
	}

	void LineRendererSetup ()
	{
		bowStringLeft.SetPosition (0, bowStringLeft.transform.position);
		bowStringRight.SetPosition (0, bowStringRight.transform.position);
	}

	void LineRendererUpdate ()
	{
		Vector3 holdPoint = currentBall.transform.position;
		bowStringLeft.SetPosition (1, holdPoint);
		bowStringRight.SetPosition (1, holdPoint);
	}

	void OnMouseDown ()
	{
		clickedOn = true;
	}

	void OnMouseUp ()
	{
		clickedOn = false;
		fireArrow = true;
	}

	void Dragging ()
	{
		// Covert the mouse screen position to world position
		// Figure out the distance from the mouse to the bow
		// If further away than the maxStretch cast a ray and manually place arrow at the the maximum stretch distance
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 bowToMouse = mouseWorldPoint - bowTransform.position;
		// Make the projectile look at the bow
		Vector3 diff = bowTransform.position - transform.position;
		diff.Normalize ();
		float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rot_z);

		rayToMouse.direction = bowToMouse;
		if (bowToMouse.sqrMagnitude > maxStretchSqr) 
		{
			rayToMouse.direction = bowToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (maxStretch);
		}
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void ReleaseMouse ()
	{
		// Apply a force to the projectile and instantiate the next projectile
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (-rayToMouse.direction * (firingSpeed));
		fireArrow = false;
		Object.Instantiate (energyBall, (new Vector3 (0, -2, 0)), Quaternion.identity);
		// Start the timer on the destroy script
		GetComponent<Destroy>().startTimer = true;
	}
}
