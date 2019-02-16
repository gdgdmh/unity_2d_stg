using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainSceneTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        SceneShare.Instance.Initialize();

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
    }

    // Update is called once per frame
    void Update() {
        
    }
}
