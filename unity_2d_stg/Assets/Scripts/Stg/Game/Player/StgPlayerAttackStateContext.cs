using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackStateContext {

	public StgPlayerAttackStateContext(ref GameObject player) {
		power1.Initialize();
		power1.SetPlayer(ref player);
		power2.Initialize();
		power2.SetPlayer(ref player);
		power3.Initialize();
		power3.SetPlayer(ref player);
		power4.Initialize();
		power4.SetPlayer(ref player);

	}

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize() {
		current = power3;
		currentState = StgPlayerAttackState.state.Power3;
		current.OnStateActive(currentState);
	}

	/// <summary>
	/// ステータス更新処理
	/// </summary>
	/// <param name="elapsedTime">前回実行からの経過時間</param>
	/// <param name="touchAction">タッチ入力クラス</param>
	/// <param name="dragAction">ドラッグ入力クラス</param>
	public void Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		StgPlayerAttackState.state state = current.Update(elapsedTime, touchAction, dragAction);
		if (state != currentState) {
			SetCurrentState(state);
		}
	}

	/// <summary>
	/// パワーアップ処理
	/// </summary>
	public void Powerup() {
		if (currentState == StgPlayerAttackState.state.Power1) {
			SetCurrentState(StgPlayerAttackState.state.Power2);
		} else if (currentState == StgPlayerAttackState.state.Power2) {
			SetCurrentState(StgPlayerAttackState.state.Power3);
		} else if (currentState == StgPlayerAttackState.state.Power3) {
			SetCurrentState(StgPlayerAttackState.state.Power4);
		} else if (currentState == StgPlayerAttackState.state.Power4) {
		} else if (currentState == StgPlayerAttackState.state.Power5) {
		} else if (currentState == StgPlayerAttackState.state.Power6) {
		}
	}

	/// <summary>
	/// currentStateを設定する
	/// </summary>
	/// <param name="state">設定するステータス</param>
	private void SetCurrentState(StgPlayerAttackState.state state) {
		if (state == currentState) {
			return;
		}
		// 現在のステータスから変更するのでイベント発生
		current.OnStateNonActive(state);

		current = GetState(state);
		current.OnStateActive(currentState);
		currentState = state;
	}

	/// <summary>
	/// ステータスのENUMからクラスを取得する
	/// </summary>
	/// <param name="state">対象ステータス定義</param>
	/// <returns>ステータスクラス</returns>
	private StgPlayerAttackState GetState(StgPlayerAttackState.state state) {
		switch (state) {
			case StgPlayerAttackState.state.Power1:
				return power1;
			case StgPlayerAttackState.state.Power2:
				return power2;
			case StgPlayerAttackState.state.Power3:
				return power3;
			case StgPlayerAttackState.state.Power4:
				return power4;
			default:
				break;
		}
		return null;
	}

	private StgPlayerAttackState current;				// 現在のステータス(クラス)
	private StgPlayerAttackState.state currentState;	// 現在のステータス(定義)

	private StgPlayerAttackPower1State power1 = new StgPlayerAttackPower1State();
	private StgPlayerAttackPower2State power2 = new StgPlayerAttackPower2State();
	private StgPlayerAttackPower3State power3 = new StgPlayerAttackPower3State();
	private StgPlayerAttackPower4State power4 = new StgPlayerAttackPower4State();

}
