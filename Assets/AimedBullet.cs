using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedBullet : bullet
{
    public Vector3 aimDirection = Vector3.forward;
    // Start is called before the first frame update

 
    // Update is called once per frame
   
    public override void movement()
    {
        transform.Translate(aimDirection * bulletSpeed * Time.deltaTime);
        Debug.DrawLine(transform.position, aimDirection, Color.green);
        Destroy(gameObject, despawnTime);
    }
}
