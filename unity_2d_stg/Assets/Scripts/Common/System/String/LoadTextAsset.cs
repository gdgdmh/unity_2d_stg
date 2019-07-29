using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTextAsset {

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public LoadTextAsset() {
        resourcePath = "";
        text = "";
    }

    /// <summary>
    /// ロードするリソースのパスを設定する
    /// </summary>
    /// <param name="path">設定するリソースのパス</param>
    public void SetResourcePath(string path) {
        resourcePath = path;
    }

    /// <summary>
    /// リソースのロード
    /// </summary>
    /// <param name="isJoinLine">trueなら改行を結合する</param>
    /// <returns></returns>
    public bool Load(bool isJoinLine) {
        return Load(resourcePath, isJoinLine);
    }


    /// <summary>
    /// リソースのロード
    /// </summary>
    /// <param name="path">リソースのパス</param>
    /// <param name="isJoinLine">trueなら改行を結合する</param>
    /// <returns></returns>
    private bool Load(string path, bool isJoinLine) {

        if (path == null) {
            throw new System.ArgumentNullException();
        }

        this.resourcePath = path;
        TextAsset textAsset = (TextAsset)Resources.Load(resourcePath);
        if (textAsset == null) {
            // ロードできなかった
            throw new UnityResourceNotFoundException();
        }

        text = "";
        if (isJoinLine) {
            // 改行も考慮して取得
            System.IO.StringReader reader = new System.IO.StringReader(textAsset.text);
            while (reader.Peek() != -1) {
                // 1行ずつ読み込み
                string line = reader.ReadLine();
                text += line;
            }
        } else {
            text = textAsset.text;
        }
        return true;
    }

    public string Get() {
        return text;
    }

    private string resourcePath;
    private string text;
}
