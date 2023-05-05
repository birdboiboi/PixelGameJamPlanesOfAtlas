using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public Animator anim;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " " + other.gameObject.tag + "hit" + (other.transform.forward - transform.forward).magnitude );
        if (other.gameObject.tag == "Bullet" && (other.transform.forward-transform.forward).magnitude >1)
        {
            other.transform.SetParent(transform);
            TakeDmg(other.gameObject.GetComponent<bullet>().getDmg());
            
        }
    }
    public void TakeDmg(int getDmg)
    {
        health -= getDmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this);
    }

}
