using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour 
{
	[SerializeField] private float destroyTimer;
	public bool startTimer = false;
	// Update is called once per frame
	void Update () 
	{
		if (startTimer) 
		{
			Destroy (this.gameObject, destroyTimer);
		}
	}
}
