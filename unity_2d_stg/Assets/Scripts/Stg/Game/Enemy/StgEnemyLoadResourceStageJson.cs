using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyLoadResourceStageJson {
    public StgEnemyLoadResourceStageJson() {
        resourcePath = "";
    }

    public StgEnemyLoadResourceStageJson(string resourcePath) {
        this.resourcePath = resourcePath;
    }

    public void SetResourcePath(string resourcePath) {
        this.resourcePath = resourcePath;
    }

    public bool Load() {
        // stageData1のパスを取得
        string path = SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kStageData01);
        // ロード
        TextAsset data = (TextAsset)Resources.Load(path);
        // 改行されているときのために文字列結合
        {
            System.IO.StringReader reader = new System.IO.StringReader(data.text);
            //List<string> stringDatas = new List<string>();
            string jsonString = "";
            while (reader.Peek() != -1) {
                // 1行ずつ読み込み
                string line = reader.ReadLine();
                jsonString += line;
            }
            // 表示
            MhCommon.Print(jsonString);
        }
        return true;
    }

    public StgEnemyPopperData[] Get() {
        return null;
    }

    private string resourcePath;
}
