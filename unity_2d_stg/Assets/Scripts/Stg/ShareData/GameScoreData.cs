using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームのスコアの数値を保持するクラス
/// </summary>
public class GameScoreData {

	public GameScoreData() {
		score = new ManagedInteger();
		// 初期値を設定(最小0 最大9999999)
		score.SetValues(0, 9999999, 0);
	}

	/// <summary>
	/// 初期化(0にする)
	/// </summary>
	public void Initialize() {
		score.Set(0);
	}

	/// <summary>
	/// スコアの加算
	/// </summary>
	/// <param name="value">加算する値</param>
	public void AdditionalScore(int value) {
		score.Add(value);
	}

	/// <summary>
	/// スコアの数値の取得
	/// </summary>
	/// <returns></returns>
	public int GetScore() {
		return score.Get();
	}
	
	private ManagedInteger score; // スコア
}
