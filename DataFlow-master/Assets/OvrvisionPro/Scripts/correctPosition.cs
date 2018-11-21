using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(transform.localPosition.x, 0.035f, transform.localPosition.z);
    }
}
