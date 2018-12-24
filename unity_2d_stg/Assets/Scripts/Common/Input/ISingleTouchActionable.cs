using UnityEngine;

/// <summary>
/// シングルタッチアクションインターフェイス(マルチタッチは非対応)
/// </summary>
interface ISingleTouchActionable {

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
    bool IsTouchNone();

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool IsTouchBegan();

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool IsTouchMoved();

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool IsTouchStationary();

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool IsTouchEnded();

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool IsTouchCanceled();

    /// <summary>
    /// アプリケーション上でのタッチ位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 GetApplicationTouchPosition();

    /// <summary>
    /// システムから取得できる無加工のタッチ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 GetRawTouchPosition();

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
