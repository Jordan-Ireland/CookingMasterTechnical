using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Main game script to hold all important game variables
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //static instance of the game manager
    [Header("UI Vars")] //all the game UI variables
    public Text p1TimeUI;
    public Text p1ScoreUI;
    public Text p2TimeUI;
    public Text p2ScoreUI;

    //Values for player score and player time
    private float p1TimeValue = 120;
    private float p2TimeValue = 120;
    private int p1ScoreValue = 0;
    private int p2ScoreValue = 0;

    [Header("Vegetable Vars")]  //all the vegetable vars
    public Sprite lettuceSprite;
    public Sprite tomatoSprite;
    public Sprite onionSprite;

    //public getters and setters for time and scores
    public float P1Time { get { return p1TimeValue; } set { p1TimeValue = value; } }
    public float P2Time { get { return p2TimeValue; } set { p2TimeValue = value; } }
    public int P1Score { get { return p1ScoreValue; } set { p1ScoreValue = value; } }
    public int P2Score { get { return p2ScoreValue; } set { p2ScoreValue = value; } }

    // Awake is called once script gets activated
    private void Awake()
    {
        if(instance == null)    //checks if instance is null
        {
            instance = this;    //set the instance to this
        }else if(instance != null && instance != this)  //if the instance isn't null and not equal to this
        {
            Destroy(this);  //destroy this so there isn't 2 game managers
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //makes the time value decrease by 1 seconds every second
        p1TimeValue -= Time.deltaTime;
        p2TimeValue -= Time.deltaTime;
        UpdateUI(); //updates the time UI and score UI
    }

    /// <summary>
    /// Gets the vegetable sprite based on the vegetable passed
    /// </summary>
    /// <param name="_veg">What vegetable needs to be found</param>
    /// <returns></returns>
    public Sprite GetSprite(Vegetables _veg)
    {
        Sprite _sprite = null;  //sets the sprite to null in case None is passed
        switch (_veg)   //switch statement based on vegetable variable
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

    /// <summary>
    /// Updates the UI score & time based
    /// </summary>
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
