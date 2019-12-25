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

    public StgStageJsonEnemyLaunchData Get(int index) {
        return stage_data[index];
    }

    private List<StgStageJsonEnemyLaunchData> stage_data = new List<StgStageJsonEnemyLaunchData>();

}