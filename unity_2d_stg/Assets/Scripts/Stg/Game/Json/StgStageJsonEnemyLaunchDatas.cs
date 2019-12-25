using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class StgStageJsonEnemyLaunchDatas {

    public StgStageJsonEnemyLaunchDatas() {

    }

    /// <summary>
    /// データ初期化
    /// </summary>
    public void Initialize() {
        stage_data.Clear();
    }

    /// <summary>
    /// 敵出現データの追加
    /// </summary>
    /// <param name="data">追加する敵出現データ</param>
    public void AddData(StgStageJsonEnemyLaunchData data) {
        stage_data.Add(data);
    }

    /// <summary>
    /// 敵出現データのデバッグ出力(リストのデータ全て)
    /// </summary>
    public void Print() {
        foreach (StgStageJsonEnemyLaunchData data in stage_data) {
            data.Print();
        }
    }

    /// <summary>
    /// 敵出現データをindex指定で取得する
    /// </summary>
    /// <param name="index">取得するデータのindex</param>
    /// <returns>敵出現データ</returns>
    public StgStageJsonEnemyLaunchData Get(int index) {
        return stage_data[index];
    }

    /// <summary>
    /// 敵出現データ数を取得
    /// </summary>
    /// <returns></returns>
    public int GetCount() {
        return stage_data.Count;
    }

    private List<StgStageJsonEnemyLaunchData> stage_data = new List<StgStageJsonEnemyLaunchData>();

}