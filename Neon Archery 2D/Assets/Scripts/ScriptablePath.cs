using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Path", menuName = "Path")]
public class ScriptablePath : ScriptableObject 
{
	public GameObject pathToFollow;
	public string pathName;
	public float speed;
	public float waveSize;
}
