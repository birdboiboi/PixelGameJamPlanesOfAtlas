using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedBullet : bullet
{
    public Vector3 aimDirection = Vector3.forward;
   
   
    public override void movement()
    {
#pragma warning disable UNT0024 // Give priority to scalar calculations over vector calculations
        transform.Translate(aimDirection * bulletSpeed * Time.deltaTime);
#pragma warning restore UNT0024 // Give priority to scalar calculations over vector calculations
        Debug.DrawLine(transform.position, aimDirection, Color.green);
        Destroy(gameObject, despawnTime);
    }
}
