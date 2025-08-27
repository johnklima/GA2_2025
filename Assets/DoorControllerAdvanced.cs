using UnityEngine;

public class DoorControllerAdvanced : MonoBehaviour
{

    public Animator doorAnim;
    public bool openthedoor = false;
    public bool closethedoor = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(openthedoor)
        {
            doorAnim.SetTrigger("OpenDoor");
            //tell animator to open door
            openthedoor = false;
        }

        if(closethedoor)
        {
            //tell animator to close door
            doorAnim.SetTrigger("CloseDoor");
            closethedoor = false;
        }
    }
}
