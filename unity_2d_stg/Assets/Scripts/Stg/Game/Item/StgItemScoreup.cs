﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemScoreup : StgItemBase, IAddableScore {
	public StgItemScoreup() {
	}

	public override void Initialize() {
		base.Initialize();
		//Debug.Log("init");
	}

	public override void Start() {
		base.Start();
		//Debug.Log("start");
	}

	public override void Update() {
		base.Update();
		//Debug.Log("update");
	}

	/// <summary>
	/// スコアの加算
	/// </summary>
	public void AdditionalScore(int score) {
		SceneShare.Instance.GetGameTemporaryData().GetScoreData().AdditionalScore(score);
	}

	/// <summary>
	/// 当たり判定
	/// </summary>
	/// <param name="collision"></param>
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayer)) {
			// プレイヤーと接触したら消滅
			Destroy(this.gameObject);
		}
	}
}