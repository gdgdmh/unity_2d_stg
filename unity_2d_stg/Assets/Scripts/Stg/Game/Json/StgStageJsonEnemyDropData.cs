using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージデータJsonの敵のドロップデータ
/// </summary>
public class StgStageJsonEnemyDropData {
	// アイテムのタイプ
	public StgItemConstant.Type Type { set; get; }
	// ドロップ位置のオフセット(敵からのオフセット)
	public Vector3 Offset { set; get; } = new Vector3(0, 0, 0);
}
