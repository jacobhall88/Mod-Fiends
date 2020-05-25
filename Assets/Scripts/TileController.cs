using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TileController : MonoBehaviour {

	Constants _constants;
	References _references;
	UnitRegister _register;

	//center of tile on which to place units
	Vector3 _unitPos;

	//unit currently on tile
	//private UnitController unit;
	public UnitController Unit {get; set;}

	//adjacint tiles, u = up, l = left, r = right, d = down
	public TileController ul = null;
	public TileController u = null;
	public TileController ur = null;
	public TileController l = null;
	public TileController r = null;
	public TileController dl = null;
	public TileController d = null;
	public TileController dr = null;

	//set point for unit to be placed at center of tile
	public void SetUnitPos (Vector3 pos){

		_unitPos = new Vector3 ( pos.x + (_constants.HEX_SCALE / 2), 0, pos.y + (_constants.HEX_SCALE /2));

	}

	public Vector3 GetUnitPos(){
		return _unitPos;
	}

	void OnMouseDown(){

		//confirm tile is empty
		if (Unit == null) {

			//confirm if a unit is selected, and cursor is not over a UI element
			if (_register.GetSelected () != null && !EventSystem.current.IsPointerOverGameObject ()) {

				//confirm a friendly unit is selected
				if (_register.GetSelected ().GetFaction () == Constants.FACTION.Friendly) {

					UnitController selected = _register.GetSelected ();
					selected.PlaceUnit (this);
				}
			}
		}
	}
	// Use this for initialization
	void Start () {
	
		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
