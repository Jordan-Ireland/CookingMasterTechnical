using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("UI Vars")]
    public Text p1TimeUI;
    public Text p1ScoreUI;
    public Text p2TimeUI;
    public Text p2ScoreUI;

    private float p1TimeValue = 120;
    private float p2TimeValue = 120;
    private int p1ScoreValue = 0;
    private int p2ScoreValue = 0;

    [Header("Vegetable Vars")]
    public Sprite lettuceSprite;
    public Sprite tomatoSprite;
    public Sprite onionSprite;

    public float P1Time { get { return p1TimeValue; } set { p1TimeValue = value; } }
    public float P2Time { get { return p2TimeValue; } set { p2TimeValue = value; } }
    public int P1Score { get { return p1ScoreValue; } set { p1ScoreValue = value; } }
    public int P2Score { get { return p2ScoreValue; } set { p2ScoreValue = value; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != null && instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        p1TimeValue -= Time.deltaTime;
        p2TimeValue -= Time.deltaTime;
        UpdateUI();
    }

    public Sprite GetSprite(Vegetables _veg)
    {
        Sprite _sprite = null;
        switch (_veg)
        {
            case Vegetables.None:
                break;
            case Vegetables.Lettuce:
                _sprite = lettuceSprite;
                break;
            case Vegetables.Tomato:
                _sprite = tomatoSprite;
                break;
            case Vegetables.Onion:
                _sprite = onionSprite;
                break;
        }

        return _sprite;
    }

    void UpdateUI()
    {
        p1TimeUI.text = $"Time {(int)p1TimeValue}";
        p2TimeUI.text = $"Time {(int)p2TimeValue}";

        p1ScoreUI.text = $"Score {p1ScoreValue}";
        p2ScoreUI.text = $"Score {p2ScoreValue}";
    }

    /// <summary>
    /// Adds time to a player
    /// </summary>
    /// <param name="isPlayer1">Is this player 1?</param>
    /// <param name="timeToAdd">Time to add</param>
    public static void AddTime(bool isPlayer1, float timeToAdd)
    {
        if (isPlayer1)
        {
            instance.P1Time = instance.P1Time + timeToAdd;
        }else
        {
            instance.P2Time = instance.P2Time + timeToAdd;
        }
    }

    /// <summary>
    /// Add score to a player
    /// </summary>
    /// <param name="isPlayer1">Is this player 1?</param>
    /// <param name="scoreToAdd">Score to add</param>
    public static void AddScore(bool isPlayer1, int scoreToAdd)
    {
        if (isPlayer1)
        {
            instance.P1Score = instance.P1Score + scoreToAdd;
        }
        else
        {
            instance.P2Score = instance.P2Score + scoreToAdd;
        }
    }
}
