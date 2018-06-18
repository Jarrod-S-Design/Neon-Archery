using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPath : MonoBehaviour 
{
	// Variables
	[SerializeField] public List <ScriptablePath> targetPaths;
	[SerializeField] private string pathName;
	[SerializeField] private float speed;
	private ScriptablePath currentPath;
	private GameObject spawner;
	private int pathToChoose;
	// Use this for initialization
	void Start () 
	{
		// Assign scriptable variables
//		spawner = GameObject.FindGameObjectWithTag("GameController");
//		pathToChoose = spawner.GetComponent<TargetSpawning> ().waveCount;
//		currentPath = targetPaths[pathToChoose];
//		speed = currentPath.speed;
//		pathName = currentPath.pathName;
		// Activate iTween and apply scriptable variables
		iTween.Init (gameObject);
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", speed, "easetype",iTween.EaseType.easeInOutSine));
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
