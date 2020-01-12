using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemPowerup : StgItemBase, IAddableScore {
    public StgItemPowerup() {
	}

	/// <summary>
	/// スコアの加算
	/// </summary>
	public void AdditionalScore(int score) {
		SceneShare.Instance.GetGameTemporaryData().GetScoreData().AdditionalScore(score);
	}
}
