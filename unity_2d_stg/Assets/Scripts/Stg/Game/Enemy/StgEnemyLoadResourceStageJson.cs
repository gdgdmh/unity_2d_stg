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
            // テキストデータ取得
            var data = textAsset.Get();
            // jsonパース
            var json2 = Utf8Json.JsonSerializer.Deserialize<dynamic>(data);
            System.Collections.Generic.Dictionary<string, object> json3 = json2["stage_data"];

            foreach (KeyValuePair<string, object> stageDatas in json3) {
                Dictionary<string, object> stageParameters = (Dictionary<string, object>)stageDatas.Value;
                StgStageJsonEnemyLaunchData launchData = new StgStageJsonEnemyLaunchData();
                foreach (KeyValuePair<string, object> stageData in stageParameters) {
                    var key = stageData.Key;
                    string val = (string)stageData.Value;
                    switch (key) {
                        case "enemy_type":
                            launchData.enemy_type = (string)val;
                            break;
                        case "frame":
                            launchData.frame = int.Parse(val);
                            break;
                        case "x":
                            launchData.x = float.Parse(val);
                            break;
                        case "y":
                            launchData.y = float.Parse(val);
                            break;
                        case "z":
                            launchData.z = float.Parse(val);
                            break;
                        default:
                            break;
                    }
                    int bbb = 10;
                }
                jsonDatas.AddData(launchData);
                //launchData.Print();
            }

            jsonDatas.Print();

            /*
    public string enemy_type;
    public int frame;
    public float x;
    public float y;
    public float z;         
            */
        }
        //StgStageJsonEnemyLaunchDatas jsonDatas = LoadJson.LoadTest<StgStageJsonEnemyLaunchDatas, StgStageJsonEnemyLaunchData>(resourcePath);
        //StgStageJsonEnemyLaunchData[] jsonDatas = LoadJson.LoadTest<StgStageJsonEnemyLaunchDatas, StgStageJsonEnemyLaunchData>(resourcePath);

        jsonDatas = null;
    }

    public StgEnemyPopperData[] Get() {
        return null;
    }
}
