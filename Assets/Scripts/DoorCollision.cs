using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    public PlayerController control;


    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "Player")
        {
            
            Vector3 back = control.transform.forward * -1;
            control.transform.position = back;   //move player back


        }

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            
        }

    }
}
