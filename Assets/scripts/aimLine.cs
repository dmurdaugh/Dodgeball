using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimLine : MonoBehaviour {
	LineRenderer lineRenderer;
	public Transform destination;
	Camera thisCamera;

	void Start(){
		thisCamera = Camera.main;
		lineRenderer = GetComponent<LineRenderer> ();

	}
	void Update(){
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Input.mousePosition.y;
		mousePos.y=0;
		mousePos= thisCamera.ScreenToWorldPoint (Input.mousePosition);
		lineRenderer.SetPosition (1, mousePos);
		lineRenderer.SetPosition (0, destination.position);

	}

}