using UnityEngine;
using System.Collections;

public class menuHunter : MonoBehaviour {

    public Transform piggy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(piggy);
	}
}
