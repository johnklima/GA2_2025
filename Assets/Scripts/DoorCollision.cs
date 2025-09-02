using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    AudioSource bonk;

    private void Start()
    {
       bonk = transform.GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "Player")
        {
            Debug.Log("bonk");
            bonk.Play();
        }

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

            
        }

    }
}
