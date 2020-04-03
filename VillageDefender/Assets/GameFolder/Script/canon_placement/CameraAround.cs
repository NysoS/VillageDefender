using UnityEngine;

public class CameraAround : MonoBehaviour
{
    public GameObject target;
    float x;

    public float sensibility_x;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire2"))
        {
            x = Input.GetAxis("Mouse X");
            transform.RotateAround(target.transform.position, Vector3.up, x * sensibility_x * Time.deltaTime);
            transform.LookAt(target.transform);
        }
    }
}
