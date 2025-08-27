using UnityEngine;
using UnityEngine.VFX;

public class DoorControllerAdvanced : MonoBehaviour
{

    private Animator doorAnim;

    //for the polling aproach (see method aproach below)
    public bool openthedoor = false;
    public bool closethedoor = false;

    private VisualEffect trails;
    private AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorAnim = transform.GetComponent<Animator>();
        trails = transform.GetComponent<VisualEffect>();
        sound = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //example of using polling for bools
        if(openthedoor)
        {

            //tell animator to open door
            doorAnim.SetTrigger("OpenDoor");
            //vfx and sound are played the same!
            trails.Play();
            sound.Play();

            
            openthedoor = false;
        }

        if(closethedoor)
        {
            //tell animator to close door
            doorAnim.SetTrigger("CloseDoor");
            trails.Stop();

            closethedoor = false;
        }
    }
}
