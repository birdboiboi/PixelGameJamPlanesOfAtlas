using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAnimationAudio : Fly
{
    
    public AudioClip shoot;
    public AudioClip die;

    
    public override void FireLogic()
    {
        //audioSource.PlayOneShot(shoot);
        base.FireLogic();
    }
    public override void Die()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(die);
        anim.SetBool("RaptureDieOut", true);
        base.Die();
    }
}
