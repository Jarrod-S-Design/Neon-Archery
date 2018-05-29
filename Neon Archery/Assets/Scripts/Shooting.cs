using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour 
{
	public Transform bulletSpawn;
	public GameObject bulletPrefab;
	public float bulletSpeed;

	//Shooting Timer
	public float waitTime;

	private bool canShoot = true;
	public float timePassed;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//var trigger = XCI.GetButton(XboxButton.A);
		timePassed += Time.deltaTime;

		if (Input.GetButton("Submit")) 
		{
			if (canShoot == true && timePassed >= waitTime) 
			{
				FireBullet ();
			}
		}

		if ((timePassed >= waitTime) && (canShoot == false))
		{
			timePassed = 0;
			canShoot = true;
		}
	}

	void FireBullet ()
	{
		GameObject GO = Instantiate (bulletPrefab, bulletSpawn.position, Quaternion.identity) as GameObject;
		GO.GetComponent<Rigidbody> ().AddForce (this.transform.up * bulletSpeed, ForceMode.Impulse);
		canShoot = false;
	}
}
