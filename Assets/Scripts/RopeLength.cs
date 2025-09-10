using GogoGaga.OptimizedRopesAndCables;
using UnityEngine;

public class RopeLength : MonoBehaviour
{
    public Rope rope;
    public CannonBall ball;
    
    // Update is called once per frame
    void Update()
    {
        if (ball.inAir)
            rope.ropeLength += Time.deltaTime * 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Debug.Log("ball hit");
            ball.inAir = false;
            rope.ropeLength = 2;
        }
        
    }
}
