using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSceneTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneShare.Instance.Initialize();

		//enemyRandomPopper

		/****
		{
			// 敵の生成
			GameObject player = GameObject.Find("Player");
			MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");
			StgEnemyFactory factory = new StgEnemyFactory(player);
			GameObject enemy = factory.Create(StgEnemyConstant.Type.kEnemyNormal);
			Instantiate(enemy, new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity);
		}
		*/

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
				// プレイヤーのGameObjectを取得
				GameObject player = GameObject.Find("Player");
				MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");

				enemyRandomPopper = this.gameObject.AddComponent<StgEnemyRandomPopper>() as StgEnemyRandomPopper;
				MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
				enemyRandomPopper.SetPlayer(player);
				MhCommon.Print("random popper created");
			}
		}

		//number002 = this.gameObject.AddComponent<DisplayNumber002>() as DisplayNumber002;
		/*
        // 動的にスクリプトを追加
        if (stgPlayerController == null) {
            stgPlayerController = this.gameObject.AddComponent<StgPlayerController>() as StgPlayerController;
            MhCommon.Assert(stgPlayerController != null, "StgPlayer::Awake() StgPlayerController AddComponent failure");
			// 試しにcall
			stgPlayerController.Update();
        }

		 */
		/*
		frame1 = new DecrementCounterFrame();
		frame1.SetCounter(10);
		frame2 = new DecrementCounterElapsedTime();
		frame2.SetCounter(10);
		*/

		{
			// DisplayNumber002 のスクリプトを取得
			num002Object = GameObject.Find("DisplayNumberScript");
			MhCommon.Assert(num002Object != null, "GameMainSceneTask::DisplayNumberScript Find Failure");
			displayNumber002Script = num002Object.GetComponent<DisplayNumber002>();
			MhCommon.Assert(displayNumber002Script != null, "GameMainSceneTask::DisplayNumberScript Find Failure");
			// 555に設定
			displayNumber002Script.Set(555);
		}

		/*
		basePosition.x = 2.0f;
		basePosition.y = 0;
		basePosition.z = 0;
		offset.x = -0.32f;
		offset.y = 0;
		offset.z = 0;

		 * 
		*/
    }

    // Update is called once per frame
    void Update() {

		// 敵の湧きシステムを常に起動しておく
		MhCommon.Assert(enemyRandomPopper != null, "GameMainSceneTask::Start() StgEnemyRandomPopper AddComponent failure");
		enemyRandomPopper.TaskAppear();

		/*
		if (!frame2.IsTimeOver()) {
			frame2.Update();
			MhCommon.Print(frame2.GetCurrentCounter());
		}
		*/

        
    }

	private StgEnemyRandomPopper enemyRandomPopper;
	private DecrementCounterFrame frame1;
	private DecrementCounterElapsedTime frame2;
	private GameObject num002Object;
	private DisplayNumber002 displayNumber002Script;

	//private DisplayNumber002 number002;
}
