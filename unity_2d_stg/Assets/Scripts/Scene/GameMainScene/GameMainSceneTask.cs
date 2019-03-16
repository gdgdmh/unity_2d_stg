using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSceneTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneShare.Instance.Initialize();

		//enemyRandomPopper

		{
			// 敵の生成
			GameObject player = GameObject.Find("Player");
			MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");
			StgEnemyFactory factory = new StgEnemyFactory(player);
			GameObject enemy = factory.Create(StgEnemyConstant.Type.kEnemyNormal);
			Instantiate(enemy, new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity);
		}

		/*
		// PlayerBulletを動的生成
		{
			StgPlayerBulletFactory factory = new StgPlayerBulletFactory();
			GameObject bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal);
			Instantiate(bullet, new Vector3(0.0f, -3.0f, 0.0f), Quaternion.identity);
		}
		*/
		{
			if (enemyRandomPopper == null) {
				enemyRandomPopper = this.gameObject.AddComponent<StgEnemyRandomPopper>() as StgEnemyRandomPopper;
				MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
				MhCommon.Print("random popper created");
			}
		}
		/*
        // 動的にスクリプトを追加
        if (stgPlayerController == null) {
            stgPlayerController = this.gameObject.AddComponent<StgPlayerController>() as StgPlayerController;
            MhCommon.Assert(stgPlayerController != null, "StgPlayer::Awake() StgPlayerController AddComponent failure");
			// 試しにcall
			stgPlayerController.Update();
        }

		 */
    }

    // Update is called once per frame
    void Update() {

		// 敵の湧きシステムを常に起動しておく
		MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
		enemyRandomPopper.TaskAppear();
        
    }

	private StgEnemyRandomPopper enemyRandomPopper;
}
