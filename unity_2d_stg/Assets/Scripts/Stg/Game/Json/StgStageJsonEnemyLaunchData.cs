using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class StgStageJsonEnemyLaunchData {
    public string enemy_type;
    public int time;
    public float x;
    public float y;
    public float z;

    public void Print() {
        MhCommon.Print(string.Format("StgStageJsonEnemyLaunchData::Print() enemy_type={0} time={1} x={2} y={3} z={4}", enemy_type, time, x, y, z));
    }
}
