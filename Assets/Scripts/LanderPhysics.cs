using System;
using UnityEngine;


public class LanderPhysics : MonoBehaviour
{

    public float inertia = 1;  //a constant depending on shape of object, just going to assume 1 to start
                               //seems it's just something that is part of the equation

    public Vector3 AngularVelocity;

    public Vector3 velocity = new Vector3(0, 0, 0);             //current direction and speed of movement
    public Vector3 acceleration = new Vector3(0, 0, 0);         //movement controlled by player movement force and gravity

    public Vector3 impulse = new Vector3(0, 0, 0);              //additional explosive force
    public Vector3 thrust = new Vector3(0, 0, 0);               //player applied thrust vector
    public Vector3 finalForce = new Vector3(0, 0, 0);           //final force to be applied this frame
    
    public float mass = 1.0f;
    public float GRAVITY = -1.6f;                      // -9.8 for earth,  -1.6 for moon 

    enum Thruster
    {
        LEFT,
        RIGHT,
        FRONT,
        BACK,
        CENTER,
    }
    //pre-allocated 5 thrusters, to be placed on the craft where you see fit (have fun!)
    //you may not need all of them, depending on how you style your game. A single
    //center thruster, with angular control can be enough to move in 3d space
    public Transform[] thrusters = new Transform[5];            //locations
    public float[] thrustForce = new float[] { 0,0,0,0,0 };     //current force

    //You will need to create an input mapping as you see fit. WASD and Space should be enough
    //You will also need to make a camera of some sort
    //You CAN use a rigid body in KINEMATIC mode with no gravity to handle box triggers.
    //You will need to create a 2 GUI indicating fuel consumption
    //Your ship has limited fuel, so the player may consume it all and crash

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

        //do rotation first, translation second

        //torque, or angular acceleration, or spin, same thing
        Vector3 torque = Vector3.zero;

        for(int i = 0; i < thrusters.Length; i++)
        {
            if(thrusters[i])
            {
                //get offset vector from center of mass
                Vector3 r = thrusters[i].position - transform.position;
                //mult by current thrust force
                torque += Vector3.Cross(r, thrusters[i].forward) * thrustForce[i] ;  
            }
            
        }


        Vector3 angAcceleration = torque / inertia; //this constant can simply be 1

        AngularVelocity += angAcceleration * Time.deltaTime * Time.deltaTime;  //dt squared

        //yeah yeah deprecated, but we are working in radians at the moment
        transform.rotation = transform.rotation * Quaternion.EulerAngles(AngularVelocity);
        
       
        //reset final force to the initial force of gravity
        finalForce.Set(0, GRAVITY, 0);  


        for(int i = 0; i < thrusters.Length;i++)
        {
            if (thrusters[i])
            {
                //add our thrust vectors, mult by scalar (0 would be no thrust on a thruster)
                thrust += thrusters[i].forward * thrustForce[i];  

            }
        }


        finalForce += thrust;

        acceleration = finalForce / mass;
        velocity += acceleration * Time.deltaTime;

        //if we want an explosion that instantly pushes the lander
        //can simply be zero for no impulse
        velocity += impulse;  

        //move the object
        transform.position += velocity * Time.deltaTime;

        //impulse is a one time force, so zero it
        impulse = Vector3.zero;


    }

    
}
