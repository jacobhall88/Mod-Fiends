using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	Constants _constants;
	References _references;
	UnitRegister _register;
	// Use this for initialization
	void Start () {
	
		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Zoom") != 0) {
			_references.CAMERA_CONTROLLER.CameraZoom (Input.GetAxis ("Zoom"));
		}

		if (Input.GetAxis("CameraZ") != 0){
			_references.CAMERA_CONTROLLER.CameraTranslateZ (Input.GetAxis("CameraZ"));
		}

		if (Input.GetAxis("CameraX") != 0){
			_references.CAMERA_CONTROLLER.CameraTranslateX (Input.GetAxis("CameraX"));
		}

		if (Input.GetAxis ("CameraRotate") != 0) {
			_references.CAMERA_CONTROLLER.CameraRotate (Input.GetAxis ("CameraRotate"));
		}
			
		if (Input.GetAxis ("CameraHeight") != 0) {
			_references.CAMERA_CONTROLLER.CameraHeight (Input.GetAxis ("CameraHeight"));
		}
	}
}
