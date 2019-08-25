using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyLoadResourceStageJson {
    public StgEnemyLoadResourceStageJson() {
    }

    public void Initialize(string resourcePath) {
        LoadTextAsset textAsset = new LoadTextAsset();
        textAsset.SetResourcePath(resourcePath);
        bool result = textAsset.Load(true);
        StgStageJsonEnemyLaunchDatas jsonDatas = new StgStageJsonEnemyLaunchDatas();
        //T jsonItem = default(T);
        if (result) {
            //var data = JsonUtility.FromJson<StgStageJsonEnemyLaunchDataArray>(textAsset.Get());
            var data = textAsset.Get();
            //LoadJson.Load
            SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(data);
            var title = node["stage_data"]["0"]["enemy_type"];
            data = null;
        }
        //return jsonItem;

        //StgStageJsonEnemyLaunchDatas jsonDatas = LoadJson.LoadTest<StgStageJsonEnemyLaunchDatas, StgStageJsonEnemyLaunchData>(resourcePath);
        //StgStageJsonEnemyLaunchData[] jsonDatas = LoadJson.LoadTest<StgStageJsonEnemyLaunchDatas, StgStageJsonEnemyLaunchData>(resourcePath);

        jsonDatas = null;
    }

    public StgEnemyPopperData[] Get() {
        return null;
    }
}
