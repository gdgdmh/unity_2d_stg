using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンインターフェース
/// </summary>
interface ISceneTask {

    /// <summary>
    /// シーン初期化処理
    /// </summary>
    void Initialize();

    /// <summary>
    /// シーン開放処理
    /// </summary>
    void Release();

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update();

    /// <summary>
    /// スマートフォン用非アクティブイベント
    /// </summary>
    void Suspend();

    /// <summary>
    /// スマートフォン用アクティブイベント
    /// </summary>
    void Resume();

}
