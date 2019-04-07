using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreData {

	public GameScoreData() {
		score = new ManagedInteger();
		// 初期値を設定(最小0 最大9999999)
		score.SetValues(0, 9999999, 0);
	}

	public void Initialize() {
		score.Set(0);
	}

	public void AdditionalScore(int value) {
		score.Add(value);
	}

	public int GetScore() {
		return score.Get();
	}
	
	private ManagedInteger score;
}
