using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Hitable
{
    public Spawnable[] weapons;

   
    public override void Die()
    {
        disableAllGuns();
        base.Die();
    }

    void disableAllGuns()
    {
        foreach(Spawnable weapon in weapons)
        {
            weapon.armed = false;
        }
    }
    void armedAllGuns()
    {
        foreach (Spawnable weapon in weapons)
        {
            weapon.armed = true;
        }
    }



}
