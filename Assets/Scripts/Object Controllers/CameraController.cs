using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	Constants _constants;
	References _references;
	UnitRegister _register;
	Vector3 _focusPoint;
	public float _focusLength;
	bool _focusNeedsUpdate = false;

	void Start () {

		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();

		_references.RegisterCamera (this);

		SetFocus ();
	}

	void Update () {
		
	}

	void LateUpdate() {
		if (_focusNeedsUpdate) {

			SetFocus ();
		}
	}
		
	
	public void CameraZoom(float zoomDirection){

		Vector3 tempPos = transform.position;

		float cameraRotation = transform.eulerAngles.x/90.0f;
		float cameraZWeight = (cameraRotation + 1.0f) * zoomDirection * _constants.CAMERA_ZOOM_MAGNITUDE;
		float cameraYWeight = cameraRotation * -1.0f * zoomDirection * _constants.CAMERA_ZOOM_MAGNITUDE;

		transform.Translate(new Vector3(0, cameraYWeight, cameraZWeight));

		float newLength = transform.localPosition.y / Mathf.Cos ((90 - transform.eulerAngles.x) * Mathf.Deg2Rad);

		if(newLength > _constants.CAMERA_MAX_ZOOM || newLength < _constants.CAMERA_MIN_ZOOM){
			transform.position = tempPos;
		}

		_focusNeedsUpdate = true;

	}

	public void CameraTranslateZ(float moveDirection){

		float holdHeight = transform.position.y;

		transform.Translate(new Vector3 (0, 0, 1 * moveDirection * _constants.CAMERA_MOVE_MAGNITUDE));
		transform.position = new Vector3 (transform.position.x, holdHeight, transform.position.z);

		_focusNeedsUpdate = true;

	}

	public void CameraTranslateX(float moveDirection){

		transform.Translate(new Vector3 (1 * moveDirection * _constants.CAMERA_MOVE_MAGNITUDE, 0, 0));

		_focusNeedsUpdate = true;

	}

	public void CameraHeight(float moveDirection){
		Vector3 tempPos = transform.position;
		Quaternion tempRot = transform.rotation;

		transform.Rotate (moveDirection * _constants.CAMERA_ROTATE_SPEED, 0, 0);
		transform.position = _focusPoint;
		transform.Translate (new Vector3(0, 0, -_focusLength)); 

		if (transform.rotation.eulerAngles.x < _constants.CAMERA_MIN_ROTATION || transform.rotation.eulerAngles.x > _constants.CAMERA_MAX_ROTATION) {
			transform.position = tempPos;
			transform.rotation = tempRot;
		}

		_focusNeedsUpdate = true;
	}

	public void CameraRotate(float rotateDirection){


		transform.RotateAround (_focusPoint, new Vector3 (0, 1, 0), -1.0f * rotateDirection * _constants.CAMERA_ROTATE_SPEED);

		_focusNeedsUpdate = true;

	}

	private void SetFocus(){

		_focusLength = transform.localPosition.y / Mathf.Cos ((90 - transform.eulerAngles.x) * Mathf.Deg2Rad);

		GameObject dummy = new GameObject();
		dummy.transform.position = this.transform.position;
		dummy.transform.rotation = this.transform.rotation;
		dummy.transform.localScale = dummy.transform.localScale * 5;
		dummy.transform.Translate (0, 0, _focusLength);

		_focusPoint = dummy.transform.position;

		Destroy (dummy);

		_focusNeedsUpdate = false;

	}

}
