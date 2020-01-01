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
		//Debug.Log(string.Format("time={0}", totalTime));

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

	private GameObject player;
	private StgEnemyFactory enemyFactory;
    private StgStageJsonEnemyLaunchDatas stgStageJsonEnemyLaunchDatas = new StgStageJsonEnemyLaunchDatas();
	private float totalTime;

}
