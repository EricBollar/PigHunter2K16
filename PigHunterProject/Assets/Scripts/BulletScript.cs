using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    private Quaternion originalRotationX;

    float timeLeft = 5.0f;

    // Use this for initialization
    void Start () {
        originalRotationX = transform.localRotation;
        Quaternion xQuaternion = Quaternion.AngleAxis(90, Vector3.up);
        transform.localRotation = xQuaternion * originalRotationX;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * 45 * Time.deltaTime);

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
