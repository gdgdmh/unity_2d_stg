using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージデータJsonの敵のアイテムドロップデータ
/// </summary>
public class StgStageJsonEnemyItemDropData {
	/// <summary>
	/// デバッグ出力
	/// </summary>
	public void Print() {
		Debug.Log(string.Format("StgStageJsonEnemyItemDropData::Print() type={0}  Offset.x={1} Offset.y={2} Offset.z={3}", Type, Offset.x, Offset.y, Offset.z));
	}
	// アイテムのタイプ
	public StgItemConstant.Type Type { set; get; }
	// ドロップ位置のオフセット(敵からのオフセット)
	public Vector3 Offset { set; get; } = new Vector3(0, 0, 0);
}
