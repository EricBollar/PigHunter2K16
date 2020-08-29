using UnityEngine;
using System.Collections;

public class AI_Mover : MonoBehaviour {

    public int speed = 5;
    private int status;
    private float rotationLeft;
    private int direction;
    private float detectDistance = 5.0f;

    private Transform playerThing;

	// Use this for initialization
	void Start () {
        status = 0;
        playerThing = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        int randHolder;
        switch(status)
        {
            case 0:
                randHolder = Random.Range(1, 101);
                if (randHolder == 100)
                {
                    status = 1;
                } else
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                break;
            case 1:
                randHolder = Random.Range(1, 3);
                switch(randHolder)
                {
                    case 1:
                        if(true)//!Physics.Raycast(transform.position, Vector3.right, 10.0f))
                        {
                            direction = 1;
                            status = 2;
                            rotationLeft = 90.0f;
                        }
                        else
                        {
                            status = 0;
                        }
                        break;
                    case 2:
                        if (true)//!Physics.Raycast(transform.position, Vector3.left, 10.0f))
                        {
                            direction = -1;
                            status = 2;
                            rotationLeft = 90.0f; 
                        }
                        else
                        {
                            status = 0;
                        }
                        break;
                }
                break;
            case 2:
                if (rotationLeft > 45.0f * Time.deltaTime)
                {
                    transform.Rotate(Vector3.up * direction * 45.0f * Time.deltaTime);
                    rotationLeft -= 45.0f * Time.deltaTime;
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(Vector3.up * direction * rotationLeft);
                    status = 0;
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                break;
            default:
                status = 0;
                break;

        }
        runAway();
	}

    public void runAway()
    {
        if (Vector3.Distance(transform.position, playerThing.position) < 30)
        {
            speed = 25;
        }else
        {
            speed = 5;
        }
    }
}
