using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timertext : MonoBehaviour {

    public GameObject PlayerContainer;
    private Text clock;

    // Use this for initialization
    void Start()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
        clock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        clock.text = "" + Mathf.Floor(PlayerContainer.GetComponent<Timer>().timeLeft) +"";
    }
}
