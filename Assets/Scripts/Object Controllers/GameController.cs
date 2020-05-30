using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int FIELD_HEIGHT;
	public int FIELD_WIDTH;

	public GameObject _fieldGameObject;
	private PlayFieldController _field;
	private Constants _constants;
	private References _references;

	void Start () {

		//initialize constants
		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_references.RegisterGameController (this);

		FIELD_HEIGHT = _constants.FIELD_HEIGHT;
		FIELD_WIDTH = _constants.FIELD_WIDTH;

		//initialize play field
		_field = Instantiate (_fieldGameObject.GetComponent<PlayFieldController> ());
		_field.SetUpMembers ();
		_field.BuildField (_constants.FIELD_HEIGHT, _constants.FIELD_WIDTH);
		_field.TestUnitPlacement ();
		_references.UI_CONTROLLER.BuildUnitFrame();
		_references.UI_CONTROLLER.BuildCommandFrame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
