using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed = 10.0f;
    public float turnspeed = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, turn * turnspeed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos += transform.forward * move * movespeed * Time.deltaTime;
        transform.position = pos;


    }
}
