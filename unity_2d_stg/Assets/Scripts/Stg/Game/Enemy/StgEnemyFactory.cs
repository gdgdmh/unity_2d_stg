using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyFactory : AStgEnemyFactory {

	public StgEnemyFactory(GameObject player) {
		this.player = player;
		StgPlayer playerScript = this.player.GetComponent<StgPlayer>();
		MhCommon.Assert(playerScript != null, "StgEnemyFactory::StgEnemyFactory() playerScript null");
	}

	public override GameObject Create(StgEnemyConstant.Type type) {
		if (type == StgEnemyConstant.Type.kEnemyNormal) {
			GameObject enemy = (GameObject)Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kNormalEnemyPrefab));
			MhCommon.Assert(enemy != null, "StgEnemyFactory::Create() kEnemyNormal null");
			return enemy;
        } else if (type == StgEnemyConstant.Type.kStraightMoveEnemy) {
			GameObject enemy = (GameObject)Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kStraightMoveEnemyPrefab));
			MhCommon.Assert(enemy != null, "StgEnemyFactory::Create() kNormalEnemyPrefab null");
			return enemy;
		} else {
			MhCommon.Assert(false, "StgEnemyFactory::Create() StgEnemyConstant.Type invalid type=" + type);
			return null;
		}
	}

	public override GameObject Create(StgEnemyConstant.Type type, StgStageJsonEnemyItemDropDatas itemDropDatas) {
		NormalEnemy normalEnemy = null;
		if (type == StgEnemyConstant.Type.kEnemyNormal) {
			GameObject enemy = (GameObject)Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kNormalEnemyPrefab));
			MhCommon.Assert(enemy != null, "StgEnemyFactory::Create() kEnemyNormal null");
			enemy = Object.Instantiate(enemy);

			normalEnemy = enemy.GetComponent<NormalEnemy>();
			StgItemMultiDropper dropper = new StgItemMultiDropper();
			for (int i = 0; i < itemDropDatas.GetCount(); ++i) {
				StgStageJsonEnemyItemDropData dropData = itemDropDatas.Get(i);
				dropper.SetParameter(dropData.Offset, dropData.Type);
			}
			dropper.Print();
			normalEnemy.SetItemDropper(dropper);
			/*
					NormalEnemy enemyBase = enemy.GetComponent<NormalEnemy>();
					StgItemMultiDropper dropper = new StgItemMultiDropper();
					for (int i = 0; i < launchData.enemyItemDropDatas.GetCount(); ++i) {
						StgStageJsonEnemyItemDropData dropData = launchData.enemyItemDropDatas.Get(i);
						dropper.SetParameter(dropData.Offset, dropData.Type);
					}
					dropper.Print();
					enemyBase.SetItemDropper(dropper);

			*/

			return enemy;
		} else if (type == StgEnemyConstant.Type.kStraightMoveEnemy) {
			GameObject enemy = (GameObject)Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kStraightMoveEnemyPrefab));
			MhCommon.Assert(enemy != null, "StgEnemyFactory::Create() kNormalEnemyPrefab null");
			enemy = Object.Instantiate(enemy);
			return enemy;
		} else {
			MhCommon.Assert(false, "StgEnemyFactory::Create() StgEnemyConstant.Type invalid type=" + type);
			return null;
		}

	}

	protected GameObject player;
	protected StgPlayer playerScript;
}
