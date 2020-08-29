using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PIgsLeft : MonoBehaviour {


    private GameObject[] pigs;
    private Text pigsLeft;

    // Use this for initialization
    void Start () {
        pigsLeft = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        pigs = GameObject.FindGameObjectsWithTag("enemy");
        pigsLeft.text = "Pigs Left: " + pigs.Length;
    }
}
