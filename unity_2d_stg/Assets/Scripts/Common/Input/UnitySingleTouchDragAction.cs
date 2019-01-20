using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySingleTouchDragAction
{
    public UnitySingleTouchDragAction() {
    }

    /// <summary>
    /// ディスプレイサイズを設定する(タッチ位置取得時に使用)
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetDisplaySize(int width, int height) {
        singleTouchDragActionable.SetDisplaySize(width, height);
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    public bool IsDragNone() {
        return singleTouchDragActionable.IsDragNone();
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    public bool IsDragBegan() {
        return singleTouchDragActionable.IsDragBegan();
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    public bool IsDragMoved() {
        return singleTouchDragActionable.IsDragMoved();
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    public bool IsDragStationary() {
        return singleTouchDragActionable.IsDragStationary();
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    public bool IsDragEnded() {
        return singleTouchDragActionable.IsDragEnded();
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    public bool IsDragCanceled() {
        return singleTouchDragActionable.IsDragCanceled();
    }

    /// <summary>
    /// ドラッグ中かどうか
    /// </summary>
    /// <returns>ドラッグ中ならtrue</returns>
    public bool IsDragging() {
        return singleTouchDragActionable.IsDragging();
    }

    /// <summary>
    /// アプリケーション上でのドラッグ開始位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    public Vector3 GetApplicationDragStartPosition() {
        return singleTouchDragActionable.GetApplicationDragStartPosition();
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ位置を取得する
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRawDragStartPosition() {
        return singleTouchDragActionable.GetRawDragStartPosition();
    }

    /// <summary>
    /// アプリケーション上でのドラッグ中の現在位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    public Vector3 GetApplicationDragCurrentPosition() {
        return singleTouchDragActionable.GetApplicationDragCurrentPosition();
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ中現在位置を取得する
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRawDragCurrentPosition() {
        return singleTouchDragActionable.GetRawDragCurrentPosition();
    }

    /// <summary>
    /// アプリケーション上でのドラッグ終了位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 GetApplicationDragEndPosition() {
        return singleTouchDragActionable.GetApplicationDragEndPosition();
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ終了位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 GetRawDragEndPosition() {
        return singleTouchDragActionable.GetRawDragEndPosition();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize() {
        singleTouchDragActionable = new SingleTouchDragActionPc();
        singleTouchDragActionable.Initialize();
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    public void Update() {
        singleTouchDragActionable.Update();
    }

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    public void Reset() {
        singleTouchDragActionable.Reset();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    public void Print() {
        singleTouchDragActionable.Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    public void PrintDifference() {
        singleTouchDragActionable.PrintDifference();
    }

    private ISingleTouchDragActionable singleTouchDragActionable;
}
