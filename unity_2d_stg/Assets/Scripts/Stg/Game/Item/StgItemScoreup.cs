﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemScoreup : StgItemBase, IAddableScore {
	public StgItemScoreup() {
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public override void Initialize() {
		base.Initialize();
		//Debug.Log("init");
	}

	public override void Start() {
		base.Start();
		//Debug.Log("start");
	}

	/// <summary>
	/// 更新処理
	/// </summary>
	public override void Update() {
		base.Update();

		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "StgItemScoreup::Update transform null");
		// 真下に進む
		rigidbody2D.velocity = new Vector2(0.0f, -1.2f);
	}

	/// <summary>
	/// スコアの加算
	/// </summary>
	/// <param name="score">加算されるスコア</param>
	public void AdditionalScore(int score) {
		SceneShare.Instance.GetGameTemporaryData().GetScoreData().AdditionalScore(score);
	}

	/// <summary>
	/// 当たり判定
	/// </summary>
	/// <param name="collision">当たり判定対象</param>
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayer)) {
			// プレイヤーと接触した時に消滅、スコアを加算
			Destroy(this.gameObject);
			AdditionalScore(StgItemConstant.kScoreScoreup);
		}
	}
}
