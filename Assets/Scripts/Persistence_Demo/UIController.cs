using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text scoreLabel;

    public static Action LoadData;
    public static Action SaveData;
    public static Action DeleteData;

    public void Load()
    {
        if (LoadData != null)
        {
            LoadData();
        }
    }

    public void Save()
    {
        if (SaveData != null)
        {
            SaveData();
        }
    }

    public void Delete()
    {
        if (DeleteData != null)
        {
            DeleteData();
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        PersistenceTester.OnScoreChanged += UpdateScoreLabel;
    }

    private void UpdateScoreLabel(int score)
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = score.ToString();
        }
    }
}