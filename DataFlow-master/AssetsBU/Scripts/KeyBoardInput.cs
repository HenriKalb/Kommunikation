using UnityEngine;
using System.Collections;

public class KeyBoardInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("up"))
        {
            UnityEngine.XR.InputTracking.Recenter();
            print("Camera recentered");
        }

    }
}
