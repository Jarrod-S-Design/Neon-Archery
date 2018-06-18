using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour 
{


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Target") 
		{
			
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
