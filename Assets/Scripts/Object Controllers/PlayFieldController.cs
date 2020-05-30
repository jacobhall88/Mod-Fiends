using UnityEngine;
using System.Collections;

public class PlayFieldController : MonoBehaviour {

	public int FIELD_HEIGHT;
	public int FIELD_WIDTH;

	private int _fieldHeight;
	private int _fieldWidth;
	public TileController[,] _field;
	private References _references;
	private Constants _constants;
	private UnitRegister _register;

	public float HEXSCALE;

	void Start () {



	}

	// Update is called once per frame
	void Update () {
	}

	public void SetUpMembers(){
		_constants = GameObject.Find ("ConstantsHolder").GetComponent<Constants> ();
		HEXSCALE = _constants.HEX_SCALE;
		_references = GameObject.Find ("ReferenceHolder").GetComponent<References> ();
		_references.RegisterPlayFieldController (this);
		_register = GameObject.Find ("UnitRegisterHolder").GetComponent<UnitRegister> ();
	}

	public int GetHeight() { return _fieldHeight; }
	public int GetWidth() { return _fieldWidth; }

	public void BuildField (int h, int w){
		_fieldHeight = h;
		FIELD_HEIGHT = h;
		_fieldWidth = w;
		FIELD_WIDTH = w;

		//build tiles
		_field = new TileController[_fieldHeight, _fieldWidth];
		for(int height = 0; height<_fieldHeight; height++){
			for (int width = 0; width < _fieldWidth; width++) {

				//create tile and place tile
				TileController tile = Instantiate (_references.MASTER_TILE).GetComponent<TileController> ();
				tile.transform.position = new Vector3 (height * HEXSCALE + height *.01f, 0, width * HEXSCALE + width*.01f);
				tile.transform.localScale = new Vector3(HEXSCALE, 1, HEXSCALE);

				//register tile with the field
				_field [height, width] = tile;

				//register adjacent tiles

				if (height > 0) {
					tile.u = _field [height - 1, width];
					tile.u.d = tile;
					if (width > 0) {
						tile.ul = _field [height - 1, width - 1];
						tile.ul.dr = tile;
					}
					if (width < _fieldWidth - 1) {
						tile.ur = _field [height - 1, width + 1];
						tile.ur.dl = tile;
					}
				}
				if (width > 0) {
					tile.l = _field [height, width - 1];
					tile.l.r = tile;
				}
						
			}
		}

		_references.RegisterTiles (_field);
	}

	public void TestUnitPlacement(){
		
		GameObject testUnitObject = Instantiate (_references.MASTER_UNIT);
		UnitController testUnit = testUnitObject.GetComponent<UnitController> ();
		testUnit.SetUpMembers ();
		testUnit.PlaceUnit (_field [1, 1]);
		testUnit.SetFaction (Constants.FACTION.Friendly);
		_register.Register (testUnit);
		testUnitObject = Instantiate (_references.MASTER_UNIT);
		testUnit = testUnitObject.GetComponent<UnitController> ();
		testUnit.SetUpMembers ();
		testUnit.PlaceUnit (_field [1, 2]);
		testUnit.SetFaction (Constants.FACTION.Friendly);
		_register.Register (testUnit);
		testUnitObject = Instantiate (_references.MASTER_UNIT);
		testUnit = testUnitObject.GetComponent<UnitController> ();
		testUnit.SetUpMembers ();
		testUnit.PlaceUnit (_field [1, 3]);
		testUnit.SetFaction (Constants.FACTION.Hostile);
		_register.Register (testUnit);
		testUnitObject = Instantiate (_references.MASTER_UNIT);
		testUnit = testUnitObject.GetComponent<UnitController> ();
		testUnit.SetUpMembers ();
		testUnit.PlaceUnit (_field [2, 1]);
		testUnit.SetFaction (Constants.FACTION.Neutral);
		_register.Register (testUnit);

	}
}