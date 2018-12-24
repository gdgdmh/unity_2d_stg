using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchActionPc : ISingleTouchActionable {

    private TouchInfo currentInfo { set; get; }
    private TouchInfo pastTouchInfo { set; get; }
    private int displayWidth { set; get; }
    private int displayHeight { set; get; }

    public SingleTouchActionPc() {
        this.displayWidth = 0;
        this.displayHeight = 0;
    }

    public SingleTouchActionPc(int displayWidth, int displayHeight) {
        this.displayWidth = displayWidth;
        this.displayHeight = displayHeight;
    }

    void ISingleTouchActionable.SetDisplaySize(int width, int height) {
        displayWidth = width;
        displayHeight = height;
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    bool ISingleTouchActionable.IsTouchNone() {
        if (currentInfo.status == TouchInfo.TouchStatus.kNone) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool ISingleTouchActionable.IsTouchBegan() {
        if (currentInfo.status == TouchInfo.TouchStatus.kBegan) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool ISingleTouchActionable.IsTouchMoved() {
        if (currentInfo.status == TouchInfo.TouchStatus.kMoved) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool ISingleTouchActionable.IsTouchStationary() {
        if (currentInfo.status == TouchInfo.TouchStatus.kStationary) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool ISingleTouchActionable.IsTouchEnded() {
        if (currentInfo.status == TouchInfo.TouchStatus.kEnded) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool ISingleTouchActionable.IsTouchCanceled() {
        if (currentInfo.status == TouchInfo.TouchStatus.kCanceled) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// アプリケーション上でのタッチ位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchActionable.GetApplicationTouchPosition() {
        return GetTouchPosition(displayWidth, displayHeight, currentInfo.position);
    }

    /// <summary>
    /// システムから取得できる無加工のタッチ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchActionable.GetRawTouchPosition() {
        return currentInfo.position;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void ISingleTouchActionable.Initialize() {
        currentInfo = new TouchInfo();
        pastTouchInfo = new TouchInfo();
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    void ISingleTouchActionable.Update() {
        SetTouchInfo();
    }

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    void ISingleTouchActionable.Reset() {
        currentInfo.Clear();
        pastTouchInfo.Clear();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void ISingleTouchActionable.Print() {
        currentInfo.Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void ISingleTouchActionable.PrintDifference() {
        if (currentInfo.Equals(pastTouchInfo) == false) {
            currentInfo.Print();
        }
    }

    /// <summary>
    /// 前回とタッチ状態が異なっていたら出力
    /// </summary>
    //public void PrintDifference() {
    //    if (currentInfo.Equals(pastTouchInfo) == false) {
    //        currentInfo.Print();
    //    }
    //}

    /// <summary>
    /// ディスプレイの縦横比を加味したpositionを取得
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    private Vector3 GetTouchPosition(float width, float height, Vector3 position) {
        Vector3 v;
        float ratioX = ((float)width / (float)Screen.width);
        float ratioY = ((float)height / (float)Screen.height);

        //float offset_x = width - ((float)Screen.width * ratio_x) / 2;

        v.x = position.x * ratioX;
        v.y = position.y * ratioY;
        v.z = position.z;
        return v;
    }

    /// <summary>
    /// システムから取得した情報から現在の情報を設定
    /// </summary>
    private void SetTouchInfo() {
        // 前の状態を保存
        pastTouchInfo.Copy(currentInfo);

        TouchInfo.TouchStatus status = currentInfo.status;
        switch (status) {
            case TouchInfo.TouchStatus.kNone:
                // 押したりしていない状態で押されたらBeganへ移行
                if (Input.GetMouseButtonDown(0) == true) {
                    currentInfo.touchId = 0;
                    currentInfo.position = Input.mousePosition;
                    currentInfo.status = TouchInfo.TouchStatus.kBegan;
                } else {
                    // デフォルト
                    currentInfo.Clear();
                }
                break;
            case TouchInfo.TouchStatus.kBegan:
                // 位置を設定
                currentInfo.position = Input.mousePosition;
                if (Input.GetMouseButton(0) == true) {
                    if (currentInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentInfo.status = TouchInfo.TouchStatus.kStationary;
                    } else {
                        currentInfo.status = TouchInfo.TouchStatus.kMoved;
                    }
                } else {
                    // 持ち上げられたのでkEndedへ
                    currentInfo.status = TouchInfo.TouchStatus.kEnded;
                }
                break;
            case TouchInfo.TouchStatus.kMoved:
                currentInfo.position = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    currentInfo.status = TouchInfo.TouchStatus.kEnded;
                } else {
                    // 移動してないならkStationary 移動していたらkMoved
                    if (currentInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentInfo.status = TouchInfo.TouchStatus.kStationary;
                    } else {
                        currentInfo.status = TouchInfo.TouchStatus.kMoved;
                    }
                }
                break;
            case TouchInfo.TouchStatus.kStationary:
                currentInfo.position = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    currentInfo.status = TouchInfo.TouchStatus.kEnded;
                } else {
                    // 移動してないならkStationary 移動していたらkMoved
                    if (currentInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentInfo.status = TouchInfo.TouchStatus.kStationary;
                    } else {
                        currentInfo.status = TouchInfo.TouchStatus.kMoved;
                    }

                }
                break;
            case TouchInfo.TouchStatus.kEnded:
            case TouchInfo.TouchStatus.kCanceled:
                // 終わった後に押されたらkBeganへ移行
                if (Input.GetMouseButton(0) == false) {
                    // デフォルト状態に戻す
                    currentInfo.Clear();
                } else {
                    // タッチIDは0固定
                    currentInfo.touchId = 0;
                    // 位置
                    currentInfo.position = Input.mousePosition;
                    currentInfo.status = TouchInfo.TouchStatus.kBegan;
                }
                break;
            default:
                break;
        }
    }
}
