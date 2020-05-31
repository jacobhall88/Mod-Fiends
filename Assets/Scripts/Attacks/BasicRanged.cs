using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class BasicRanged : MonoBehaviour, IAttack {

	public int ATTACK_DAMAGE;
	public int RANGE;
	public ATYPE ATTACK_TYPE;

	public int Damage { 
		get { return ATTACK_DAMAGE; }
		set { ATTACK_DAMAGE = value; }
	}

	public int Range { 
		get { return RANGE; }
		set { RANGE = value; }
	}

	public ATYPE Atype { get{ return ATTACK_TYPE; } }

	public void OnAttack(UnitController[] targets){}
		

}
