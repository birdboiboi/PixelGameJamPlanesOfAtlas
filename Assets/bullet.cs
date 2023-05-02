using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed= 500;
    public float despawnTime = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * bulletSpeed*Time.deltaTime);
        Destroy(gameObject, despawnTime);
    }
}