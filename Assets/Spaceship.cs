using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public Transform thruster0;
    public Transform thruster1;
    public Transform Ship;
    public float inertia = 1;  //a constant depending on shape of object, just going to assume 1 to start

    //just to represent the magnitude of the force
    private Transform thrust0mag;
    private Transform thrust1mag;

    public Vector3 AngularVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //just to represent the magnitude of the force
        thrust0mag = thruster0.GetChild(0);
        thrust1mag = thruster1.GetChild(0);

        //at start we have equal opposite forces equally offset from center of mass
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 torque = Vector3.zero;

        Vector3 r = thruster0.position - Ship.position;
        torque += Vector3.Cross(r, thruster0.forward);

        r = thruster1.position - Ship.position;
        torque += Vector3.Cross(r, thruster1.forward);

        Vector3 angAcceleration = torque / inertia;

        AngularVelocity += angAcceleration * Time.deltaTime;

        Ship.rotation *= Quaternion.Euler(AngularVelocity);


    }
}
