using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	Constants _constants;
	References _references;
	UnitRegister _register;

	public GameObject _unitFramesHolder;
	public Dictionary<GameObject, UnitController> _unitPortraits = new Dictionary<GameObject, UnitController>();


	// Use this for initialization
	void Start () {

		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();

		_references.RegisterUI (this);

	}

	public void BuildUnitFrame(){

		//scale _unitFramesHolder
		_unitFramesHolder = GameObject.Find ("UnitFrame"); 
		RectTransform frameRect = _unitFramesHolder.GetComponent<RectTransform> ();
		RectTransform uiRect = this.GetComponent<RectTransform> ();
		frameRect.sizeDelta = new Vector2 (uiRect.sizeDelta.x * .8f, uiRect.sizeDelta.y * .15f);
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
