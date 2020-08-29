using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShootScript : MonoBehaviour {

    public GameObject spawnPosObj;
    public GameObject bullet;
    public int ammo = 5;
    public GameObject[] pigs;
    public float timeLeft = 2f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        pigs = GameObject.FindGameObjectsWithTag("enemy");
        if (ammo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, spawnPosObj.transform.position, transform.rotation);
                ammo--;
            }
        }else if (ammo == 0)
        {
            if (pigs.Length > 0)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        if (pigs.Length == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("youWin");
        }
    }
}
