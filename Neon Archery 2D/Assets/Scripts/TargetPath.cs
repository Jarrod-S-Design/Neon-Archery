using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPath : MonoBehaviour 
{
	public GameObject pathToFollow;
	[SerializeField] private string pathName;
	private float speed;
	private float waveSize;
	// Use this for initialization
	void Start () 
	{
		// Assign scriptable variables

		iTween.Init (gameObject);
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", 2, "easetype",iTween.EaseType.easeInOutSine));
	}

	// Update is called once per frame
	void Update () 
	{

//		iTween.MoveAdd (target, targetPath[1], 2);

	}

//	void OnDrawGizmos()
//	{
//		iTween.DrawPath (targetPath, Color.red);
//	}
}
