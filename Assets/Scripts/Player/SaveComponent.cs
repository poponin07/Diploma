using UnityEngine;

public static class SaveComponent
{

    public static void SaveGame(int bestScore)
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        Debug.Log("Game data saved!");
    }

    public static void GetBestScore()
    {
        int bestScore= PlayerPrefs.GetInt("BestScore");
    }
}
