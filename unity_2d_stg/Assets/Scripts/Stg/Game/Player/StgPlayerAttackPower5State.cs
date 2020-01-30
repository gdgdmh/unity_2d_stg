using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackPower5State : StgPlayerAttackState {
	public StgPlayerAttackPower5State() {
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
		MhCommon.Assert(this.player != null, "StgPlayerAttackPower5State::SetPlayer() player null");
		playerScript = player.GetComponent<StgPlayer>();
	}

	public override void OnStateActive(state beforeState) {
		base.OnStateActive(beforeState);
		Debug.Log("StgPlayerAttackPower5State::OnStateActive");
		shoot.ResetInterval();
	}

	public override void OnStateNonActive(state nextState) {
		base.OnStateNonActive(nextState);
		Debug.Log("StgPlayerAttackPower5State::OnStateNonActive");
	}

	public override state Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		MhCommon.Assert(playerScript != null, "StgPlayerAttackPower5State::Update() playerScript null");
		// 発射位置の設定
		shoot.SetShootPosition(playerScript.GetShootPosition());
		shoot.SetShootOffset(new Vector3(0.0f, 0.0f, 0.0f));
		// 発射更新処理
		shoot.Update(elapsedTime, touchAction, dragAction);
		return state.Power5;
	}

	private static readonly float kAttackInterval = 1.1f; // 攻撃の再間隔時間(sec)
	protected GameObject player;
	protected StgPlayer playerScript;
	private StgPlayerInterval3WayShoot shoot = new StgPlayerInterval3WayShoot();
}
