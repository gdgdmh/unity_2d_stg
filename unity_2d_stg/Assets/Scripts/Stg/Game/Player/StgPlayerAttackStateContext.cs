using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackStateContext {

	public StgPlayerAttackStateContext() {
		power1.Initialize();

	}

	public void Initialize() {
		current = power1;
		currentState = StgPlayerAttackState.state.Power1;
		current.OnStateActive(currentState);
	}

	/// <summary>
	/// ステータス更新処理
	/// </summary>
	/// <param name="elapsedTime"></param>
	/// <param name="touchAction"></param>
	/// <param name="dragAction"></param>
	public void Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		StgPlayerAttackState.state state = current.Update(elapsedTime, touchAction, dragAction);
		if (state != currentState) {
			SetCurrentState(state);
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
			default:
				break;
		}
		return null;
	}

	private StgPlayerAttackState current;				// 現在のステータス(クラス)
	private StgPlayerAttackState.state currentState;	// 現在のステータス(定義)

	private StgPlayerAttackPower1State power1 = new StgPlayerAttackPower1State();

}
