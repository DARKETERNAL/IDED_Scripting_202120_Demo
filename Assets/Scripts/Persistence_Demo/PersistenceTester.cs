using System;
using UnityEngine;

public class PersistenceTester : MonoBehaviour
{
    private static PersistenceTester instance;
    public static PersistenceTester Instance { get => instance; private set => instance = value; }

    private int score;

    private int Score
    {
        get => score;
        set
        {
            score = value;

            if (OnScoreChanged != null)
            {
                OnScoreChanged(score);
            }
        }
    }

    public static Action<int> OnScoreChanged;

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Score");

        if (OnScoreChanged != null)
        {
            OnScoreChanged(score);
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            UIController.LoadData += LoadScore;
            UIController.SaveData += SaveScore;
            UIController.DeleteData += DeleteScore;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            Score += 1;
        }
    }
}