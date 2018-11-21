using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class makeVisible : MonoBehaviour{

	void Update()
	{
		GameObject[] obj = (GameObject[]) GameObject.FindObjectsOfType (typeof(GameObject));
		foreach (GameObject o in obj)
			o.hideFlags = HideFlags.None;
	}
}