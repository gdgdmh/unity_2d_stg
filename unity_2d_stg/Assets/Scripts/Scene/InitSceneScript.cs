using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲーム起動時に必ず行う処理をするシーン
public class InitSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        // 共有シーンの初期化
        // TODO

        // 次のシーンへ(デバッグメニュー)
        //UnityEngine.SceneManagement.SceneManager.LoadScene("DebugMenuScene");

        /*
        // 共有データの初期化
        // 重いデータがあるかもしれないのでスレッドを使用したかったけど、
        // シングルトンに対してスレッドを使用できなかったので現状は使わない
        //ShareData.Instance.Initialize();
        // 次のシーンへ
        UnityEngine.SceneManagement.SceneManager.LoadScene("debug_menu");
         */
    }
}
