using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float startX;
    public float startY;
    public float launchForce;
    private AudioSource audioSource;
    public AudioClip dinkClip;
    public AudioClip bounceClip;
    public AudioClip launchClip;
    public GameObject multiball;
    public bool ignoreLock = false;
    public bool reallyIgnoreLock = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(startX,startY,0);
        rb2d.AddForce(new Vector3(0,launchForce,0));
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(launchClip);
    }

    

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        if (rb2d.linearVelocity.magnitude > launchForce) rb2d.linearVelocity = rb2d.linearVelocity.normalized * launchForce;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bumper"))
        {
            audioSource.PlayOneShot(dinkClip);
        }else audioSource.PlayOneShot(bounceClip);
        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Cathedral") &&  !ignoreLock && reallyIgnoreLock == false)
        {
            rb2d.linearVelocity = Vector3.zero;
            rb2d.angularVelocity = 0f;
            rb2d.gravityScale = 0f;
            multiball.GetComponent<Multiball>().MultiballActivate();
            ignoreLock = true;
        }

        if (collision.CompareTag("Launcher"))
        {
            transform.position = new Vector3(startX, startY, 0);
            rb2d.linearVelocity = new Vector3(0, 0, 0);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb2d.AddForce(new Vector3(0, launchForce, 0));
                audioSource.PlayOneShot(launchClip);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            if (reallyIgnoreLock)
            {
                multiball.GetComponent<Multiball>().MultiballDeactivate(this.gameObject);
                Destroy(gameObject);
            }
            else
            {
                if (multiball.GetComponent<Multiball>().GetBallCount() < 4)
                {
                    BallUI.Instance.BallIncrement();
                    transform.position = new Vector3(startX, startY, 0);
                    rb2d.linearVelocity = new Vector3(0, 0, 0);
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        rb2d.AddForce(new Vector3(0, launchForce, 0));
                        audioSource.PlayOneShot(launchClip);
                    }

                    multiball.GetComponent<Multiball>().IncrementBalls();
                    Debug.Log(multiball.GetComponent<Multiball>().GetBallCount());
                }else SceneManager.LoadScene("Lose");

            }
        }
    }

    

    public float getX()
    {
        return transform.position.x;
    }

    public float getY()
    {
        return transform.position.y;
    }

    public void IgnoreLock()
    {
        ignoreLock = false;
        reallyIgnoreLock = true;
        rb2d.gravityScale = 2.5f;
    }

    public void SetMultiball(GameObject multiball)
    {
        this.multiball = multiball;
    }
}
