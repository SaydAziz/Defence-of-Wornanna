using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text txt_score;
    [SerializeField] private TMP_Text txt_Hscore;

    public static GameManager Instance { get; private set;}

    private int _Score;
    public int Score
    {
        get { return _Score; }
    }


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance !=null && Instance != this)
        {
            Destroy(this);   //basic singleton pattern
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _Score = 0;
    }

    void Update()
    {
        txt_score.text = "Score: " + _Score.ToString();           //leep UI updated
        txt_Hscore.text = "Highscore: " + _Score.ToString();

    }
    
    public void EndGameLoop()
    {
        Time.timeScale = 0;       //pauses game and turns on menu
        menu.SetActive(true);
    }

    public void AddScore(int scoreAmount)
    {
        _Score += scoreAmount;
    }
}
