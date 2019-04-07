using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : StgGameObject {

	public EnemyBase() {
	}

	public override void Initialize() {
		base.Initialize();
	}

    // Update is called once per frame
    public override void Update() {
    }

	/// <summary>
	/// スコアの加算
	/// </summary>
	public void AdditionalScore(int score) {
		SceneShare.Instance.GetGameTemporaryData().GetScoreData().AdditionalScore(score);
	}
}
