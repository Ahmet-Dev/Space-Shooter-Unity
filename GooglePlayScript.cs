using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class GooglePlayScript : MonoBehaviour {


    // Use this for initialization
    void Start () {
        //Initialize google play services
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }
 
    //Sign in to google play account
    void SignIn()
    {
        Social.localUser.Authenticate(success => { //handle if the authentication is successful or fails
        });
    }
 
    #region Leaderboards

    // Add highscore to the leaderboard
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { Debug.Log("HighScore posted"); 
            //handle the if the score is posted successfully or not
        });
    }
 
    //Show leaderboard UI
    public void ShowLeaderboardsUI()
    {
        // if the player is not authenticated, sign in first
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            SignIn();

        }

        //show leader board UI
        Social.ShowLeaderboardUI();
        Debug.Log("LeaderBoard");
        //Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboards
 
}
