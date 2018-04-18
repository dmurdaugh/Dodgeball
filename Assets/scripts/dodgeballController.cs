using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeballController : MonoBehaviour {

	public int ballState; //3 states: dead ball, carried, and live ball
	private GameObject owner;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ballState = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (ballState == 1) {//Deadball
			deadBall ();
		} else if (ballState == 2) {//Carriedball
			carryBall ();
		} else if (ballState == 3) {//liveBall
			liveBall ();
		}
	
	}

	void deadBall (){
		gameObject.tag = "DeadBall";
		owner = null; // once ball becomes dead it has now owner
	}

	void carryBall (){
		gameObject.tag = "Carry";
		gameObject.transform.position = new Vector3 (owner.transform.position.x+0.75f,owner.transform.position.y, owner.transform.position.z);
	}

	void liveBall(){
		gameObject.tag = "LiveBall";
	}

	public void populateOwnerInfo (GameObject player){
		owner = player; // once ball is picked up it has an owner. The ball will now attach to the owner during movement;
	}
}
