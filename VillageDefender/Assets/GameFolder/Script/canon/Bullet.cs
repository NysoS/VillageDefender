using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    Transform transformDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transformDir.forward * (force * 10));

    StartCoroutine("Destoy");
    }

    IEnumerator Destoy()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }

    public void setDirectionBullet(Transform t)
    {
        transformDir = t;
    }    
}
