using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	private Constants _constants;
	private References _references;
	private UnitRegister _register;

	public bool _isSelected = false;
	public TileController _onTile;
	public int _registerIndex;
	public GameObject _portrait;
	public Constants.FACTION _faction = Constants.FACTION.Neutral;


	public void PlaceUnit(TileController tc){

		//clear current tile
		if(_onTile != null) _onTile.Unit = null;

		//place in center of target tile
		gameObject.transform.position = new Vector3(tc.transform.position.x, tc.transform.position.y + tc.transform.localScale.y/2 + gameObject.transform.localScale.y/2, tc.transform.position.z);
		_onTile = tc;
		tc.Unit = this;
	}
		
	public void SetIndex(int i){

		_registerIndex = i;

	}

	public int GetIndex(){
		return _registerIndex;
	}

	public void SetFaction (Constants.FACTION f){
		_faction = f;
		SetColor ();
	}

	public Constants.FACTION GetFaction(){
		return _faction;
	}

	void Start () {

	}

	public void SetUpMembers(){
		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();
	}

	void SetColor(){
		switch (_faction) 
		{
		case Constants.FACTION.Friendly:
			gameObject.GetComponent<Renderer> ().material = _references.MATERIALS.FRIENDLY;
			break;
		case Constants.FACTION.Hostile:
			gameObject.GetComponent<Renderer> ().material = _references.MATERIALS.HOSTILE;
			break;
		default:
			gameObject.GetComponent<Renderer> ().material = _references.MATERIALS.NEUTRAL;
			break;

		}

	}

	public void SetSelected(bool s){
		_isSelected = s;
	}
		
	void OnMouseDown(){
		_register.SetSelected (this);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
