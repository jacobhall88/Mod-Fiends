using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {

	public int HEX_SCALE;
	public int FIELD_HEIGHT;
	public int FIELD_WIDTH;
	public float CAMERA_MIN_ROTATION;
	public float CAMERA_MAX_ROTATION;
	public float CAMERA_MAX_HORIZONTAL;
	public float CAMERA_MAX_ZOOM;
	public float CAMERA_MIN_ZOOM;
	public float CAMERA_ZOOM_MAGNITUDE;
	public float CAMERA_MOVE_MAGNITUDE;
	public float CAMERA_ROTATE_SPEED;
	public enum FACTION{Friendly, Hostile, Neutral};
	public enum UISTATE{Attack, Move};

	// Use this for initialization
	void Start () {

		//register self with reference manager
		References refs = GameObject.Find ("ReferenceHolder").GetComponent<References>();
		refs.RegisterConstants (this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
