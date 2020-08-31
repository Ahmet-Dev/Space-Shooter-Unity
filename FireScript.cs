using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
	public GameObject bulletPrefab;
	public GameObject[] enemyPrefab;
    	public Transform enemySpawn;

    int x;
	float time;

	// Use this for initialization
	void Start () {
		
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
        x = Random.Range(0, enemyPrefab.Length -1);
		//yPosition = 8;
		time += Time.deltaTime;
		if(time >= 2){

            var enemy = Instantiate(enemyPrefab[x], enemySpawn.position, enemySpawn.rotation);
			time = 0;

            Destroy(enemy, 100.0f);


		}

	}
	
}
