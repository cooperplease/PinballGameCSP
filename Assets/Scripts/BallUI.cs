using UnityEngine;
using TMPro;

public class BallUI : MonoBehaviour
{
    public static BallUI Instance;
    
    public TMP_Text ballText;
    private int ballCount = 1;


    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballText.text = "Ball " + ballCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ballText.text = "Ball " + ballCount.ToString();
    }

    public void BallIncrement()
    {
        ballCount++;
    }
}
