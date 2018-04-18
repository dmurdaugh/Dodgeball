using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MoveToClickPoint.cs
using UnityEngine.AI;

public class MoveToMouse : MonoBehaviour {
	NavMeshAgent agent;
	Vector3 destination;
	public bool selectedFlag;
	public Transform pointer;
	LineRenderer lineRenderer;
	public Vector3[]  destinations = new Vector3[3];
	public Transform PUBall;
	private Rigidbody rb;
	int step;
	dodgeballController ballScript;
	void Start() {
		agent = GetComponent<NavMeshAgent>();
		lineRenderer = pointer.GetComponent<LineRenderer> ();
		rb = GetComponent<Rigidbody>();

	}

	void Update() {
		rb.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
		if (selectedFlag == true) {
			//Debug.Log( agent.remainingDistance);
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;

				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
					destination = hit.point;
					destination.y+=0.1f;
					//agent.destination = destination;
					//Debug.Log (agent.destination + " vs. " + destination);
				}
//				if (agent.remainingDistance <= .01f) { //Seems to always turn it off unless you reselect the player
//					Debug.Log ("Done");
//					selectedFlag = false;
//					lineRenderer.enabled = false;
//				}
			}
		}

		if(Input.GetKeyDown ("space")){
			Debug.Log ("space key pressed");
			agent.destination = destination;
			selectedFlag = false;
			lineRenderer.enabled = false;
		}
	}

	void endTurnMove(){
		Input.GetKeyDown ("space");
		agent.destination = destination;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("collision detected");
		if (other.gameObject.CompareTag ("DeadBall")) {
			SpawnPUBall (other.gameObject);
			//Destroy (other.gameObject);
		}
	}

	void SpawnPUBall (GameObject ball){
		Debug.Log (gameObject);
		var newTrans = GetComponent<Transform>();
		Vector3 playerPos = newTrans.position;
		Debug.Log (playerPos.x + " " + playerPos.y + " " + playerPos.z + " ");
		//Instantiate(PUBall, new Vector3(playerPos.x-0.33f, playerPos.y, playerPos.z+0.72f), Quaternion.identity);
		ballScript=ball.GetComponent <dodgeballController>();
		ballScript.populateOwnerInfo (gameObject);
		ballScript.ballState = 2;
	}
}

