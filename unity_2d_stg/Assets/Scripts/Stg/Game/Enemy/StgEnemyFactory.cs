using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyFactory : AStgEnemyFactory {

	public StgEnemyFactory(GameObject player) {
		this.player = player;
	}

	public override GameObject Create(StgEnemyConstant.Type type) {
		if (type == StgEnemyConstant.Type.kEnemyNormal) {
			GameObject enemy = (GameObject)Resources.Load("Prefabs/Game/Enemy/Enemy1");
			MhCommon.Assert(enemy != null, "StgEnemyFactory::Create() kEnemyNormal null");
			return enemy;
		} else {
			MhCommon.Assert(false, "StgEnemyFactory::Create() StgEnemyConstant.Type invalid type=" + type);
			return null;
		}
	}

	protected GameObject player;
}
