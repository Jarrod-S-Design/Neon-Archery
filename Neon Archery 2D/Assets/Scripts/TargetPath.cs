using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPath : MonoBehaviour 
{
	// Variables
	public ScriptablePath scriptPath;
	private string pathName;
	private float speed;

	// Use this for initialization
	void Start () 
	{
		// Assign scriptable variables
		speed = scriptPath.speed;
		pathName = scriptPath.pathName;
		// Activate iTween and apply scriptable variables
		iTween.Init (gameObject);
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", speed, "easetype",iTween.EaseType.easeInOutSine));
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
