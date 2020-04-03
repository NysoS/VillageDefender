using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int lifeMax = 100;
    public int life;

    private SpawnEnemy spawnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnEnemy>();

        life = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        DeadEnemy();
    }



    private void DeadEnemy()
    {
        if (life <= 0)
        {
            GameObject g = GameObject.Find("Spawn");
            g.GetComponent<SpawnEnemy>().RemoveEnemy(gameObject);
            spawnEnemy.SetEnemyKill(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Bullet")
        {
            life -= 50;
        }
    }
}
