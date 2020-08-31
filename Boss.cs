using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    // Use this for initialization
    public static bool isBossLive = false;
    //public GameObject bossPrefab;
    public GameObject[] bulletSpawns;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public int bossReward;
    public float time;
    //Defines how many bullets the boss will endure
    public int lifeTime;

    bool isActive = false;

    //Intialize variables
	void Start () {
        GetComponent<Animator>().enabled = false;
        time = 0.0f;
        isActive = false;

	}

    void OnBecameVisible()
    {
        isActive = true;
    }
	
	// Update is called once per frame
	void Update () {

        //if(Scoring.score == 20){
        //    isBossLive = true;
        //}

        if(isBossLive){
            time += Time.deltaTime;

            if (time >= 1 && isActive == true)
            {
                Debug.Log("Firing");
                Fire();
                time = 0.0f;
            }

            if(transform.position.y >= 3){
                transform.Translate(0.0f, -Time.deltaTime * 2, 0.0f);
            }
            else{
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().Play(0);
            }

        }
		
	}

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab

        for (int i = 0; i < bulletSpawns.Length; i++){
            var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawns[i].transform.position,
                bulletSpawns[i].transform.rotation);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }


    }

    //handle if the bullet hits an enemy
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Hitted");
            lifeTime--;

            Scoring.score++;
            Destroy(col.gameObject);
            if(lifeTime <= 0){

                Instantiate(explosionPrefab, transform.position, transform.rotation);
                Scoring.score += bossReward;
                isBossLive = false;
                Destroy(gameObject);
            }




        }

    }
}
