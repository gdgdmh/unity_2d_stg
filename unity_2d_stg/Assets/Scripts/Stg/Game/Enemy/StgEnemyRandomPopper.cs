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
				MhCommon.Print("reset");
				counter.SetCounter(0.5f);
				GameObject enemy = enemyFactory.Create(StgEnemyConstant.Type.kEnemyNormal);

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

		//MhCommon.Print("TaskAppear");
	}
	/*
		{
			// 敵の生成
			GameObject player = GameObject.Find("Player");
			MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");
			StgEnemyFactory factory = new StgEnemyFactory(player);
			GameObject enemy = factory.Create(StgEnemyConstant.Type.kEnemyNormal);
			Instantiate(enemy, new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity);
		}

	*/

	private GameObject player;
	private DecrementCounterElapsedTime counter;
	private StgEnemyFactory enemyFactory;
}
