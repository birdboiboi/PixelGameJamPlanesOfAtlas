using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fly : Hitable
{
    public float speed;
    public float rot_speed;

    public float turbulanceAmplitude;
    public Vector2 turbulanceFreq;

    public Camera cam;
    public float porportion;

    public PlayerGun turrets;
    public Vector2 horizontalLimit = new Vector2(-60, 60);
    public Vector2 verticalLimit = new Vector2(-22, 120);



    private float timeStampFire = 0;


    //public Transform centerpoint;
  
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(fire());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion moment = Quaternion.identity;

        Vector3 turbulanceTranslate = turbulanceAmplitude * (Mathf.Sin(turbulanceFreq.x * Time.time) * transform.up
                                                    + Mathf.Sin(turbulanceFreq.y * Time.time) * transform.right);

        Vector3 turbulanceRotate = turbulanceAmplitude * (Mathf.Sin(turbulanceFreq.x * Time.time) * transform.right
                                                    + Mathf.Sin(turbulanceFreq.y * Time.time) * transform.forward);
        Vector3 move = Vector3.zero;
        moment = Quaternion.Euler((- (Input.GetAxis("Vertical") * transform.right* rot_speed)
                                    -Input.GetAxis("Horizontal") * transform.forward * rot_speed)*Time.deltaTime+turbulanceRotate);

        move += Input.GetAxis("Vertical") * transform.up + Input.GetAxis("Horizontal") * transform.right ;
        move += turbulanceTranslate;
        Quaternion scaledSubtraction = Quaternion.Slerp(
                                        cam.transform.rotation,
                                        moment,
                                        porportion * Time.deltaTime);
        Debug.Log("moment" + moment);
        cam.transform.rotation = (moment* scaledSubtraction);//* Quaternion.Inverse(scaledSubtraction));
        transform.Translate(move * speed * Time.deltaTime);
        if (Input.GetButton("Fire1"))
        {
            FireLogic();
        }
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, horizontalLimit.x, horizontalLimit.y),
                                            Mathf.Clamp(transform.position.y, verticalLimit.x, verticalLimit.y),
                                            0);


    }
    public virtual void FireLogic()
    {
        
        turrets.fire();
        
    }
    
    public override void Die()
    {
        /*
        Rigidbody rb = this.AddComponent<Rigidbody>();
        rb.AddForce(-Vector3.up);
        rb.AddTorque(transform.forward* rot_speed);
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        */
        base.Die();
    }

}
