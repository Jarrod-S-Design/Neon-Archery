using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour 
{
	[SerializeField] private GameObject hitParticle;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Target") 
		{
			Vector3 temp = this.transform.position;
			Object.Instantiate (hitParticle, (new Vector3 (temp.x, temp.y, temp.z)),Quaternion.identity);
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
