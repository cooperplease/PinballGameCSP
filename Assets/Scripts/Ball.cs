using System;
using UnityEngine;

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
        if (transform.position.y <= -18.73)
        {
            transform.position = new Vector3(startX,startY,0);
            rb2d.linearVelocity = new Vector3(0, 0, 0);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb2d.AddForce(new Vector3(0,launchForce,0));
                audioSource.PlayOneShot(launchClip);
            }
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bumper"))
        {
            audioSource.PlayOneShot(dinkClip);
        }else audioSource.PlayOneShot(bounceClip);
    }
}
