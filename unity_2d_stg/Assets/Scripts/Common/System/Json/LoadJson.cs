using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jsonのロード(JsonUtilityを使用)
/// </summary>
public static class LoadJson {

    /// <summary>
    /// Jsonのロード
    /// </summary>
    /// <typeparam name="T">JsonをSerializeするクラス</typeparam>
    /// <param name="resourcePath"></param>
    /// <returns></returns>
    public static T Load<T>(string resourcePath) {
        LoadTextAsset textAsset = new LoadTextAsset();
        textAsset.SetResourcePath(resourcePath);
        bool result = textAsset.Load(true);
        T jsonItem = default(T);
        if (result) {
            jsonItem = JsonUtility.FromJson<T>(textAsset.Get());
        }
        return jsonItem;
    }

    // 配列テスト(いまくいかないので放置中)
    public static T LoadTest<T, T2>(string resourcePath) {
        LoadTextAsset textAsset = new LoadTextAsset();
        textAsset.SetResourcePath(resourcePath);
        bool result = textAsset.Load(true);
        T jsonItem = default(T);
        if (result) {
            jsonItem = (T)(object)JsonUtility.FromJson<T2>(textAsset.Get());
        }
        return jsonItem;
    }

}
