using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backtoMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
