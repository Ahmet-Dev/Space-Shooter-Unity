using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{
    //Declare variables
    public float scrollSpeed;
    private Vector2 savedOffset;

    //Initializations
    void Start()
    {
        savedOffset = transform.position;
    }

    void Update()
    {
        transform.Translate(0.0f, -Time.deltaTime * scrollSpeed, 0.0f);
        //get the position of the transform related to the world screen
        Vector2 playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);

        //Reposition if the transform if it's position goes fully down
        if(playerPosScreen.y <= -(Screen.height/2) ){
            transform.position = savedOffset;
        }
    }

   
}