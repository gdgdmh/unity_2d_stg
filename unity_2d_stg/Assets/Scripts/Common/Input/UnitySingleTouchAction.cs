using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySingleTouchAction {

    public UnitySingleTouchAction() {
    }

    /// <summary>
    /// ディスプレイサイズを設定する(タッチ位置取得時に使用)
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetDisplaySize(int width, int height) {
        singleTouchActionMain.SetDisplaySize(width, height);
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    public bool IsTouchNone() {
        return singleTouchActionMain.IsTouchNone();
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    public bool IsTouchBegan() {
        return singleTouchActionMain.IsTouchBegan();
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    public bool IsTouchMoved() {
        return singleTouchActionMain.IsTouchMoved();
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    public bool IsTouchStationary() {
        return singleTouchActionMain.IsTouchStationary();

    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    public bool IsTouchEnded() {
        return singleTouchActionMain.IsTouchEnded();
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    public bool IsTouchCanceled() {
        return singleTouchActionMain.IsTouchCanceled();
    }

    /// <summary>
    /// ドラッグ動作をしているか
    /// </summary>
    /// <returns><c>true</c>ドラッグ動作をしている<c>false</c>ドラッグ動作をしていない</returns>
    public bool IsDragging() {
        return singleTouchActionMain.IsDragging();
    }

    /// <summary>
    /// アプリケーション上でのタッチ位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    public Vector3 GetApplicationTouchPosition() {
        return singleTouchActionMain.GetApplicationTouchPosition();
    }

    /// <summary>
    /// システムから取得できる無加工のタッチ位置を取得する
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRawTouchPosition() {
        return singleTouchActionMain.GetRawTouchPosition();
    }

    /// <summary>
    /// ドラッグ開始位置を取得する
    /// </summary>
    /// <returns>ドラッグを開始した位置を取得する</returns>
    public Vector3 GetDragStartPosition() {
        return singleTouchActionMain.GetDragStartPosition();
    }

    /// <summary>
    /// ドラッグ中の現在位置を取得する
    /// </summary>
    /// <returns>ドラッグ中の現在位置</returns>
    public Vector3 GetDragCurrentPosition() {
        return singleTouchActionMain.GetDragCurrentPosition();
    }

    /// <summary>
    /// ドラッグ終了位置を取得する
    /// </summary>
    /// <returns>ドラッグを終了した位置を取得する</returns>
    public Vector3 GetDragEndPosition() {
        return singleTouchActionMain.GetDragEndPosition();
    }



    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize() {
		// プラットフォームに応じて対応したクラスを生成
        if ((Application.platform == RuntimePlatform.Android)
            || (Application.platform == RuntimePlatform.IPhonePlayer)) {
            // iOS,Android
            singleTouchActionMain = new SingleTouchActionSmartPhone();
        } else {
            singleTouchActionMain = new SingleTouchActionPc();
        }
        singleTouchActionMain.Initialize();
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    public void Update() {
        singleTouchActionMain.Update();
    }

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    public void Reset() {
        singleTouchActionMain.Reset();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    public void Print() {
        singleTouchActionMain.Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    public void PrintDifference() {
        singleTouchActionMain.PrintDifference();
    }


    // 環境によってどれかのsingleTouchActionを使用するのでその参照
    private ISingleTouchActionable singleTouchActionMain;
}
