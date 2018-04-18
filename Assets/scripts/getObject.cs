using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObject : MonoBehaviour {
	//public bool selectedFlag;
	MoveToMouse targetScript;
	public Transform targetObj;
	public Transform pointer;
	public Transform aim;
	LineRenderer lineRenderer;
	LineRenderer aimRenderer;
	// Use this for initialization
	void Start () {
		targetScript = targetObj.GetComponent <MoveToMouse>();
		lineRenderer = pointer.GetComponent<LineRenderer> ();
		aimRenderer = aim.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		// this code show nameobject with click   
		if (Input.GetMouseButtonDown(0))
		{
			//empty RaycastHit object which raycast puts the hit details into
			RaycastHit hit;
			//ray shooting out of the camera from where the mouse is
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				//print out the name if the raycast hits something
				Debug.Log(hit.collider.name);
				//freeclup= hit.collider.name;
				Debug.Log (targetScript.selectedFlag);
				if (hit.collider.tag == "Player" && targetScript.selectedFlag== false) {
					targetScript.selectedFlag = true;
					Debug.Log (targetScript.selectedFlag + "should be true");
					lineRenderer.enabled = true;
				}
				else if (hit.collider.tag == "Player" && targetScript.selectedFlag== true) {
					targetScript.selectedFlag = false;
					Debug.Log (targetScript.selectedFlag + " should be false");
					lineRenderer.enabled = false;
				}
			}
		}

		if (Input.GetMouseButtonDown(1)) // aim ball
		{
			//empty RaycastHit object which raycast puts the hit details into
			RaycastHit hit;
			//ray shooting out of the camera from where the mouse is
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				//print out the name if the raycast hits something
				Debug.Log(hit.collider.name);
				//freeclup= hit.collider.name;
				Debug.Log (targetScript.selectedFlag);
				if (hit.collider.tag == "Player" && targetScript.selectedFlag== false) {
					targetScript.selectedFlag = true;
					Debug.Log (targetScript.selectedFlag + "should be true");
					aimRenderer.enabled = true;
				}
				else if (hit.collider.tag == "Player" && targetScript.selectedFlag== true) {
					targetScript.selectedFlag = false;
					Debug.Log (targetScript.selectedFlag + " should be false");
					aimRenderer.enabled = false;
				}
			}
		}
	}
}
