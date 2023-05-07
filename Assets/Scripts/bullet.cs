using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed= 500;
    public float despawnTime = 5;
    public int dmg = 1;
    public float stickDuration = 0;
    

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public virtual void movement()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, despawnTime);
    }

    public virtual int getDmg()
    {
        bulletSpeed = 0;
        Destroy(this.gameObject, stickDuration);
        return dmg;
    }

}
