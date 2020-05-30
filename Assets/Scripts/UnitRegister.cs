using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitRegister : MonoBehaviour {

	Constants _constants;
	References _references;
	int _numUnits = 0;
	public UnitController _selected;

	List<UnitController> _unitList = new List<UnitController>();

	// Use this for initialization
	void Start () {
		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();

		_references.RegisterUnitRegister (this);

	}

	//move currently selected unit to parameter tile
	public void MoveSelected(TileController tc){
		_selected.PlaceUnit (tc);
	}

	public List<UnitController> GetRegister(){
		return _unitList;
	}

	public void Register(UnitController uc){
		_unitList.Insert (_numUnits, uc);
		uc.SetIndex (_numUnits);
		_numUnits++;
	}

	public void Remove(UnitController uc){
		if (_selected.GetIndex () == uc.GetIndex()) ClearSelected();
		_unitList.RemoveAt (uc.GetIndex ());
	}

	public void SetSelected(UnitController uc){

		if (_references.UI_CONTROLLER.UIState != Constants.UISTATE.Attack) {
			if (_selected != null)
				_selected.SetSelected (false); 
			_selected = uc;
			_selected.SetSelected (true);
			_references.UI_CONTROLLER.ClearCommands ();

			//show command frame if friendly, hide otherwise
			switch (uc.GetFaction ()) {
			case Constants.FACTION.Friendly:
				_references.UI_CONTROLLER.ShowCommandFrame ();
				break;
			case Constants.FACTION.Hostile:
				_references.UI_CONTROLLER.HideCommandFrame ();
				break;
			case Constants.FACTION.Neutral:
				_references.UI_CONTROLLER.HideCommandFrame ();
				break;
			}
		}
		//using else if to accomodate potential future UI states
		else if (_references.UI_CONTROLLER.UIState == Constants.UISTATE.Attack) {
			if (uc.GetFaction () != Constants.FACTION.Friendly) {
				_references.UI_CONTROLLER.AttackTarget = uc;
			}
		}
	}

	public UnitController GetSelected(){
		return _selected;
	}

	public void ClearSelected(){
		_selected = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
