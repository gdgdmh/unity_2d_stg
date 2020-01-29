using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackPower4State : StgPlayerAttackState {
	public StgPlayerAttackPower4State() {
		ResetAttackTime();
		attackPositions[0] = new Vector3(kAttackPositionXOffset, -3.0f, 0.0f);
		attackPositions[1] = new Vector3(-kAttackPositionXOffset, -3.0f, 0.0f);
	}

	public override void Initialize() {
		base.Initialize();
	}

	public override void SetPlayer(ref GameObject player) {
		this.player = player;
		MhCommon.Assert(this.player != null, "StgPlayerAttackPower4State::SetPlayer() player null");
	}

	public override void OnStateActive(state beforeState) {
		base.OnStateActive(beforeState);
		Debug.Log("StgPlayerAttackPower4State::OnStateActive");
		ResetAttackTime();
	}

	public override void OnStateNonActive(state nextState) {
		base.OnStateNonActive(nextState);
		Debug.Log("StgPlayerAttackPower4State::OnStateNonActive");
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

		return state.Power4;
	}

	private void ResetAttackTime() {
		attackInterval = kAttackInterval;
	}

	private void AttackProcess() {
		// PlayerBulletを動的生成
		StgPlayerBulletFactory factory = new StgPlayerBulletFactory();

		if (playerScript == null) {
			// SetPlayerの時点ではStgPlayerを取得できないのでここで一度だけ取得する
			playerScript = this.player.GetComponent<StgPlayer>();
		}
		MhCommon.Assert(playerScript != null, "StgPlayerAttackPower4State::AttackProcess() playerScript null");
		Vector3 shootPosition = playerScript.GetShootPosition();
		attackPositions[0] = shootPosition;
		attackPositions[1] = shootPosition;

		attackPositions[0].x += kAttackPositionXOffset;
		attackPositions[1].x += -kAttackPositionXOffset;

		GameObject[] bullets = new GameObject[kAttackNum];
		bullets[0] = factory.Create(StgBulletConstant.Type.kPlayerNormal);
		bullets[1] = factory.Create(StgBulletConstant.Type.kPlayerNormal);

		for (int i = 0; i < kAttackNum; ++i) {
			Object.Instantiate(bullets[i], attackPositions[i], Quaternion.identity);
		}
		//Object.Instantiate(bullets, attackPositions[0], Quaternion.identity);
	}
	private static readonly float kAttackInterval = 0.7f; // 攻撃の再間隔時間(sec)
	private static readonly float kAttackPositionXOffset = 0.5f; // 攻撃の位置オフセットX
	private static readonly int kAttackNum = 2;
	protected GameObject player;
	protected StgPlayer playerScript;
	private float attackInterval = kAttackInterval; // 現在の攻撃再間隔時間
	private Vector3[] attackPositions = new Vector3[kAttackNum]; // 攻撃位置
}
