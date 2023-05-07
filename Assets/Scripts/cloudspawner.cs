using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudspawner : Spawnable
{
    
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
        SpawnStuff();
    }

   
}
