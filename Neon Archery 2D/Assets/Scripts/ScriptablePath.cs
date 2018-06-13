using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Path", menuName = "Path")]
public class ScriptablePath : ScriptableObject 
{
	// Target Movement
	public string pathName;
	public float speed;

	// Target Spawning
	public float waveSize;
	public float waveSpacing;
}
