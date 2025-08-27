using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public DoorControllerAdvanced doorhinge;

    private bool isNearDoor = false;

    public float timer = -1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            doorhinge.openthedoor = true;
            //get what time we opened the door
            timer = Time.time;
        }

        //wait until 7 seconds has passed
        if(Time.time - timer > 7.0f  && timer > 0)
        {
            doorhinge.closethedoor = true;
            //reset timer
            timer = -1;
        }

    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        //BAD SUSHI
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E) )
        {
            doorhinge.openthedoor = true;
        }
    }
    */

    private void OnTriggerStay(Collider other)
    {
        //GOOD SUSHI
        if (other.tag == "Player" )
        {
            isNearDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isNearDoor = false;
        }
    }
}
