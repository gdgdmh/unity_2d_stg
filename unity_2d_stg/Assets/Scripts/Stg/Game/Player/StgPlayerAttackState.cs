using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackState {

	public enum state {
		Power1,
		Power2,
		Power3,
		Power4,
		Power5,
		Power6
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public virtual void Initialize() {
	}

	/// <summary>
	/// プレイヤーの設定
	/// </summary>
	/// <param name="player"></param>
	public virtual void SetPlayer(ref GameObject player) {
	}

	/// <summary>
	/// ステータスがアクティブ状態に切り替わった時のイベント
	/// </summary>
	public virtual void OnStateActive(state beforeState) {
	}

	/// <summary>
	/// ステータスが非アクティブ状態に切り替わった時のイベント
	/// </summary>
	public virtual void OnStateNonActive(state nextState) {
	}

	/// <summary>
	/// 入力更新処理
	/// </summary>
	/// <param name="elapsedTime">前回からの経過時間</param>
	/// <param name="touchAction">入力クラス</param>
	/// <param name="dragAction">ドラッグ入力クラス</param>
	/// <returns>次のステータス</returns>
	public virtual state Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		return state.Power1;
	}

}
