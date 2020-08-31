using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour {

    //assign bullet/proctile prefab 
    public GameObject bulletPrefab;
    //assign a transform from where a bullet/prefab is spawned
    public Transform bulletSpawn;
    //sprite of the player
    public SpriteRenderer sprite;
    //life bar slider
    public Slider lifebar;
    //set the value out 100 that a player will loose it's health
    public int reduceLifePerHit;
    //how much coins will be awared
    public int rewardAmount;
    //reward video promt panel
    public GameObject rewardVideoPanel;
    //speed of the player 
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

        //initial health
        lifebar.value = 1;

        //if the user selected any rocket, assign that rocket as player
        if(GameController.gamePlayingRocket != null){
            var scale = sprite.transform.localScale;
            sprite.sprite = GameController.gamePlayingRocket;
            sprite.transform.localScale = scale;
        }

        //get the total screen size
		world = Camera.main.ScreenToWorldPoint(transform.position);
	}

    void Update() {

		world = Camera.main.ScreenToWorldPoint(transform.position);

        //Get the acceleration direction
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);

		Debug.Log(world + " " + playerPos);

        // get payer position in reference with the world
        Vector2 playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);

        //set player position inside of the screen
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

        //call fire method on touch event
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Fire();
        }

		
    }

    //Instatiate a new bullet
    void Fire()
    {
        bulletShot.Play();
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    //Handle if the player collide with other object
    void OnTriggerEnter2D(Collider2D col)
    {
        //handles if collides with an enemy or asteriods
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Asteroid")
        {
            //Instantiate(explosionPrefab, transform.position, transform.rotation);
            //Destroy the player
            Destroy(gameObject);
            //destroy with wich the player collides
            Destroy(col.gameObject);
            onCancel();
            //pause everything
            Time.timeScale = 0;
        }

        //handle if it collides with a reward object
        if (col.gameObject.tag == "Reward")
        {
            GameController.setCoins(rewardAmount + GameController.getCoins());
            Destroy(col.gameObject);

        }

        //handle if a bullet hits it
        if(col.gameObject.tag == "EnemyBullet"){

            //reduce the health, convert between 0-1
            lifebar.value -=  (reduceLifePerHit/100.0f);

            // handle if the score goes under 0
            if (lifebar.value <= 0)
            {
                //handle if there is any rewarded video
                if (AdmobVideo.isAdLoaded)
                {
                    //if rewarded video is loaded, show the option to continue
                    rewardVideoPanel.SetActive(true);
                    //pause everytihing
                    Time.timeScale = 0;
                }
                else
                {
                    //if any reawarded video is loaded, go to onCancel
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

        //hide the reward video option
        rewardVideoPanel.SetActive(false);

        //save new high score if the score is greater than the previous high score
        if(Scoring.score > GameController.getHighScore()){
            GameController.setHighScore(Scoring.score);
            GooglePlayScript.AddScoreToLeaderboard(GPGSIds.leaderboard_rocket_lead, Scoring.score);
        }

        //show current score and the highest score
        score.SetActive(true);
        currentScore.text = Scoring.score.ToString();
        highScore.text = GameController.getHighScore().ToString();
        Time.timeScale = 0;


    }


}
