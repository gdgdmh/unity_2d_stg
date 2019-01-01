using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerController : MonoBehaviour, IStgPlayerController
{
    public StgPlayerController() {
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void IStgPlayerController.Update() {
    }

    /// <summary>
    /// 左に移動
    /// </summary>
    void IStgPlayerController.MoveLeft() {
    }

    /// <summary>
    /// 右に移動
    /// </summary>
    void IStgPlayerController.MoveRight() {

    }

    /// <summary>
    /// 上に移動
    /// </summary>
    void IStgPlayerController.MoveUp() {
    }

    /// <summary>
    /// 下に移動
    /// </summary>
    void IStgPlayerController.MoveDown() {
    }

    /// <summary>
    /// ショットを行う
    /// </summary>
    void IStgPlayerController.Shoot() {
    }

    /// <summary>
    /// ショットを行うことができるか
    /// </summary>
    /// <returns><c>true</c>ショットを行うことができる<c>false</c>ショットを行うことができない</returns>
    bool IStgPlayerController.CanShoot() {
        return false;
    }


}
