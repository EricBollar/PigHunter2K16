using UnityEngine;
using System.Collections;

public class PigSpawn : MonoBehaviour {


    public GameObject PigSpawn1;
    public GameObject PigSpawn2;
    public GameObject PigSpawn3;
    public GameObject PigSpawn4;
    public GameObject PigSpawn5;
    public GameObject PigSpawn6;
    public GameObject PigSpawn7;
    public GameObject PigSpawn8;
    public GameObject pig;

    // Use this for initialization
    void Start () {
        Instantiate(pig, PigSpawn1.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn2.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn3.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn4.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn5.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn6.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn7.transform.position, transform.rotation);
        Instantiate(pig, PigSpawn8.transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
