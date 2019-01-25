using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchActionPc : SingleTouchActionBase, ISingleTouchActionable {

    public SingleTouchActionPc() {
		Initialize();
    }

    public SingleTouchActionPc(int displayWidth, int displayHeight) {
		Initialize();
        this.displayWidth = displayWidth;
        this.displayHeight = displayHeight;
    }

	/// <summary>
	/// 初期化
	/// </summary>
	public override void Initialize() {
		base.Initialize();
	}

	/// <summary>
	/// 更新処理
	/// </summary>
	public override void Update() {
		SetTouchInfoPc();
	}

    void ISingleTouchActionable.SetDisplaySize(int width, int height) {
		SetDisplaySize(width, height);
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    bool ISingleTouchActionable.IsTouchNone() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kNone) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool ISingleTouchActionable.IsTouchBegan() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kBegan) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool ISingleTouchActionable.IsTouchMoved() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kMoved) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool ISingleTouchActionable.IsTouchStationary() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kStationary) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool ISingleTouchActionable.IsTouchEnded() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kEnded) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool ISingleTouchActionable.IsTouchCanceled() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kCanceled) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ドラッグ動作をしているか
    /// </summary>
    /// <returns><c>true</c>ドラッグ動作をしている<c>false</c>ドラッグ動作をしていない</returns>
    bool ISingleTouchActionable.IsDragging() {
        TouchInfo.TouchStatus status = currentTouchInfo.status;
        if ((status == TouchInfo.TouchStatus.kBegan) || (status == TouchInfo.TouchStatus.kMoved) || (status == TouchInfo.TouchStatus.kStationary)) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// アプリケーション上でのタッチ位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchActionable.GetApplicationTouchPosition() {
        return GetTouchPosition(displayWidth, displayHeight, currentTouchInfo.position);
    }


    /// <summary>
    /// システムから取得できる無加工のタッチ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchActionable.GetRawTouchPosition() {
        return currentTouchInfo.position;
    }

    /// <summary>
    /// ドラッグ開始位置を取得する
    /// </summary>
    /// <returns>ドラッグを開始した位置を取得する</returns>
    Vector3 ISingleTouchActionable.GetDragStartPosition() {
		return new Vector3(0,0,0);
        //return GetTouchPosition(displayWidth, displayHeight, dragStartPosition);
    }

    /// <summary>
    /// ドラッグ中の現在位置を取得する
    /// </summary>
    /// <returns>ドラッグ中の現在位置</returns>
    Vector3 ISingleTouchActionable.GetDragCurrentPosition() {
		return new Vector3(0,0,0);
        //return GetTouchPosition(displayWidth, displayHeight, dragCurrentPosition);
    }

    /// <summary>
    /// ドラッグ終了位置を取得する
    /// </summary>
    /// <returns>ドラッグを終了した位置を取得する</returns>
    Vector3 ISingleTouchActionable.GetDragEndPosition() {
		return new Vector3(0,0,0);
        //return GetTouchPosition(displayWidth, displayHeight, dragEndPosition);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void ISingleTouchActionable.Initialize() {
		Initialize();
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    void ISingleTouchActionable.Update() {
		Update();
    }

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    void ISingleTouchActionable.Reset() {
        currentTouchInfo.Clear();
        pastTouchInfo.Clear();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void ISingleTouchActionable.Print() {
        currentTouchInfo.Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void ISingleTouchActionable.PrintDifference() {
        if (currentTouchInfo.Equals(pastTouchInfo) == false) {
            currentTouchInfo.Print();
        }
    }

    /// <summary>
    /// 前回とタッチ状態が異なっていたら出力
    /// </summary>
    //public void PrintDifference() {
    //    if (currentTouchInfo.Equals(pastTouchInfo) == false) {
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
    //private Vector3 GetTouchPosition(float width, float height, Vector3 position) {
    //    Vector3 v;
    //    float ratioX = ((float)width / (float)Screen.width);
    //    float ratioY = ((float)height / (float)Screen.height);
	//
    //    //float offset_x = width - ((float)Screen.width * ratio_x) / 2;
	//
    //    v.x = position.x * ratioX;
    //    v.y = position.y * ratioY;
    //    v.z = position.z;
    //    return v;
    //}

    /// <summary>
    /// システムから取得した情報から現在の情報を設定
    /// </summary>
	/*
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
                    dragStartPosition = Input.mousePosition;
                    dragCurrentPosition = Input.mousePosition;
                } else {
                    // デフォルト
                    currentInfo.Clear();
                }
                break;
            case TouchInfo.TouchStatus.kBegan:
                // 位置を設定
                currentInfo.position = Input.mousePosition;
                dragCurrentPosition = Input.mousePosition;
                if (Input.GetMouseButton(0) == true) {
                    if (currentInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentInfo.status = TouchInfo.TouchStatus.kStationary;
                    } else {
                        currentInfo.status = TouchInfo.TouchStatus.kMoved;
                    }
                }
                else {
                    dragEndPosition = Input.mousePosition;
                    // 持ち上げられたのでkEndedへ
                    currentInfo.status = TouchInfo.TouchStatus.kEnded;
                }
                break;
            case TouchInfo.TouchStatus.kMoved:
                currentInfo.position = Input.mousePosition;
                dragCurrentPosition = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    currentInfo.status = TouchInfo.TouchStatus.kEnded;
                    dragEndPosition = Input.mousePosition;
                }
                else {
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
                dragCurrentPosition = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    currentInfo.status = TouchInfo.TouchStatus.kEnded;
                    dragEndPosition = Input.mousePosition;
                }
                else {
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
                    dragCurrentPosition = Input.mousePosition;
                }
                break;
            default:
                break;
        }
    }
	*/

    //private TouchInfo currentInfo { set; get; }
    //private TouchInfo pastTouchInfo { set; get; }
    //private Vector3 dragStartPosition { set; get; }
    //private Vector3 dragCurrentPosition { set; get; }
    //private Vector3 dragEndPosition { set; get; }
}
