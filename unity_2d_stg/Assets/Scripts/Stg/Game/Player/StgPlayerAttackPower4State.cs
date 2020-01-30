using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackPower4State : StgPlayerAttackState {
	public StgPlayerAttackPower4State() {
	}

	public override void Initialize() {
		base.Initialize();
		// 発射システムの初期化
		shoot.Initialize();
		// 発射システムのインターバル設定
		shoot.SetInterval(kAttackInterval);
		shoot.ResetInterval();
	}

	public override void SetPlayer(ref GameObject player) {
		this.player = player;
		MhCommon.Assert(this.player != null, "StgPlayerAttackPower4State::SetPlayer() player null");
		playerScript = player.GetComponent<StgPlayer>();
	}

	public override void OnStateActive(state beforeState) {
		base.OnStateActive(beforeState);
		Debug.Log("StgPlayerAttackPower4State::OnStateActive");
		shoot.ResetInterval();
	}

	public override void OnStateNonActive(state nextState) {
		base.OnStateNonActive(nextState);
		Debug.Log("StgPlayerAttackPower4State::OnStateNonActive");
	}

	public override state Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		MhCommon.Assert(playerScript != null, "StgPlayerAttackPower4State::Update() playerScript null");
		// 発射位置の設定
		shoot.SetShootPosition(playerScript.GetShootPosition());
		shoot.SetShootOffset(new Vector3(0.0f, 0.0f, 0.0f));
		// 発射更新処理
		shoot.Update(elapsedTime, touchAction, dragAction);
		return state.Power4;
	}

	private static readonly float kAttackInterval = 0.7f; // 攻撃の再間隔時間(sec)
	protected GameObject player;
	protected StgPlayer playerScript;
	private StgPlayerInterval2WayShoot shoot = new StgPlayerInterval2WayShoot();
}
