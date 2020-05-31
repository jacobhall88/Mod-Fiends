using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public interface IAttack{

	int Damage { get; set; }
	int Range { get; set; }
	ATYPE Atype { get; }

	void OnAttack(UnitController[] targets);
}
