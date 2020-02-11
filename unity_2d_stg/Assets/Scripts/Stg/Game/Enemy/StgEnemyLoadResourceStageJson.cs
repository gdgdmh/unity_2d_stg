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
        if (result) {
            // テキストデータ取得
            var data = textAsset.Get();
            // jsonパース
            var json2 = Utf8Json.JsonSerializer.Deserialize<dynamic>(data);
            System.Collections.Generic.Dictionary<string, object> json3 = json2["stage_data"];

            // 読み込んだjsonデータを敵の出撃データとしてリストに保持する
            foreach (KeyValuePair<string, object> stageDatas in json3) {
                Dictionary<string, object> stageParameters = (Dictionary<string, object>)stageDatas.Value;
                StgStageJsonEnemyLaunchData launchData = new StgStageJsonEnemyLaunchData();
                foreach (KeyValuePair<string, object> stageData in stageParameters) {
                    var key = stageData.Key;
                    string val = stageData.Value as string;
					if (val != null) {
						// 値がstringへ変換できた
                        switch (key) {
                            case "enemy_type":
                                launchData.enemy_type = val as string;
                                break;
                            case "time":
                                launchData.time = float.Parse(val);
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

                    } else {
                        StgStageJsonEnemyItemDropDatas itemDropDatas = new StgStageJsonEnemyItemDropDatas();
                        // key,value形式
                        switch (key) {
							case "item_drop_data":
                                
                                List<object> itemDropList = stageData.Value as List<object>;
								foreach (object test in itemDropList) {
                                    Dictionary<string, object> items = test as Dictionary<string, object>;
                                    StgStageJsonEnemyItemDropData itemDropData = new StgStageJsonEnemyItemDropData();
                                    foreach (KeyValuePair<string, object> item in items) {
                                        string itemValue = item.Value as string;
										switch (item.Key) {
                                            case "type":
                                                itemDropData.Type = StgItemConstant.GetStringToType(itemValue);
                                                break;
                                            case "offset_x":
												{
                                                    Vector3 offset = itemDropData.Offset;
                                                    offset.x = float.Parse(itemValue);
                                                    itemDropData.Offset = offset;
                                                }
                                                break;
                                            case "offset_y":
												{
                                                    Vector3 offset = itemDropData.Offset;
                                                    offset.y = float.Parse(itemValue);
                                                    itemDropData.Offset = offset;
                                                }
                                                break;
                                            case "offset_z":
												{
                                                    Vector3 offset = itemDropData.Offset;
                                                    offset.z = float.Parse(itemValue);
                                                    itemDropData.Offset = offset;
                                                }
                                                break;
                                            default:
                                                break;
										}
									}
                                    itemDropDatas.AddData(itemDropData);
								}
                                launchData.enemyItemDropDatas.Copy(itemDropDatas);
                                break;
                            default:
                                break;
                        }
                        
                    }
                }
                launchDatas.AddData(launchData);
            }
            launchDatas.Print();
        } else {
            launchDatas.Initialize();
            throw new System.ArgumentException(string.Format("resource={0} json parse failure", resourcePath));
        }
    }

    public void Task(float elapsedTime) {
    }

    public StgStageJsonEnemyLaunchDatas Get() {
        return launchDatas;
    }

    private StgStageJsonEnemyLaunchDatas launchDatas = new StgStageJsonEnemyLaunchDatas();
}
