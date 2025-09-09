using System.Net;
using UnityEngine;

public class GoFishing : MonoBehaviour
{

    public Transform ropeObj;
    public Camera fishCam;
    public bool isCast = false;

    public Transform endp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endp = ropeObj.GetChild(1);
    }

    // Update is called once per frame
    bool reelItIn = false;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            ropeObj.gameObject.SetActive(true);
            
            BallGravity body = endp.GetComponent<BallGravity>();


            if (!isCast)
            {
                Vector3 fwd = fishCam.transform.forward;
                body.impulse = (fwd * 10.0f + Vector3.up * 5.0f);
                endp.parent = null;

                isCast = true;

            }
            else
            {
                reelItIn = true;
            }

        }

        if(reelItIn)
        {

           

            //reel it in
            Vector3 pos1 = endp.position;
            Vector3 pos2 = transform.position;

            if (Vector3.Distance(pos1, pos2) < 0.1f)
            {
                //reparent
                endp.parent = ropeObj;
                //allow to cast again
                isCast = false;
                reelItIn = false;
                return;
            }

            endp.position = Vector3.Lerp(pos1, pos2, Time.deltaTime);


        }

    }
}
