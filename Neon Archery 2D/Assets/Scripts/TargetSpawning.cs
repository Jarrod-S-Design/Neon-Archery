using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawning : MonoBehaviour 
{

	[SerializeField] private ScriptableObject targetPath;
	[SerializeField] private int numTargets;
	[SerializeField] private GameObject targetPrefab;

	private bool canSpawn = false;
	[SerializeField] private float timePassed;
	[SerializeField] private float waitTime;

	// Use this for initialization
	void Start () 
	{
//		for (int i = 0; i < numTargets; i++) 
//		{
//			Object.Instantiate (targetPrefab, (new Vector3 (-6, 2, 0)), Quaternion.identity);
//			Debug.Log (i);
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Dirty ass timer but hey, it works maybe
		timePassed += Time.deltaTime;

		if ((timePassed > waitTime) && (canSpawn == false))
		{
		    timePassed = 0;
			canSpawn = true;
		}
		if (canSpawn == true) 
		{
			canSpawn = false;

			Object.Instantiate (targetPrefab, (new Vector3 (-6, 2, 0)), Quaternion.identity);
		}
	}
}
