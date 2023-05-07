using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using static UnityEngine.ParticleSystem;

public class Character : MonoBehaviour
{
    public LineViewToggle LVT;
    public int myLineView;
    public Animator anim;
    public SpriteRenderer bust;


    private void Start()
    {
        
    }
    public void GreyOut()
    {
    }

    [YarnCommand("expression")]
    public void expression(string emotion)
    {
        LVT.SelectLineViews(myLineView);
        anim.Play(emotion);
    }
    

}
