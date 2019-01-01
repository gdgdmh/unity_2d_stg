using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム中のプレイヤーインターフェース
/// </summary>
interface IStgPlayerController {

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update();

    /// <summary>
    /// 左に移動
    /// </summary>
    void MoveLeft();

    /// <summary>
    /// 右に移動
    /// </summary>
    void MoveRight();

    /// <summary>
    /// 上に移動
    /// </summary>
    void MoveUp();

    /// <summary>
    /// 下に移動
    /// </summary>
    void MoveDown();

    /// <summary>
    /// ショットを行う
    /// </summary>
    void Shoot();

    /// <summary>
    /// ショットを行うことができるか
    /// </summary>
    /// <returns><c>true</c>ショットを行うことができる<c>false</c>ショットを行うことができない</returns>
    bool CanShoot();

}
