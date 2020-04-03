using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDetect : MonoBehaviour
{
    public List<GameObject> enemiesList;


    public GameObject bullet;
    public Transform[] ejectBullet;
    public float time;
    float fireRate;

    public AudioSource fireSound;

    // Update is called once per frame
    void Update()
    {
        if (enemiesList.Count > 0)
        {
            foreach(GameObject g in enemiesList)
            {
                transform.LookAt(enemiesList[0].transform);
                transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy") {
            if (fireRate > time)
            {
                StartCoroutine("Fire");
                fireRate = 0.0f;
            }
            else
            {
                fireRate += Time.deltaTime;
            }
        }

        if(enemiesList.Count > 0)
        {
            if (enemiesList[0] == null)
            {
                enemiesList.RemoveAt(0);
            }
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2);
        for(int i = 0; i < ejectBullet.Length; i++)
        {
            GameObject b = Instantiate(bullet, ejectBullet[i].position, Quaternion.identity);
            b.GetComponent<Bullet>().setDirectionBullet(transform);
            fireSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            AddEnemies(other.gameObject);
    }

    void AddEnemies(GameObject g)
    {
        enemiesList.Add(g);
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveEnemies(other.gameObject);
    }

    void RemoveEnemies(GameObject g)
    {
        enemiesList.Remove(g);
    }

}
