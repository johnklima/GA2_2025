using UnityEngine;

public class FlameThrowerTrigger : MonoBehaviour
{
    public ParticleSystem[] flames;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for(int i = 0; i < flames.Length; i++)
            {
                flames[i].Stop();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < flames.Length; i++)
            {
                if (flames[i].isStopped)
                    flames[i].Play();
            }

        }
    }
}
