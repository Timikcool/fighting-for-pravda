using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour {

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void punch0()
    {
        anim.SetTrigger("isPunching0");
    }

    public void punch1()
    {
        anim.SetTrigger("isPunching1");
    }

    public void kick0()
    {
        anim.SetTrigger("isKicking0");
    }

    public void kick1()
    {
        anim.SetTrigger("isKicking1");
    }

    public void dodge()
    {
        anim.SetTrigger("isDodging");
    }

    public void getDamage()
    {
        anim.SetTrigger("isGettingDamage");
    }

    public void die()
    {
        anim.SetTrigger("isDying");
    }


    

    // Update is called once per frame
    void Update()
    {

    }
}
