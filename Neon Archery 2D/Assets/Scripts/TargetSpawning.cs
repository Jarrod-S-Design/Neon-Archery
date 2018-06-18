using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TargetSpawning : MonoBehaviour 
{
	[SerializeField] public List <ScriptablePath> targetPaths;
	private ScriptablePath currentPath;
	[SerializeField] private int numTargets;
	[SerializeField] private int maxTargets;
	[SerializeField] private GameObject targetPrefab;
	public int waveCount = 0;
	private bool canSpawn = false;
	[SerializeField] private float timePassed;
	[SerializeField] private float waitTime;

	// Use this for initialization
	void Start () 
	{
		currentPath = targetPaths[waveCount];
		maxTargets = currentPath.waveSize;

		numTargets = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Dirty ass timer but hey, it works maybe
	
		timePassed += Time.deltaTime;
		if (numTargets == maxTargets) 
		{
			WaveInfoUpdate ();
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
			numTargets = numTargets+1;
		}

	}

	public void WaveInfoUpdate()
	{
		waveCount = waveCount+1;
		numTargets = 0;
		if (waveCount == 2)
		{
			waveCount = 0;
		}
	} 
		
}

