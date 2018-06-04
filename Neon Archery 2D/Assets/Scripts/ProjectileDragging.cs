using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour 
{
	///Variables
	// Points on the bow to draw the string to
	public LineRenderer bowStringLeft;
	public LineRenderer bowStringRight;
	public Transform bowStringTransformLeft;
	public Transform bowStringTransformRight;
	// The spring joint connecting the arrow to the bow
	private SpringJoint2D spring;
	// The maximum distance you can draw the arrow back
	public float maxStretch = 3.0f;
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
	// Variables for manipulating the projectiles rigidbody
	private Vector2 prevVelocity;
	private bool isKinimatic;
	Rigidbody2D tempRigid;


	void Awake ()
	{
		spring = GetComponent <SpringJoint2D> ();
		bowObject = GameObject.FindWithTag ("Bow");
		bowTransform = bowObject.transform;
		GameObject tempLeft = GameObject.FindWithTag ("LeftBowString"); 
		GameObject tempRight = GameObject.FindWithTag ("LeftBowString");
		bowStringTransformLeft = tempLeft.transform; 
		bowStringTransformRight = tempRight.transform; 
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
		}

		// Logic while attached to the bow string
		if (spring != null) 
		{
			if (isKinimatic && prevVelocity.sqrMagnitude > Rigidbody2D.velocity.sqrMagnitude) 
			{
				Destroy (spring);
				tempRigid = GetComponent<Rigidbody2D> ();
				tempRigid.velocity = prevVelocity;
			}
			if (!clickedOn) 
			{
				tempRigid = GetComponent<Rigidbody2D> ();
				prevVelocity = tempRigid.velocity;
			}
		} 
		// Logic when released
		else 
		{

		}
	}

	void LineRendererSetup ()
	{
		bowStringLeft.SetPosition (0, bowStringLeft.transform.position);
		bowStringRight.SetPosition (0, bowStringRight.transform.position);
	}

	void LineRendererUpdate ()
	{
		Vector2 bowToProjectile = transform.position - bowStringLeft.transform.position;
		leftBowStringRay.direction = bowStringLeft;
		//		Vector3 holdPoint = leftBowStringRay.GetPoint (bowStringTransformLeft.magnitude + circleRadius);
	}

	void OnMouseDown ()
	{
		spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp ()
	{
		spring.enabled = true;
		this.gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
		isKinimatic = false;
		clickedOn = false;
	}

	void Dragging ()
	{
		// Covert the mouse screen position to world position
		// Figure out the distance from the mouse to the bow
		// If further away than the maxStretch cast a ray and manually place arrow at the the maximum stretch distance
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 bowToMouse = mouseWorldPoint - bowTransform.position;
		if (bowToMouse.sqrMagnitude > maxStretchSqr) 
		{
			rayToMouse.direction = bowToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (maxStretch);
		}
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}
}
