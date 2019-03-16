using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デクリメント型のカウンタ(Updateの1回のコールを1フレームとみなして減算する)
/// </summary>
public class DecrementCounterFrame {

	public DecrementCounterFrame() {
		maxCounter = 0.0f;
		counter = 0.0f;
	}

	/// <summary>
	/// カウンタ値を設定する(カウンタ最大値とカウンタの現在値が設定される)
	/// </summary>
	/// <param name="counter">設定されるカウンタ</param>
	public void SetCounter(int counter) {
		maxCounter = counter;
		this.counter = counter;
	}

	/// <summary>
	/// カウンタ値を設定する(カウンタ最大値とカウンタの現在値が設定される)
	/// </summary>
	/// <param name="counter">設定されるカウンタ</param>
	public void SetCounter(float counter) {
		maxCounter = counter;
		this.counter = counter;
	}

	/// <summary>
	/// 現在のカウンタ値を設定する(カウンタ最大値は影響されない)
	/// </summary>
	/// <param name="counter">設定されるカウンタ</param>
	public void SetCurrentCounter(int counter) {
		this.counter = counter;
	}

	/// <summary>
	/// 現在のカウンタ値を設定する(カウンタ最大値は影響されない)
	/// </summary>
	/// <param name="counter">設定されるカウンタ</param>
	public void SetCurrentCounter(float counter) {
		this.counter = counter;
	}

	/// <summary>
	/// カウンタ最大値を取得する
	/// </summary>
	/// <returns></returns>
	public float GetMaxCounter() {
		return maxCounter;
	}

	/// <summary>
	/// 現在のカウンタ値を取得する
	/// </summary>
	/// <returns></returns>
	public float GetCurrentCounter() {
		return counter;
	}

	/// <summary>
	/// パーセンテージの取得
	/// </summary>
	/// <returns></returns>
	public float GetPercent() {
		// maxが0だったり負の値のときは正常に算出できないので0とする
		if (maxCounter <= 0.0f) {
			return 0.0f;
		}
		return ((100 * counter) / maxCounter);
	}

	/// <summary>
	/// 更新処理
	/// </summary>
	/// <returns>trueならまだタイムオーバーになっていない falseならタイムオーバーになっている</returns>
	public bool Update() {
		if (IsTimeOver()) {
			// 既に時間経過しているので何もしない
			return false;
		} else {
			counter -= 1.0f; // 1フレーム経過とみなし-1.0fとする
			if (IsTimeOver()) {
				// 今タイムオーバーになった
				return false;
			} else {
				// まだタイムオーバーになっていない
				return true;
			}
		}
	}

	/// <summary>
	/// タイムオーバーになったかどうか
	/// </summary>
	/// <returns>trueならタイムオーバー falseならタイムオーバーになっていない</returns>
	public bool IsTimeOver() {
		// カウンタが0.0000か下回ったらタイムオーバーとする
		if (counter <= 0.0000f) {
			return true;
		}
		return false;
	}

	private float maxCounter;	// カウンタの最大値
	private float counter;		// 現在のカウンタ値

}
