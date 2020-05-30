using UnityEngine;
using System.Collections;

public class References : MonoBehaviour {


	public Constants CONSTANTS;
	public GameController GAME_CONTROLLER;
	public PlayFieldController PLAY_FIELD_CONTROLLER;
	public TileController[,] TILES;
	public GameObject MASTER_TILE;
	public GameObject MASTER_UNIT;
	public GameObject MASTER_UNIT_FRAME;
	public GameObject COMMAND_BUTTON;
	public UnitRegister UNIT_REGISTER;
	public CameraController CAMERA_CONTROLLER;
	public UIController UI_CONTROLLER;
	public Materials MATERIALS;

	public void RegisterMaterial(Materials m){
		MATERIALS = m;
	}

	public void RegisterConstants(Constants c){
	
		CONSTANTS = c;

	}

	public void RegisterUI(UIController u){

		UI_CONTROLLER = u;

	}

	public void RegisterGameController(GameController gc){

		GAME_CONTROLLER = gc;

	}

	public void RegisterPlayFieldController(PlayFieldController pfc){

		PLAY_FIELD_CONTROLLER = pfc;

	}

	public void RegisterTiles(TileController[,] tc){

		TILES = tc;

	}

	public void RegisterUnitRegister(UnitRegister ur){

		UNIT_REGISTER = ur;
	
	}

	public void RegisterCamera(CameraController c){

		CAMERA_CONTROLLER= c;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
