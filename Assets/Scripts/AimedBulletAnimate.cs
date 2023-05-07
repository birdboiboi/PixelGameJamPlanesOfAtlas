using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedBulletAnimate : AimedBullet
{
    public Animator anim;
    public AudioSource AudioSource;
    public AudioClip impact;
    public AudioClip fired;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        AudioSource.PlayOneShot(fired);

    }
    override public int getDmg()
    {
        AudioSource.PlayOneShot(impact);
        anim.Play("Hit Glass");
        return base.getDmg();

    }
}
