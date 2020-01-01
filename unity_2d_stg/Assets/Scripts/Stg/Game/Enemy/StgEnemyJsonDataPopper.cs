using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyJsonDataPopper : MonoBehaviour, IStgEnemyAppearable {

    public StgEnemyJsonDataPopper() {
        this.player = null;

    }

	public void SetPlayer(GameObject player) {
		this.player = player;
		MhCommon.Assert(this.player != null, "StgEnemyRandomPopper::SetPlayer() player null");
		enemyFactory = new StgEnemyFactory(player);
	}

    public void SetJsonEnemyLaunchDatas(StgStageJsonEnemyLaunchDatas stgStageJsonEnemyLaunchDatas) {
        this.stgStageJsonEnemyLaunchDatas = stgStageJsonEnemyLaunchDatas;
        //this.stgStageJsonEnemyLaunchDatas.Print();

        StgStageJsonEnemyLaunchData d = stgStageJsonEnemyLaunchDatas.Get(4);
        d.Print();

		currentIndex = 0;
		maxCount = stgStageJsonEnemyLaunchDatas.GetCount();
    }

    // Start is called before the first frame update
    public void Start() {
		totalTime = 0.0f;
    }

    // Update is called once per frame
    public void Update() {        
    }

	public void TaskAppear() {
		float elapsedTime = Time.deltaTime;

		// 総合経過時間を加算
		totalTime += elapsedTime;
		Debug.Log(string.Format("time={0}", totalTime));

		// データがない or データが終端まで実行し終わっている
		if ((maxCount == 0) || (currentIndex >= maxCount)) {
			Debug.Log("ended");
			return;
		}

		bool isContinue = true;
		while (isContinue) {
			if (currentIndex >= maxCount) {
				// データが終端まで実行している
				Debug.Log("loop end");
				return;
			}
			StgStageJsonEnemyLaunchData launchData = stgStageJsonEnemyLaunchDatas.Get(currentIndex);
			if (launchData.time <= (int)totalTime) {
				launchData.Print();
				++currentIndex;
				Debug.Log("next loop");
			} else {
				Debug.Log("loop end by frame");
				return;
			}
		}

		/*
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
        */
	}

	private GameObject player;				// プレイヤー
	private StgEnemyFactory enemyFactory;	// 敵生成システム
    private StgStageJsonEnemyLaunchDatas stgStageJsonEnemyLaunchDatas = new StgStageJsonEnemyLaunchDatas(); // 敵出現データ
	private float totalTime;	// 現在の経過時間
	private int currentIndex;   // 敵出現データのindex
	private int maxCount;		// 敵出現データの最大数

}
