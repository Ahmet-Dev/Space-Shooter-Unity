using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    //Assign the bullet prefab
	public GameObject bulletPrefab;
    //Assign combinations of enemies
	public GameObject[] enemyPrefab;

    // the point from where the enemies are spawned
    public Transform enemySpawn;

    int x;
	float time;

	// Use this for initialization
	void Start () {
		
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		
        //Takes a random combination to spawn
        x = Random.Range(0, enemyPrefab.Length -1);
		//yPosition = 8;
		time += Time.deltaTime;


        //every enemy will be created after 2 sec 
		if(time >= 2){

            var enemy = Instantiate(enemyPrefab[x], enemySpawn.position, enemySpawn.rotation);
			time = 0;

            Destroy(enemy, 100.0f);


		}
		 
		



	}

	
}
