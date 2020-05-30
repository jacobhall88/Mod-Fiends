using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	Constants _constants;
	References _references;
	UnitRegister _register;

	public GameObject _unitFramesHolder;
	public GameObject _commandFrame;
	public Dictionary<GameObject, UnitController> _unitPortraits = new Dictionary<GameObject, UnitController>();

	//command buttons
	public GameObject _attack;
	public GameObject _move;


	// Use this for initialization
	void Start () {

		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();

		_references.RegisterUI (this);

	}

	//needs to be called after UnitFrame has been built
	public void BuildCommandFrame(){

		_commandFrame  = GameObject.Find ("CommandFrame");
		RectTransform commandRect = _commandFrame.GetComponent<RectTransform> ();

		//set command frame position and size
		RectTransform uiRect = this.GetComponent<RectTransform> ();
		commandRect.sizeDelta = new Vector2 (uiRect.sizeDelta.x * _constants.UNIT_FRAME_WIDTH, uiRect.sizeDelta.y * _constants.UNIT_FRAME_HEIGHT);
		commandRect.anchoredPosition = new Vector2 (0, _unitFramesHolder.GetComponent<RectTransform>().sizeDelta.y + commandRect.sizeDelta.y / 2);

		//create command buttons
		_attack = Instantiate (_references.COMMAND_BUTTON);
		Button attackButton = _attack.GetComponent <Button> ();
		Text[] attackButtonText = attackButton.GetComponentsInChildren <Text> ();
		attackButtonText [0].text = "Attack";

		_move = Instantiate (_references.COMMAND_BUTTON);
		Button moveButton = _move.GetComponent <Button> ();
		Text[] moveButtonText = moveButton.GetComponentsInChildren <Text> ();
		moveButtonText [0].text = "Move";

		// TEST CODE - Adding buttons to frame automatically instead of when a friendly unit is selected

		_attack.GetComponent <Button> ().GetComponent<RectTransform> ().parent = _commandFrame.GetComponent<RectTransform> ();

		_move.GetComponent <Button> ().GetComponent<RectTransform> ().parent = _commandFrame.GetComponent<RectTransform> ();

		// TEST CODE
	}

	public void BuildUnitFrame(){

		//scale _unitFramesHolder
		_unitFramesHolder = GameObject.Find ("UnitFrame"); 
		RectTransform frameRect = _unitFramesHolder.GetComponent<RectTransform> ();
		RectTransform uiRect = this.GetComponent<RectTransform> ();
		frameRect.sizeDelta = new Vector2 (uiRect.sizeDelta.x * _constants.UNIT_FRAME_WIDTH, uiRect.sizeDelta.y * _constants.UNIT_FRAME_HEIGHT);
		frameRect.anchoredPosition = new Vector2 (0, frameRect.sizeDelta.y / 2);
	
		//make button for each friendly unit
		foreach (UnitController unit in _register.GetRegister()) {

			if (unit.GetFaction () == Constants.FACTION.Friendly) {

				//create button
				GameObject unitFrame = Instantiate (_references.MASTER_UNIT_FRAME);
				Button unitFrameButton = unitFrame.GetComponent<Button> ();

				//name button
				Text[] buttonText = unitFrameButton.GetComponentsInChildren <Text> ();
				buttonText[0].text = "Friendly Unit";

				//add listener
				unitFrameButton.onClick.AddListener (delegate {
					SelectUnit (unitFrame);
				});

				//add to frame holder
				unitFrame.transform.SetParent (_unitFramesHolder.transform);
				_unitPortraits.Add (unitFrame, unit);
			}
		}

	}

	public void SelectUnit(GameObject portrait){

		_register.SetSelected (_unitPortraits [portrait]);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
