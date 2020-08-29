using UnityEngine;
using System.Collections;

public class menuMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * 5 * Time.deltaTime);
	}
}
