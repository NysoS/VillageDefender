using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float range;

    public int nbWave = 1;
    public int nbEnemyMax = 4;
    public int nbEnemy;
    public int EnemyKill;

    public float time;
    float fireRate;

    public float timeBeforeStart;
    float timeBefore;

    public List<GameObject> enemyList;

    GameObject node;
    bool canSpawn;

    public Text timerValue;
    public GameObject timer;

    public GameObject boutique;

    private void Start()
    {
        node = GameObject.Find("grid_system");
        node.SetActive(false);
        canSpawn = false;
        timer = GameObject.Find("Timer");
        timerValue = GameObject.Find("TimeBeforeStart").GetComponent<Text>();

        timer.SetActive(true);

        timeBefore = timeBeforeStart;

        boutique = GameObject.Find("Boutique");
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E)){
            NewWave();
        }

        if (EnemyKill == nbEnemyMax)
        {
            print("new Wave");
            NewWave();
        }

        if (enemyList.Count == 0)
        {
            
        }

        if(enemyList.Count < 1)
        {
            Wave();
        }

        TimeSpawn();
    }

    void TimeSpawn()
    {
        if (nbEnemy == 0)
        {
            nbEnemy = 0;
        }


        if (canSpawn) {
            if (fireRate > time)
            {
                if (nbEnemy > 0)
                {
                    SpawnWaveEnemy();
                    nbEnemy--;
                }
                fireRate = 0.0f;
            }
            else
            {
                fireRate = fireRate + Time.deltaTime;
            }
        }
    }

    void SpawnWaveEnemy()
    {
        GameObject g = Instantiate(enemy, RandomPointOnCircleEdge(range), Quaternion.identity);
        enemyList.Add(g);
    }

    public void RemoveEnemy(GameObject g)
    {
        enemyList.Remove(g);
    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, 2, vector2.y);
    }

    void NewWave()
    {
        canSpawn = false;
        print("GoTIMER");
        enemyList.Clear();
        nbWave++;
        nbEnemyMax += 3;
        nbEnemy = nbEnemyMax;
        EnemyKill = 0;
        timeBefore = timeBeforeStart;
    }

    void Wave()
    {
        node.SetActive(true);
        canSpawn = false;
        nbEnemy = nbEnemyMax;
        timer.SetActive(true);
        boutique.SetActive(true);

        if (timeBefore < 0.1f)
        {
            CanSpawn();
            if (nbWave > nbWave+1)
            {
                NewWave();
            }
        }
        else
        {
            timeBefore -= Time.deltaTime;
            timerValue.text = (Mathf.Round(timeBefore * 1f) / 1f).ToString();
        }
    }

    private void CanSpawn()
    {
        node.SetActive(false);
        canSpawn = true;
        timer.SetActive(false);
        boutique.SetActive(false);
    }

    public void SetEnemyKill(int i)
    {
        EnemyKill += i;
    }
}
