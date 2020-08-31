using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{
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

        Vector2 playerPosScreen = Camera.main.WorldToScreenPoint(transform.position);

        if(playerPosScreen.y <= -(Screen.height/2) ){
            transform.position = savedOffset;
        }
    }

   
}
