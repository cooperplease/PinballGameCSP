using UnityEngine;

public class Bumper_Right : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float torque;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torque, ForceMode2D.Force);
        }else rb2d.AddTorque(torque, ForceMode2D.Force);
    }
}
