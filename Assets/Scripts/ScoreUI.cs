using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance;
    
    public TMP_Text scoreText;
    private int currentScore = 0;


    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentScore++;
        }
    }

    public void ScoreIncrease(int num)
    {
        currentScore += num;
    }
}
