using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵をランダムに出現させる
/// </summary>
public class StgEnemyRandomPopper : MonoBehaviour, IStgEnemyAppearable {
	
	StgEnemyRandomPopper() {
	}

	public void SetPlayer(GameObject player) {
		this.player = player;
		MhCommon.Assert(this.player != null, "StgEnemyRandomPopper::SetPlayer() player null");
		enemyFactory = new StgEnemyFactory(player);
	}

	public void Start() {
		counter = new DecrementCounterElapsedTime();	
		counter.SetCounter(0.5f);
	}

	/// <summary>
	/// 定期的に実行するタスク(1フレームごと)
	/// </summary>
	public void TaskAppear() {
		if (!counter.IsTimeOver()) {
			counter.Update();
			if (counter.IsTimeOver()) {
				//MhCommon.Print("reset");
				counter.SetCounter(0.5f);
				GameObject enemy = enemyFactory.Create(StgEnemyConstant.Type.kStraightMoveEnemy);//StgEnemyConstant.Type.kEnemyNormal);

				RandomIntegerSystem random = new RandomIntegerSystem();
				int value = random.Get(0, 2);
				if (value == 0) {
					Instantiate(enemy, new Vector3(0.0f, 6.0f, 0.0f), Quaternion.identity);
				} else if (value == 1) {
					Instantiate(enemy, new Vector3(0.5f, 6.0f, 0.0f), Quaternion.identity);
				} else {
					Instantiate(enemy, new Vector3(-0.5f, 6.0f, 0.0f), Quaternion.identity);
				}
			}
		}
	}

	public bool IsEnd() {
		// 無限に出る想定なので終了はしない
		return false;
	}

	private GameObject player;
	private DecrementCounterElapsedTime counter;
	private StgEnemyFactory enemyFactory;
}
