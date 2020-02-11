using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
/// <summary>
/// ステージデータの敵アイテムドロップデータ
/// </summary>
public class StgStageJsonEnemyItemDropDatas {
	public StgStageJsonEnemyItemDropDatas() {

	}

	/// <summary>
	/// データ初期化
	/// </summary>
	public void Initialize() {
        dropList.Clear();
	}

	/// <summary>
	/// データ追加
	/// </summary>
	public void AddData(StgStageJsonEnemyItemDropData enemyItemDropData) {
        dropList.Add(enemyItemDropData);
	}

	/// <summary>
	/// デバッグ出力
	/// </summary>
	public void Print() {
        foreach (StgStageJsonEnemyItemDropData data in dropList) {
            data.Print();
        }
    }

	/// <summary>
	/// index指定で取得する
	/// </summary>
	/// <param name="index">取得するデータのindex</param>
	/// <returns>アイテムドロップデータ</returns>
    public StgStageJsonEnemyItemDropData Get(int index) {
        return dropList[index];
	}

	/// <summary>
	/// データ数を取得
	/// </summary>
	/// <returns>データ数</returns>
	public int GetCount() {
		return dropList.Count;
	}

    private List<StgStageJsonEnemyItemDropData> dropList = new List<StgStageJsonEnemyItemDropData>(); // アイテムドロップデータ
}