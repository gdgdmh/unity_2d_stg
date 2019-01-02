using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchDragActionPc : ISingleTouchDragActionable {


    /// <summary>
    /// ディスプレイサイズを設定する(タッチ位置取得時に使用)
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    void ISingleTouchDragActionable.SetDisplaySize(int width, int height) {
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragNone() {
        return false;
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragBegan() {
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragMoved() {
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool ISingleTouchDragActionable.IsDragStationary() {
        return false;
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool ISingleTouchDragActionable.IsDragEnded() {
        return false;
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool ISingleTouchDragActionable.IsDragCanceled() {
        return false;
    }

    /// <summary>
    /// アプリケーション上でのドラッグ開始位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetApplicationDragStartPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetRawDragStartPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// アプリケーション上でのドラッグ中の現在位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetApplicationDragCurrentPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ中現在位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetRawDragCurrentPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// アプリケーション上でのドラッグ終了位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetApplicationDragEndPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ終了位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetRawDragEndPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void ISingleTouchDragActionable.Initialize() {
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    void ISingleTouchDragActionable.Update() {
    }

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    void ISingleTouchDragActionable.Reset() {
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void ISingleTouchDragActionable.Print() {
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void ISingleTouchDragActionable.PrintDifference() {
    }

}
