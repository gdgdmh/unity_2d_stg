﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームシーンの前後で一時的に保持するデータ(ステージデータ、スコアなど)
/// </summary>
public class GameTemporaryData {

	public GameTemporaryData() {
	}

	public void Initialize() {
		score = new GameScoreData();
		score.Initialize();
	}


	private GameScoreData score;
}
