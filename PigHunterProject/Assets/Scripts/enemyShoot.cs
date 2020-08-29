using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {


    public GameObject spawnPosObj;
    public GameObject bullet;
    public float timeLeft = 2f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Instantiate(bullet, spawnPosObj.transform.position, transform.rotation);
            timeLeft = 2f;
        }
    }
}
