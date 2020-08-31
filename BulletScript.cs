using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    //speed of bullets
	public float speed = 10;
    public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(0.0f, Time.deltaTime * speed, 0.0f);
	}
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
			Debug.Log("Hitted");
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);



            Scoring.score++;
        }

    }
	private void OnBecameInvisible()
	{
        Destroy(gameObject);
	}
}
