using System.Collections;
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
			if (enemyRandomPopper == null) {
				// プレイヤーのGameObjectを取得
				GameObject player = GameObject.Find("Player");
				MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");

				enemyRandomPopper = this.gameObject.AddComponent<StgEnemyRandomPopper>() as StgEnemyRandomPopper;
				MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
				enemyRandomPopper.SetPlayer(player);
				MhCommon.Print("random popper created");
			}
		}
    }

    // Update is called once per frame
    void Update() {

		// 敵の湧きシステムを常に起動しておく
		//MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
		//enemyRandomPopper.TaskAppear();
    }

	private StgEnemyRandomPopper enemyRandomPopper;
	private DecrementCounterFrame frame1;
	private DecrementCounterElapsedTime frame2;
	private GameObject num002Object;
	private DisplayNumber002 displayNumber002Script;
}
