using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool GameOver { get; internal set; }
    public bool isLevelComplete { get; internal set; }

    [Header("Panel Settings")]
    public GameObject _panelLevelSuccess;
    public GameObject _panelLevelFailure;
    public GameObject _panelGameplay;
    public GameObject _panelGameMenu;

    public static int currentLevelIndex;

    [Header("UI Elements")]
    public Slider _sliderGameProgress;
    public TextMeshProUGUI _currentLevelText;
    public TextMeshProUGUI _nextLevelText;
    public TextMeshProUGUI _scoreText;

    private int _score = 0;

    public int TotalRings { get; set; }
    public int RingsPassed { get; set; }
    public bool MuteGame { get; set; }
    public bool isGameStarted { get; set; }
    public LevelProps.LevelType LevelType { get; set; }
    public int CurrentLevel { get; set; }
    public float TimeElapsed { get; private set; }
    public int LevelCompleteScore { get; set; }

    private int flag;

    private void Awake()
    {
        instance = this;
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        flag = 1; 
        RingsPassed = 0;
        //int highscore = PlayerPrefs.GetInt("Highscore", 0);
        Time.timeScale = 1;
        isGameStarted = MuteGame = GameOver = isLevelComplete = false;
        // set the level text. 
        _currentLevelText.SetText("" + CurrentLevel);
    }

    private void Update()
    {
        #region PC 
        // for PC then replace with the if statement below, remove the
        //if (Input.GetMouseButtonDown(0) && !isGameStarted)
        //{
        //    // return if we are touching (via Raycasting) a UI game object, otherwise continue. 
        //    if (EventSystem.current.IsPointerOverGameObject())
        //        return;
        //    isGameStarted = true;
        //    flag = 1;
        //    TimeElapsed = Time.time;
        //    // get the time the game started. 
        //    _panelGameMenu.SetActive(false);
        //    _panelGameplay.SetActive(true);
        //}
        #endregion
        #region MOBILE 
        // Eventsystem for touch and finger ID, then continue. 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            isGameStarted = true;
            TimeElapsed = Time.time;

            _panelGameMenu.SetActive(false);
            _panelGameplay.SetActive(true);
        }
        #endregion

        if (GameOver)
        {
            Time.timeScale = 0f; // animations will not work here unless you set the animation mode to unscaled time. 
            // this is because we have affected the timescale here, so animations will stop as well unless we check that option. 
            _panelLevelFailure.SetActive(true);
            //if (_score > PlayerPrefs.GetInt("Highscore"))
            //{
            //    PlayerPrefs.SetInt("Highscore", _score);
            //}
            if (Input.GetButtonDown("Fire1"))
            {
                _score = 0; // reset score. 
                SceneManager.LoadScene("Level Select");
            }
        }
        else if (isLevelComplete && flag == 1)
        {
            flag = 0;
            TimeElapsed = Time.time - TimeElapsed;
            // 1000 is the score added for completing successfully, think of it as a multiplier, right now a magic number 
            // but each level should have it's own. 
            LevelCompleteScore = Mathf.RoundToInt((1 / TimeElapsed * RingsPassed) * 1000);
            _panelLevelSuccess.SetActive(true);
            PlayerPrefs.SetString("Level " + CurrentLevel + " Completed", "YES");
            //if (_score > PlayerPrefs.GetInt("Highscore"))
            //{
            //    PlayerPrefs.SetInt("Highscore", _score);
            //}
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level Select"); // get back to Level Selection screen and choose next Level. 
            }
        }
    }

    public void EventOnRingCrossed()
    {
        // way better than calling it in update frequently. 
        RingsPassed++;
        // Increase Score when the event occurs. 
        _score++;
        //_scoreText.SetText(_score.ToString()); 
        _scoreText.SetText("" + _score);
        int progress = RingsPassed * 100 / TotalRings;
        _sliderGameProgress.value = progress;
        //Debug.Log("Ring Bypassed = " + RingsPassed); 
    }
    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}
