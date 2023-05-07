using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public abstract class Spawnable : MonoBehaviour
{

    public float spawnRate = 1;
    protected float timeStampSpawn = 0;
    public GameObject toSpawn;
    public Transform spawnPoint;
    public Vector2 spread =Vector2.zero;
    public Vector2 spreadOffset = Vector2.zero;
    public bool armed = true;

    void Start()
    {
        spawnPoint = this.transform;
    }

    public virtual void SpawnStuff()
    {
        if (Time.time > timeStampSpawn && armed)
        {
            timeStampSpawn = Time.time + spawnRate;
            Vector3 randOffset = new Vector3((Random.value * spread.x) - spreadOffset.x,
                                              (Random.value * spread.y) - spreadOffset.y,
                                                0);
            Debug.Log("randoffset" + transform.position + randOffset);
            Spawn(randOffset);
        }
    }

    public virtual void Spawn(Vector3 offset)
    {
        Instantiate(toSpawn, spawnPoint.position + offset, spawnPoint.rotation);
    }


}
