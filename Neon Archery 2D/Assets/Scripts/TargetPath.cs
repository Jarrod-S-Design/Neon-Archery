using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPath : MonoBehaviour 
{
	// Variables
	[SerializeField] public List <ScriptablePath> targetPaths;
	[SerializeField] private string pathName;
	[SerializeField] private float speed;
	[SerializeField] private ScriptablePath currentPath;
	// Use this for initialization
	void Start () 
	{
		// Assign scriptable variables
		currentPath = targetPaths[0];
		speed = currentPath.speed;
		pathName = currentPath.pathName;
		// Activate iTween and apply scriptable variables
		iTween.Init (gameObject);
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", speed, "easetype",iTween.EaseType.easeInOutSine));
	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void WaveInfoUpdate()
	{
	
	} 
}
