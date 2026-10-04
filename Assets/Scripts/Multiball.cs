using System.Collections;
using UnityEngine;

public class Multiball : MonoBehaviour
{
    private int lockNum = 0;
    private int numBalls = 0;
    [SerializeField] float startX;
    public float startY;
    [SerializeField] GameObject ballPrefab;
    private ArrayList ballList = new ArrayList();
    private int ballCount =2;

    private bool isMultipleBalls = false;
    //private Vector3 spawnPos = new Vector3(startX, startY, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballList.Add(Object.Instantiate(ballPrefab,new Vector3(startX, startY, 0), Quaternion.identity));
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ball in ballList)
        {
            ball.GetComponent<Ball>().SetMultiball(this.gameObject);
        }

        if (numBalls <= 1 && isMultipleBalls)
        {
            foreach (GameObject ball in ballList)
            {
                
                ball.GetComponent<Ball>().reallyIgnoreLock = false;
                ball.GetComponent<Ball>().ignoreLock = false;
                isMultipleBalls = false;
            }
        }

        
    }

    public void MultiballActivate()
    {
        lockNum++;
        numBalls++;
        if (lockNum >= 3)
        {
            foreach (GameObject ball in ballList)
            {
                ball.GetComponent<Ball>().IgnoreLock();
                Debug.Log("multiball");
            }

            isMultipleBalls = true;
            lockNum = 0;
            ScoreUI.Instance.ScoreIncrease(500);
        }else
        {
            ballList.Add(Object.Instantiate(ballPrefab, new Vector3(startX, startY, 0), Quaternion.identity));
            Debug.Log("multiball++");
            ScoreUI.Instance.ScoreIncrease(200);
        }
    }

    public void MultiballDeactivate(GameObject remove)
    {
        
            ballList.Remove(remove);
            numBalls--;

    }

    public void IncrementBalls()
    {
        ballCount++;
        Debug.Log(ballCount);
    }

    public int GetBallCount()
    {
        return ballCount;
    }


}
