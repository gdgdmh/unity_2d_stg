using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class SceneBase : ISceneTask {

    /// <summary>
    /// シーン初期化処理
    /// </summary>
    void ISceneTask.Initialize() {
    }

    /// <summary>
    /// シーン開放処理
    /// </summary>
    void ISceneTask.Release() {
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void ISceneTask.Update() {
    }

    /// <summary>
    /// スマートフォン用非アクティブイベント
    /// </summary>
    void ISceneTask.Suspend() {
    }

    /// <summary>
    /// スマートフォン用アクティブイベント
    /// </summary>
    void ISceneTask.Resume() {
    }
}
