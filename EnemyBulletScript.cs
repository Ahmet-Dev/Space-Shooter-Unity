using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

    //speed of enemy bullets
	public float speed = 10;
	public int direction;
	// Use this for initialization
	void Start () {
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(0.0f, -Time.deltaTime * speed, 0.0f);
	}
	void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
			Debug.Log("Hitted");
            Destroy(col.gameObject);
        }
        Destroy(gameObject);

    }
}
