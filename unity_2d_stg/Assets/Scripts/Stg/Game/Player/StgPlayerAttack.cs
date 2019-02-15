using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttack : MonoBehaviour, IStgAttack {

	public StgPlayerAttack() {
		ResetAttackTime();
		attackPositon = new Vector3(0.0f, -3.0f, 0.0f);
	}

	public void SetAttackPosition(Vector3 position) {
		attackPositon = position;
	}

    // Start is called before the first frame update
    public void Start() {
        ResetAttackTime();
    }

    // Update is called once per frame
    public void Update() {
		// 一定時間ごとに攻撃
		float elapsedTime = Time.deltaTime;
		attackInterval -= elapsedTime;
		if (attackInterval <= 0.0f) {
			// 攻撃処理
			AttackProcess();
			// 攻撃再間隔設定
			ResetAttackTime();
		}
    }

	public void Attack(StgGameObject stgGameObject) {
	}

	private void ResetAttackTime() {
		attackInterval = kAttackInterval;
	}

	private void AttackProcess() {
		//MhCommon.Print("AttackProcess");
		// PlayerBulletを動的生成
		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();
		GameObject bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal);
		Instantiate(bullet, attackPositon, Quaternion.identity);
	}

	private static readonly float kAttackInterval = 2.0f; // 攻撃の再間隔時間(sec)
	private float attackInterval = kAttackInterval; // 現在の攻撃再間隔時間
	private Vector3 attackPositon; // 攻撃位置
}
