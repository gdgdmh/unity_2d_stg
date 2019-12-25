using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class StgStageJsonEnemyLaunchDatas {

    public StgStageJsonEnemyLaunchDatas() {

    }

    public void Initialize() {
        stage_data.Clear();
    }

    public void AddData(StgStageJsonEnemyLaunchData data) {
        stage_data.Add(data);
    }

    public void Print() {
        foreach (StgStageJsonEnemyLaunchData data in stage_data) {
            data.Print();
        }
    }

    private List<StgStageJsonEnemyLaunchData> stage_data = new List<StgStageJsonEnemyLaunchData>();

}