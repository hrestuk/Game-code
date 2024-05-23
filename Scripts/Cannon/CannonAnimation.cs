using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimation: MonoBehaviour
{
    private Animation anim;
    private void Awake() 
    {
        anim = GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        anim.Play();
    }
}
