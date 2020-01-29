using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttack : MonoBehaviour, IStgAttack {

	public StgPlayerAttack() {
		ResetAttackTime();
		attackPositon = new Vector3(0.0f, -3.0f, 0.0f);

	}

	public void SetPlayer(ref GameObject player) {
		MhCommon.Print("SetPlayer");
		this.player = player;
		MhCommon.Assert(this.player != null, "StgPlayerAttack::SetPlayer() player null");
	}

    // Start is called before the first frame update
    public void Start() {
        ResetAttackTime();
    }

    // Update is called once per frame
    public void Update() {
		// 一定時間ごとに攻撃
		//float elapsedTime = Time.deltaTime;
		//attackInterval -= elapsedTime;
		//if (attackInterval <= 0.0f) {
			// 攻撃処理
		//	AttackProcess();
			// 攻撃再間隔設定
		//	ResetAttackTime();
		//}
    }

	/// <summary>
	/// 攻撃した際の挙動
	/// </summary>
	/// <param name="stgGameObject"></param>
	public void Attack(StgGameObject stgGameObject) {
	}

	private void ResetAttackTime() {
		attackInterval = kAttackInterval;
	}

	private void AttackProcess() {
		// PlayerBulletを動的生成
		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();
		GameObject bullet = factory.Create(StgBulletConstant.Type.kPlayerNormal);

		if (playerScript == null) {
			// SetPlayerの時点ではStgPlayerを取得できないのでここで一度だけ取得する
			playerScript = this.player.GetComponent<StgPlayer>();
		}
		MhCommon.Assert(playerScript != null, "StgPlayerAttack::AttackProcess() playerScript null");
		Vector3 shootPosition = playerScript.GetShootPosition();
		attackPositon = shootPosition;

		Object.Instantiate(bullet, attackPositon, Quaternion.identity);
	}

	private static readonly float kAttackInterval = 1.0f; // 攻撃の再間隔時間(sec)
	protected GameObject player;
	protected StgPlayer playerScript;
	private float attackInterval = kAttackInterval; // 現在の攻撃再間隔時間
	private Vector3 attackPositon; // 攻撃位置
}
