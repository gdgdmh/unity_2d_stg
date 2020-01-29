using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackPower1State : StgPlayerAttackState {
	public StgPlayerAttackPower1State() {
		ResetAttackTime();
		attackPositon = new Vector3(0.0f, -3.0f, 0.0f);
	}

	public override void Initialize() {
		base.Initialize();
	}

	public override void SetPlayer(ref GameObject player) {
		this.player = player;
		MhCommon.Assert(this.player != null, "StgPlayerAttackPower1State::SetPlayer() player null");
	}

	public override void OnStateActive(state beforeState) {
		base.OnStateActive(beforeState);
		Debug.Log("StgPlayerAttackPower1State::OnStateActive");
		ResetAttackTime();
	}

	public override void OnStateNonActive(state nextState) {
		base.OnStateNonActive(nextState);
		Debug.Log("StgPlayerAttackPower1State::OnStateNonActive");
	}

	public override state Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		base.Update(elapsedTime, touchAction, dragAction);
		// 一定時間ごとに攻撃
		//float elapsedTime = Time.deltaTime;
		attackInterval -= elapsedTime;
		if (attackInterval <= 0.0f) {
			// 攻撃処理
			AttackProcess();
			// 攻撃再間隔設定
			ResetAttackTime();
		}

		return state.Power1;
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
		MhCommon.Assert(playerScript != null, "StgPlayerAttackPower1State::AttackProcess() playerScript null");
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
