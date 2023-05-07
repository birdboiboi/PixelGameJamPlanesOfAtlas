using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Spawnable
{
    public Transform target;
    void Update()
    {
        
        
        Debug.DrawLine(transform.position, target.position);
        transform.LookAt(target);
        SpawnStuff();
    }

    public override void Spawn(Vector3 offset)
    {

        GameObject bull = Instantiate(toSpawn,
                    transform.position + offset,
                    transform.rotation);
        //bull.GetComponent<AimedBullet>().aimDirection = (transform.position - target.position).normalized;
        Debug.Log("fire" + bull.GetComponent<AimedBullet>().aimDirection + bull.name);
        Debug.DrawLine(transform.position, target.position,Color.red);


    }
}
