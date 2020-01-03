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

		if (totalTime >= kMaxTime) {
			// 最大時間以上加算を行わない(オーバーフロー)
			return;
		}
		// 総合経過時間を加算
		totalTime += elapsedTime;
		//Debug.Log(string.Format("time={0}", totalTime));

		// データがない or データが終端まで実行し終わっている
		if ((maxCount == 0) || (currentIndex >= maxCount)) {
			return;
		}

		bool isContinue = true;
		while (isContinue) {
			if (currentIndex >= maxCount) {
				// データが終端まで実行している
				return;
			}
			StgStageJsonEnemyLaunchData launchData = stgStageJsonEnemyLaunchDatas.Get(currentIndex);
			if (launchData.time <= (int)totalTime) {
				// 敵の生成
				{
					GameObject enemy = enemyFactory.Create(StgEnemyConstant.GetStringToType(launchData.enemy_type));
					Instantiate(enemy, new Vector3(launchData.x, launchData.y, launchData.z), Quaternion.identity);
				}
				++currentIndex;
			} else {
				// 処理すべきtimeのデータがない
				return;
			}
		}
	}

	private static readonly float kMaxTime = 999999; // 最大時間
	private GameObject player;				// プレイヤー
	private StgEnemyFactory enemyFactory;	// 敵生成システム
    private StgStageJsonEnemyLaunchDatas stgStageJsonEnemyLaunchDatas = new StgStageJsonEnemyLaunchDatas(); // 敵出現データ
	private float totalTime;	// 現在の経過時間
	private int currentIndex;   // 敵出現データのindex
	private int maxCount;		// 敵出現データの最大数

}
