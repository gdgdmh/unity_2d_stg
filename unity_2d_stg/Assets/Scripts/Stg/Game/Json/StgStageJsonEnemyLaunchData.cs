using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵出現データ
/// </summary>
[SerializeField]
public class StgStageJsonEnemyLaunchData {
    public string enemy_type; // 敵のタイプ
    public float time; // 出現時間
    public float x; // 出現位置X
    public float y; // 出現位置Y
    public float z; // 出現位置Z
    public string item_drop_type; // アイテムドロップ
    public float item_drop_offset_x; // アイテムドロップオフセット位置X
    public float item_drop_offset_y; // アイテムドロップオフセット位置Y
    public float item_drop_offset_z; // アイテムドロップオフセット位置Z

    /// <summary>
    /// データの中身をデバッグ出力
    /// </summary>
    public void Print() {
        MhCommon.Print(string.Format("StgStageJsonEnemyLaunchData::Print() enemy_type={0} time={1} x={2} y={3} z={4} item_drop_type={5} item_drop_offset_x={6} item_drop_offset_y={7} item_drop_offset_z={8}",
			enemy_type, time, x, y, z, item_drop_type, item_drop_offset_x, item_drop_offset_y, item_drop_offset_z));
    }
}
