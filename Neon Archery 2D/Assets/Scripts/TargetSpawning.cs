using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawning : MonoBehaviour 
{
	[SerializeField] public ScriptableObject[] targetPaths;
//	[SerializeField] private ScriptableObject targetPath;
	public int numTargets;
	[SerializeField] private int maxTargets;
	[SerializeField] private GameObject targetPrefab;

	private bool canSpawn = false;
	[HideInInspector] public bool nextWave = false;
	[SerializeField] private float timePassed;
	[SerializeField] private float waitTime;

	// Use this for initialization
	void Start () 
	{
		maxTargets = numTargets;
		numTargets = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Dirty ass timer but hey, it works maybe
		timePassed += Time.deltaTime;
		if (nextWave == true) 
		{
		
		}
		if ((timePassed > waitTime) && (canSpawn == false)) 
		{
			timePassed = 0;
			canSpawn = true;
		}
		if (canSpawn == true) 
		{
			canSpawn = false;
			Object.Instantiate (targetPrefab, (new Vector3 (-6, 2, 0)), Quaternion.identity);
			numTargets = numTargets++;
		}
		
	}
}
