using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] bossPrefab;
    public Transform enemySpawn;
    public int[] respawnTime;
    public int bossInterval;

    int x;
    int t;
    float time;

    // Use this for initialization
    void Start()
    {
        Boss.isBossLive = false;
        time = 0;
        t = Random.Range(0,respawnTime.Length-1);
    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(0, enemyPrefab.Length-1);
        time += Time.deltaTime;

        if(gameObject.tag == "EnemySpawn"){

           

            if(!Boss.isBossLive){
                

                if (Scoring.score == 1)
                {
                    Boss.isBossLive = true;
                    var enemy = Instantiate(bossPrefab[0], enemySpawn.position, enemySpawn.rotation);

                }


                if (Scoring.score % bossInterval == 0 && Scoring.score > 0)
                {

                    Boss.isBossLive = true;
                    var enemy = Instantiate(bossPrefab[(Scoring.score / bossInterval) % bossPrefab.Length], enemySpawn.position, enemySpawn.rotation);
                    enemy.SetActive(true);
                }

                if (time >= respawnTime[t])
                {
                    var enemy = Instantiate(enemyPrefab[x], enemySpawn.position, enemySpawn.rotation);
                    t = Random.Range(0, respawnTime.Length - 1);
                    time = 0;
                    Destroy(enemy, 100.0f);
                }
            }

            else{
            }
        }
        else{
            if (time >= respawnTime[t])
            {
                var enemy = Instantiate(enemyPrefab[x], enemySpawn.position, enemySpawn.rotation);
                t = Random.Range(0, respawnTime.Length - 1);
                time = 0;
                Destroy(enemy, 100.0f);
            }
        }


    }
}
