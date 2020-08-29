using UnityEngine;
using System.Collections;

public class teleportPig : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
         if (transform.position.x > 1000)
         {
             transform.position = new Vector3(568, transform.position.y, transform.position.z);
        }
    }
}
