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

		if (IsTimeOver()) {
			// 経過時間オーバーなので処理しない
			return;
		}
		// 総合経過時間を加算
		totalTime += elapsedTime;
		//Debug.Log(string.Format("time={0}", totalTime));

		if (IsDataEnd()) {
			// データ実行終了 or データがない
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
					GameObject enemy = enemyFactory.Create(StgEnemyConstant.GetStringToType(launchData.enemy_type), launchData.enemyItemDropDatas);

					Instantiate(enemy, new Vector3(launchData.x, launchData.y, launchData.z), Quaternion.identity);

					// ドロップアイテム設定
					NormalEnemy enemyBase = enemy.GetComponent<NormalEnemy>();
					StgItemMultiDropper dropper = new StgItemMultiDropper();
					for (int i = 0; i < launchData.enemyItemDropDatas.GetCount(); ++i) {
						StgStageJsonEnemyItemDropData dropData = launchData.enemyItemDropDatas.Get(i);
						dropper.SetParameter(dropData.Offset, dropData.Type);
					}
					dropper.Print();
					enemyBase.SetItemDropper(dropper);

				}
				++currentIndex;
			} else {
				// 処理すべきtimeのデータがない
				return;
			}
		}
	}

	public bool IsEnd() {
		if ((IsDataEnd()) || (IsTimeOver())) {
			// データ処理済み or 経過時間オーバーなら終了していると見なす
			return true;
		}
		return false;
	}

	private bool IsDataEnd() {
		// データがない or データが終端まで実行し終わっている
		if ((maxCount == 0) || (currentIndex >= maxCount)) {
			return true;
		}
		return false;
	}

	private bool IsTimeOver() {
		if (totalTime >= kMaxTime) {
			// 最大時間以上加算を行わない(オーバーフロー)
			return true;
		}
		return false;
	}

	private static readonly float kMaxTime = 999999; // 最大時間
	private GameObject player;				// プレイヤー
	private StgEnemyFactory enemyFactory;	// 敵生成システム
    private StgStageJsonEnemyLaunchDatas stgStageJsonEnemyLaunchDatas = new StgStageJsonEnemyLaunchDatas(); // 敵出現データ
	private float totalTime;	// 現在の経過時間
	private int currentIndex;   // 敵出現データのindex
	private int maxCount;		// 敵出現データの最大数

}
