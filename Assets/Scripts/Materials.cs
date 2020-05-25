using UnityEngine;
using System.Collections;

public class Materials : MonoBehaviour {

	public Material FRIENDLY;
	public Material HOSTILE;
	public Material NEUTRAL;

	// Use this for initialization
	void Start () {
		GameObject.Find ("ReferenceHolder").GetComponent<References> ().RegisterMaterial(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
