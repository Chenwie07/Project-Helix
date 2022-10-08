using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    public GameObject[] levelMarkers;
    private int leaderboardScore;

    // there must exist a more optimized way to achieve this. 
    private void Start()
    {
        leaderboardScore = 0;
        for (int i = 0; i < levelMarkers.Length; i++)
        {
            if (PlayerPrefs.GetString("Level " + (i + 1) + " Completed") == "YES")
            {
                levelMarkers[i].SetActive(true);
                leaderboardScore += 1000; // we will display this score on the leaderboard on play. 
            }
        }
        PlayUtilityManager.instance.PostScoreOnLeaderBoard(leaderboardScore);
    }
}
