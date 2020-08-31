using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public SpriteRenderer sprite;
    public Slider lifebar;
    public int reduceLifePerHit;
    public int rewardAmount;
    public GameObject rewardVideoPanel;
 	public float speed = 10.0F;
    public GameObject explosionPrefab;
    public AudioSource bulletShot;

	public Vector3 playerPos;
	public Vector3 world;
	float half_szX;
	float half_szY;

    //Score panel
    public GameObject score;
    public Text currentScore;
    public Text highScore;


    public static PlayerMove instance;

	

	void Start(){
        // playerPos = transform.position;
        // half_szX = renderer.bounds.size.x / 2;
        // half_szY = renderer.bounds.size.y /2 ;
        bulletShot = GetComponent<AudioSource>();
        instance = this;
        lifebar.value = 1;

        if(GameController.gamePlayingRocket != null){
            var scale = sprite.transform.localScale;
            sprite.sprite = GameController.gamePlayingRocket;
            sprite.transform.localScale = scale;
        }
		world = Camera.main.ScreenToWorldPoint(transform.position);
	}

    void Update() {

		world = Camera.main.ScreenToWorldPoint(transform.position);

        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);

		Debug.Log(world + " " + playerPos);

        Vector2 playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);
        if (playerPosScreen.x > Screen.width)
        {
            transform.position = 
                Camera.main.ScreenToWorldPoint(
                    new Vector3(Screen.width, 
                                playerPosScreen.y, 
                                transform.position.z - Camera.main.transform.position.z));
        }
        if (playerPosScreen.x < 0.0f)
        {
            transform.position = 
                Camera.main.ScreenToWorldPoint(
                    new Vector3(0.0f, 
                                playerPosScreen.y, 
                                transform.position.z - Camera.main.transform.position.z));
        }

    	if (playerPosScreen.y > Screen.height)
        {
            transform.position = 
                Camera.main.ScreenToWorldPoint(
                    new Vector3(playerPosScreen.x, 
                                Screen.height, 
                                transform.position.z - Camera.main.transform.position.z));
        }
    	if (playerPosScreen.y < 0)
        {
            transform.position = 
                Camera.main.ScreenToWorldPoint(
                    new Vector3(playerPosScreen.x, 
                                0.0f, 
                                transform.position.z - Camera.main.transform.position.z));
        }

		Debug.Log(world + " " + playerPos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Fire();
        }	
    }
    void Fire()
    {
        bulletShot.Play();
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        Destroy(bullet, 2.0f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Asteroid")
        {
            //Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(col.gameObject);
            onCancel();
            Time.timeScale = 0;
        }
        if (col.gameObject.tag == "Reward")
        {
            GameController.setCoins(rewardAmount + GameController.getCoins());
            Destroy(col.gameObject);

        }
        if(col.gameObject.tag == "EnemyBullet"){
            lifebar.value -=  (reduceLifePerHit/100.0f);
            if (lifebar.value <= 0)
            {
                if (AdmobVideo.isAdLoaded)
                {
                    rewardVideoPanel.SetActive(true);
                    //pause everytihing
                    Time.timeScale = 0;
                }
                else
                {
                    onCancel();
                }

                Debug.Log("Game Over");
            }

        }

    }

    //public void addLife(int value){

    //    lifebar.value += (value / 100.0f);
    //    rewardVideoPanel.SetActive(false);
    //    //Time.timeScale = 1;

    //}

    public void onCancel(){
        rewardVideoPanel.SetActive(false);
        if(Scoring.score > GameController.getHighScore()){
            GameController.setHighScore(Scoring.score);
            GooglePlayScript.AddScoreToLeaderboard(GPGSIds.leaderboard_rocket_lead, Scoring.score);
        }
        score.SetActive(true);
        currentScore.text = Scoring.score.ToString();
        highScore.text = GameController.getHighScore().ToString();
        Time.timeScale = 0;
    }
}
