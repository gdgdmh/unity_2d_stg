using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISingleTouchDragActionable {

    /// <summary>
    /// ディスプレイサイズを設定する(タッチ位置取得時に使用)
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    void SetDisplaySize(int width, int height);

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    bool IsDragNone();

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool IsDragBegan();

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool IsDragMoved();

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool IsDragStationary();

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool IsDragEnded();

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool IsDragCanceled();

    /// <summary>
    /// ドラッグ中かどうか
    /// </summary>
    /// <returns>ドラッグ中ならtrue</returns>
    bool IsDragging();

    /// <summary>
    /// アプリケーション上でのドラッグ開始位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 GetApplicationDragStartPosition();

    /// <summary>
    /// システムから取得できる無加工のドラッグ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 GetRawDragStartPosition();

    /// <summary>
    /// アプリケーション上でのドラッグ中の現在位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 GetApplicationDragCurrentPosition();

    /// <summary>
    /// アプリケーション上でのドラッグ中の前フレームの位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
	Vector3 GetApplicationDragBefore1FramePosition();

    /// <summary>
    /// システムから取得できる無加工のドラッグ中現在位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 GetRawDragCurrentPosition();

    /// <summary>
    /// システムから取得できる無加工のドラッグ中現在位置を取得する
    /// </summary>
    /// <returns></returns>
	Vector3 GetRawDragBefore1FramePosition();

    /// <summary>
    /// アプリケーション上でのドラッグ終了位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 GetApplicationDragEndPosition();

    /// <summary>
    /// システムから取得できる無加工のドラッグ終了位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 GetRawDragEndPosition();

    /// <summary>
    /// 初期化
    /// </summary>
    void Initialize();

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    void Update();

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    void Reset();

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void Print();

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void PrintDifference();

}
