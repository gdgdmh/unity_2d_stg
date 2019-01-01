using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchActionSmartPhone : ISingleTouchActionable {

    private TouchInfo currentInfo { set; get; }
    private TouchInfo pastTouchInfo { set; get; }
    private int displayWidth { set; get; }
    private int displayHeight { set; get; }

    public SingleTouchActionSmartPhone() {
        this.displayWidth = 0;
        this.displayHeight = 0;
    }

    public SingleTouchActionSmartPhone(int displayWidth, int displayHeight) {
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
    /// ドラッグ動作をしているか
    /// </summary>
    /// <returns><c>true</c>ドラッグ動作をしている<c>false</c>ドラッグ動作をしていない</returns>
    bool ISingleTouchActionable.IsDragging() {
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
    /// ドラッグ開始位置を取得する
    /// </summary>
    /// <returns>ドラッグを開始した位置を取得する</returns>
    Vector3 ISingleTouchActionable.GetDragStartPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// ドラッグ中の現在位置を取得する
    /// </summary>
    /// <returns>ドラッグ中の現在位置</returns>
    Vector3 ISingleTouchActionable.GetDragCurrentPosition() {
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// ドラッグ終了位置を取得する
    /// </summary>
    /// <returns>ドラッグを終了した位置を取得する</returns>
    Vector3 ISingleTouchActionable.GetDragEndPosition() {
        return new Vector3(0, 0, 0);
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
    /// システムの情報から現在の情報を設定
    /// </summary>
    /// <param name="touch"></param>
    private void SetCurrentInfo(Touch touch) {
        currentInfo.touchId = touch.fingerId;
        currentInfo.position = touch.position;

        switch (touch.phase) {
            case TouchPhase.Began:
                currentInfo.status = TouchInfo.TouchStatus.kBegan;
                break;
            case TouchPhase.Moved:
                currentInfo.status = TouchInfo.TouchStatus.kMoved;
                break;
            case TouchPhase.Stationary:
                currentInfo.status = TouchInfo.TouchStatus.kStationary;
                break;
            case TouchPhase.Ended:
                currentInfo.status = TouchInfo.TouchStatus.kEnded;
                break;
            case TouchPhase.Canceled:
                currentInfo.status = TouchInfo.TouchStatus.kCanceled;
                break;
            default:
                break;
        }
    }

    private void SetTouchInfo() {
        // 前の状態を保存
        pastTouchInfo.Copy(currentInfo);

        int id = currentInfo.touchId;
        int touchCount = Input.touchCount;
        // 情報をリセット
        currentInfo.Clear();

        if (touchCount <= 0) {
            // タッチ情報なし
            return;
        }

        // タッチIDが有効なので前回と同じタッチIDを探す
        if (TouchInfo.IsTouchIdInvalid(id) == false) {
            for (int i = 0; i < touchCount; ++i) {
                if (id == Input.GetTouch(i).fingerId) {
                    // 情報をセット
                    SetCurrentInfo(Input.GetTouch(i));
                    return;
                }
            }
        } else {
            // 既存のタッチがないので新規のタッチがあったら情報をセット
            // 普通はBeganになるはず
            // 逆にいきなり変なステータスになっているのを適用したら不自然と思うのでやらない
            // (特定の機種のみ異常な動作になる可能性も考慮)
            // 将来的には検証して有りにするは可能性あり
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                SetCurrentInfo(Input.GetTouch(0));
            }
        }
    }
}
