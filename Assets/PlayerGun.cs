using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Spawnable
{
    public Transform[] guns;

    public override void Spawn(Vector3 offset)
    {
        foreach (Transform gun in guns)
        {
            Instantiate(toSpawn, gun.position + offset, gun.rotation);
        }
    }

    public void fire()
    {
        SpawnStuff();
    }
}
