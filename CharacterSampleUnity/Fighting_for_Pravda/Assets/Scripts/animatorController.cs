using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour {

	public Animator anim;

	public void punch0() {
		anim.setTrigger("isPunching0");
	}

	public void punch1() {
		anim.setTrigger("isPunching1");
	}

	public void kick0() {
		anim.setTrigger("isKicking0");
	}

	public void kick1() {
		anim.setTrigger("isKicking1");
	}

	public void dodge() {
		anim.setTrigger("isDodging");
	}

	public void getDamage() {
		anim.setTrigger("isGettingDamage");
	}

	public void die() {
		anim.setTrigger("isDying");
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
