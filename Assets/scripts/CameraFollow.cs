using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float rotationSensitivity = 5;
	public Transform target;
	private Vector3 offset;

	private float rotationSpeed = 1f;
	private float minY = -60f;
	private float maxY = 60f;
	private float rotationY = -30f;
	private float rotationX = 0f;
	private float zoomInOutSpeed = 20f;
	private float speed = 5.0f;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		/* Camera follows the target */
		//transform.LookAt(target, Vector3.up);
		transform.position = target.position + offset;

		/* Camera rotation */
		Vector3 v3 = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0f);
		transform.Rotate(v3 * speed * Time.deltaTime); 
		rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed * rotationSensitivity;
		rotationY += Input.GetAxis("Mouse Y") * rotationSpeed * rotationSensitivity;
		rotationY = Mathf.Clamp(rotationY, minY, maxY);
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		/* Camera zoom in & zoom out */
		float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
		if(scrollWheel != 0) {
			transform.position += transform.forward * scrollWheel * zoomInOutSpeed * Time.deltaTime;
			offset = transform.position - target.position;
		}
	}
}




