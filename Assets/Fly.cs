using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fly : MonoBehaviour
{
    public float speed;
    public float rot_speed;

    public Camera cam;
    public float porportion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion moment = Quaternion.identity;
        Vector3 move = Vector3.zero;
        moment = Quaternion.Euler((- (Input.GetAxis("Vertical") * transform.right* rot_speed) -Input.GetAxis("Horizontal") * transform.forward * rot_speed));
        move += Input.GetAxis("Vertical") * transform.up + Input.GetAxis("Horizontal") * transform.right;

        Quaternion scaledSubtraction = Quaternion.Slerp(
                                        cam.transform.rotation,
                                        moment,
                                        porportion);
        Debug.Log("moment" + moment);
        cam.transform.rotation = (moment* scaledSubtraction);//* Quaternion.Inverse(scaledSubtraction));
        transform.Translate(move * speed * Time.deltaTime);

    }
}
