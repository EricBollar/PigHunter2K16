using UnityEngine;
using System.Collections;

public class hitStick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(Vector3.up * 45.0f * Time.deltaTime);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            transform.Rotate(Vector3.down * 45.0f * Time.deltaTime);
            transform.Translate(Vector3.back * 1 * Time.deltaTime);
        }
	}
}
