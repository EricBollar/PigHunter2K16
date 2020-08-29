using UnityEngine;
using System.Collections;
[AddComponentMenu("Camera-Control/Mouse Look")]

public class BallScript : MonoBehaviour
{

    public int ForwardSpeed = 0;
    public int SideSpeed = 0;
    public float speed = 5.0f;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float minimumX = -180f;
    public float maximumX = 180f;

    public float sensitivityX = 15F;
    float rotationX = 0F;
    Quaternion originalRotation;

    public float jumpStrength = 10.0f;


    private bool m_cursorIsLocked = true;

    public bool lockCursor = true;

    public Animation anim;

    void Start()
    {
       originalRotation = transform.localRotation;
       anim.playAutomatically = false;
        foreach (AnimationState state in anim)
        {
            state.speed = 1F;
        }
    }

    void Update()
    {
        move();
        UpdateCursorLock();
        hit();
       // foreach (AnimationState state in anim)
       // {
       //     state.speed = 1F;
      //  }
    }

    public void move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) <= 0.1 && Physics.Raycast(transform.position, Vector3.down, 3.0f))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength); //Gives an upward force, better than simply moving the player in a given direction.
        }

        if (!Cursor.visible)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }

        if (Input.GetKey(KeyCode.D))
        {
            SideSpeed = 5;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            SideSpeed = -5;
        }
        else
        {
            SideSpeed = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ForwardSpeed = 8;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ForwardSpeed = 12;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ForwardSpeed = -8;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ForwardSpeed = -12;
            }
        }
        else
        {
            ForwardSpeed = 0;
        }

        transform.Translate(Vector3.right * SideSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * ForwardSpeed * Time.deltaTime);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < min)
            angle += (max - min);
        if (angle > max)
            angle -= (max - min);
        return Mathf.Clamp(angle, min, max);
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void hit()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("ArmAnimation");
        }
    }
}
