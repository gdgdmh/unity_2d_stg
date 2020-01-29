using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackPower2State : StgPlayerAttackState {
	public StgPlayerAttackPower2State() {
	}

	public override void Initialize() {
		base.Initialize();
		// 発射システムの初期化
		shot.Initialize();
		// 発射システムのインターバル設定
		shot.SetInterval(kAttackInterval);
		shot.ResetInterval();
	}

	public override void SetPlayer(ref GameObject player) {
		this.player = player;
		MhCommon.Assert(this.player != null, "StgPlayerAttackPower2State::SetPlayer() player null");
		playerScript = player.GetComponent<StgPlayer>();
	}

	public override void OnStateActive(state beforeState) {
		base.OnStateActive(beforeState);
		Debug.Log("StgPlayerAttackPower2State::OnStateActive");
		shot.ResetInterval();
	}

	public override void OnStateNonActive(state nextState) {
		base.OnStateNonActive(nextState);
		Debug.Log("StgPlayerAttackPower2State::OnStateNonActive");
	}

	public override state Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		MhCommon.Assert(playerScript != null, "StgPlayerAttackPower2State::Update() playerScript null");
		// 発射位置の設定
		shot.SetShotPosition(playerScript.GetShootPosition());
		shot.SetShotOffset(new Vector3(0.0f, 0.0f, 0.0f));
		// 発射更新処理
		shot.Update(elapsedTime, touchAction, dragAction);
		return state.Power2;
	}

	private static readonly float kAttackInterval = 0.6f; // 攻撃の再間隔時間(sec)
	protected GameObject player;
	protected StgPlayer playerScript;
	private StgPlayerIntervalShot shot = new StgPlayerIntervalShot();
}
