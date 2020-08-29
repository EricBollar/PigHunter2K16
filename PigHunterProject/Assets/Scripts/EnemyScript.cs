using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
	}
}
