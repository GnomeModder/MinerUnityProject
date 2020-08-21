using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCont : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		bool isMoving = Input.GetKey("a");
		bool isCrushing = Input.GetKey("s");

		anim.SetBool("isMoving", isMoving);
		if (isCrushing) { anim.SetTrigger("CrushAttack"); }
	}
}
