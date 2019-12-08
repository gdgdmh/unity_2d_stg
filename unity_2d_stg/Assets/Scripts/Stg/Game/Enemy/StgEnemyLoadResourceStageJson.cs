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

            //Utf8Json utf8Json = new Utf8Json();

            /*
 public class NewBehaviourScript : MonoBehaviour {
	void Start () {
        var json2 = JsonSerializer.Deserialize<dynamic>(@"{""foo"":""json"",""bar"":100,""nest"":{""foobar"":true}}");

        var r1 = json2["foo"]; // "json" - dynamic(string)
        var r2 = json2["bar"]; // 100 - dynamic(double), it can cast to int or other number.
        var r3 = json2["nest"]["foobar"]; // true
    }
}
            */
            var json2 = Utf8Json.JsonSerializer.Deserialize<dynamic>(data);
            //RuntimeBinderException: Cannot implicitly convert type 'System.Collections.Generic.Dictionary<string,object>
            System.Collections.Generic.Dictionary<string, object> json3 = json2["stage_data"];

            foreach (KeyValuePair<string, object> item in json3) {
                //var key = item.Key;
                //var val = item.Value;

                Dictionary<string, object> stageParameters = (Dictionary<string, object>)item.Value;
                foreach (KeyValuePair<string, object> stageData in stageParameters) {
                    var key = stageData.Key;
                    var val = stageData.Value;

                    int bbb = 10;

                }

                //KeyValuePair<string, object> stageParameters = (System.Collections.Generic.KeyValuePair<string, object>)item.Value;

                //foreach (KeyValuePair<string,object> stageParameter in stageParameters) {
                //}
                //var ad = item.Value;
                //int bbb = 10;

            }

            //for (int i = 0; i < ; ++i) {
            //}


            /*
            SimpleJSON.JSONNode node = SimpleJSON.JSONNode.Parse(data);

            var title = node["stage_data"]["0"]["enemy_type"];
            var test_data = node["stage_data"]["10000"]["enemy_type"];
            //foreach (SimpleJSON.JSONNode node["stage_data"] in aaa) {
            //}
            StgStageJsonEnemyLaunchData[] launchDatas = new StgStageJsonEnemyLaunchData[node.Count];

            for (int i = 0; i < node.Count; ++i) {
                StgStageJsonEnemyLaunchData launchData = new StgStageJsonEnemyLaunchData();
                launchData.enemy_type = node["stage_data"][i]["enemy_type"];
                launchData.frame = node["stage_data"][i]["frame"];
                launchData.x = node["stage_data"][i]["x"];
                launchData.y = node["stage_data"][i]["y"];
                launchData.z = node["stage_data"][i]["z"];
                launchDatas[i] = launchData;
            }
            */

            var aaa = 10;




            /*
            StgStageJsonEnemyLaunchData launchData = new StgStageJsonEnemyLaunchData();
            launchData.enemy_type = node["stage_data"];
            launchData.frame = ;
            launchData.x = ;
            launchData.y = ;
            launchData.z = ;
            */

            /*
    public string enemy_type;
    public int frame;
    public float x;
    public float y;
    public float z;         
            */

            //data = null;
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
