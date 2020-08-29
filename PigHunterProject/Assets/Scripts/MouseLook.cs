using UnityEngine;
using System.Collections;

[AddComponentMenu("Player-Control/Simple Controller")]

public class MouseLook : MonoBehaviour
{
	public GameObject PlayerCamera;
	
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2, None = 3 };
	
    public RotationAxes axes = RotationAxes.MouseXAndY;
	
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
	
    public float minimumX = -180F;
    public float maximumX = 180F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    private float rotationX = 0F;
    private float rotationY = 0F;
	
    private Quaternion originalRotationX;
	private Quaternion originalRotationY;

	public float jumpStrength = 100.0f;
	public float speed = 3.0f;

    public Animation anim;
    public bool animation_bool;

	void Start()
    {
        // Make the rigid body not change rotation
        originalRotationX = transform.localRotation;
		originalRotationY = PlayerCamera.transform.localRotation;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        anim.playAutomatically = true;
        foreach (AnimationState state in anim)
        {
            state.speed = 1F;
        }
    }
	
    void Update()
    {
		if (!Cursor.visible){
			mouseControl();
			mainMovement();
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			PauseControl();
		}
    }
	
	void mainMovement(){
		//Implements movement for the player
		
		/************
			This section implements a very rudimentary WSDA
		************/
		if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
		
		/************
			This adds jump and sprint functionality
		************/
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) <= 0.1 && Physics.Raycast(transform.position, Vector3.down, 3.0f))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength); //Gives an upward force, better than simply moving the player in a given direction.
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2.5f;
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2.5f;
        }
	}
	
	void PauseControl(){
		//Code that allows the player to pause and unpause the game
		if (Cursor.visible){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1.0f;
		} else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0.0f;
        }
	}
	
	void mouseControl () {
		//Code that controls the mouse.
		
		//These lines of code are more complex, requiring a knowledge of Quaternions
		
		//This section controls the X direction mouse movement
		if (axes == RotationAxes.MouseX || axes == RotationAxes.MouseXAndY)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotationX * xQuaternion;
        }
		
		//This controls the Y direction. This is linked to the camera game  object
        if (axes == RotationAxes.MouseY || axes == RotationAxes.MouseXAndY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            PlayerCamera.transform.localRotation = originalRotationY * yQuaternion;
        }
	}
	
	/*void hitEnemies() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int i;

		for (i = 0; i < enemies.Length; i++)
		{
			Debug.Log(enemies[1].name);
			if (Vector3.Distance(enemies[i].transform.position, gameObject.transform.position) < 6.0f)
			{
				if (enemies[i].GetComponent<Enemy_AI>().health > 0)
				{
					enemies[i].GetComponent<Enemy_AI>().health--;
				}
				else
				{
					Destroy(enemies[i]);
				}

			}
		}
	}
	
	*/public static float ClampAngle(float angle, float min, float max)
    {
		//Clamp Angle function, simplifies the code for mouse control
		if (max >= 180.0f && min <= -180.0f){
			if (angle < min)
				angle += 360.0f;
			else if (angle > max)
				angle -= 360.0f;
		}
        return Mathf.Clamp(angle, min, max);
    }/*
	
	void OnApplicationPause( bool pauseStatus )
	{
		//This is the other way to handle pausing, this is a wednesday thing
		isPaused = pauseStatus;
	}*/
}