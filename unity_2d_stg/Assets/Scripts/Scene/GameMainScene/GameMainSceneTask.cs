﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSceneTask : MonoBehaviour
{

	private void Awake() {
        SceneShare.Instance.Initialize();
		
	}

	// Start is called before the first frame update
	void Start() {
		{
            // 敵出現システムの初期化
			if (enemyRandomPopper == null) {
				// プレイヤーのGameObjectを取得
				GameObject player = GameObject.Find("Player");
				MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");

				enemyRandomPopper = this.gameObject.AddComponent<StgEnemyRandomPopper>() as StgEnemyRandomPopper;
				MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
				enemyRandomPopper.SetPlayer(player);
				MhCommon.Print("random popper created");
			}
            // ステージデータ読み込み
            {
                stgEnemyLoadResourceStageJson = new StgEnemyLoadResourceStageJson();
                stgEnemyLoadResourceStageJson.SetResourcePath("");
                stgEnemyLoadResourceStageJson.Load();

            }
		}
    }

    // Update is called once per frame
    void Update() {

		// 敵の湧きシステムを常に起動しておく
		MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
		enemyRandomPopper.TaskAppear();
    }

	private StgEnemyRandomPopper enemyRandomPopper; // 敵をランダム出現システム
	private DecrementCounterFrame frame1; // フレームカウンタ
	private DecrementCounterElapsedTime frame2; // フレームカウンタ(ElapsedTime)
	private GameObject num002Object; // 数字表示
	private DisplayNumber002 displayNumber002Script; // 数字表示用のスクリプト
    private StgEnemyLoadResourceStageJson stgEnemyLoadResourceStageJson;
}
