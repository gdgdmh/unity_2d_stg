using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStgEnemyFactory {
	public abstract GameObject Create(StgEnemyConstant.Type type);
}
