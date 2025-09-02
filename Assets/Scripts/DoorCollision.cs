using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    public PlayerController control;


    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "Player")
        {
            control.enableControl(false);
            Vector3 previous = control.getPrevPos();  //get last known good
            Vector3 back = control.transform.forward * -1;
            control.transform.position = previous + back;   //move player back


        }

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            control.enableControl(true);
        }

    }
}
