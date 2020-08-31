using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float time;
	public GameObject bulletPrefab;
    public Transform bulletSpawn;

    bool isActive = false;
	// Use this for initialization
	void Start () {

        isActive = false;
		time = 0.0f;
	}

    void OnBecameVisible()
    {
        isActive = true;
    }
	
	// Update is called once per frame
	void Update () {
		
		time += Time.deltaTime;

        if(gameObject.tag == "Enemy"){

            if (time >= 1.5 && isActive == true)
            {
                Debug.Log("Firing");
                Fire();
                time = 0.0f;
            }
        }


		transform.Translate(0.0f, -Time.deltaTime * 2, 0.0f);
	}

	//  void OnCollisionEnter2D (Collision2D col)
    // {
    //     if(col.gameObject.tag == "Bullet")
    //     {
    //         Destroy(gameObject);
    //     }
    // }

	void Fire()
    {
        // Create the Bullet from the Bullet Prefab

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);        
    }
}
