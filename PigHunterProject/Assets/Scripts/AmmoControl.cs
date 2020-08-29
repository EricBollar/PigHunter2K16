using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoControl : MonoBehaviour {

    public GameObject PlayerContainer;
    private Text counter;

	// Use this for initialization
	void Start () {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
        counter = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        counter.text = "Shots Left: " + PlayerContainer.GetComponent<ShootScript>().ammo;
	}
}
