using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bouncer : MonoBehaviour
{

    private int scaleTimer = 0;
    private int scaleThresh = 10;
    private bool isScaled = false;

    private float scaleX = 0;
    private float scaleY = 0;

    [SerializeField] private int pointVal;
    [SerializeField] private TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            
                
                
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            
            //transform.localScale = new Vector3(1.1f, 1.1f, 1f);
            //transform.parent.localScale = new Vector3(1.1f, 1.1f, 1f);
            ScoreUI.Instance.ScoreIncrease(pointVal);

        }
        ScoreUI.Instance.ScoreIncrease(pointVal);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            /*transform.localScale = new Vector3(scaleX, scaleY, 1f);
            transform.parent.localScale = new Vector3(1f, 1f, 1f);
            */
        }
    }
}
