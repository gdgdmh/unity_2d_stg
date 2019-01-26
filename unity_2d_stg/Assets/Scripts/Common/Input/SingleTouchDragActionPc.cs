using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchDragActionPc : SingleTouchActionBase, ISingleTouchDragActionable {

    public SingleTouchDragActionPc() {
		Initialize();
    }

    public SingleTouchDragActionPc(int displayWidth, int displayHeight) {
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

	public override void Reset() {
		base.Reset();
		{
			Vector3 resetPosition = dragStartPosition;
			resetPosition.x = 0.0f;
			resetPosition.y = 0.0f;
			resetPosition.z = 0.0f;
			dragStartPosition = resetPosition;
		}
		{
			Vector3 resetPosition = dragCurrentPosition;
			resetPosition.x = 0.0f;
			resetPosition.y = 0.0f;
			resetPosition.z = 0.0f;
			dragCurrentPosition = resetPosition;
		}
		{
			Vector3 resetPosition = dragEndPosition;
			resetPosition.x = 0.0f;
			resetPosition.y = 0.0f;
			resetPosition.z = 0.0f;
			dragEndPosition = resetPosition;
		}
	}

	protected override void ChangeTouchStatusNonePlatformPc(TouchInfo.TouchStatus beforeStatus) {
		base.ChangeTouchStatusNonePlatformPc(beforeStatus);
	}

	protected override void ChangeTouchStatusBeganPlatformPc(TouchInfo.TouchStatus beforeStatus) {
		base.ChangeTouchStatusBeganPlatformPc(beforeStatus);
		dragStartPosition = currentTouchInfo.position;
		dragCurrentPosition = currentTouchInfo.position;
	}

	protected override void ChangeTouchStatusMovedPlatformPc(TouchInfo.TouchStatus beforeStatus) {
		base.ChangeTouchStatusMovedPlatformPc(beforeStatus);
		dragCurrentPosition = currentTouchInfo.position;
	}

	protected override void ChangeTouchStatusStationaryPlatformPc(TouchInfo.TouchStatus beforeStatus) {
		base.ChangeTouchStatusStationaryPlatformPc(beforeStatus);
		dragCurrentPosition = currentTouchInfo.position;
	}

	protected override void ChangeTouchStatusEndedPlatformPc(TouchInfo.TouchStatus beforeStatus) {
		base.ChangeTouchStatusEndedPlatformPc(beforeStatus);
		dragEndPosition = currentTouchInfo.position;
		dragCurrentPosition = currentTouchInfo.position;
	}

	protected override void ChangeTouchStatusCanceledPlatformPc(TouchInfo.TouchStatus beforeStatus) {
		base.ChangeTouchStatusCanceledPlatformPc(beforeStatus);
		dragEndPosition = currentTouchInfo.position;
		dragCurrentPosition = currentTouchInfo.position;
	}

	/// <summary>
	/// ステータスがなしのときにずっと呼ばれる
	/// </summary>
	protected override void OnTouchStatusNonePlatformPc() {
		base.OnTouchStatusNonePlatformPc();
	}

	protected override void OnTouchStatusBeganPlatformPc() {
		base.OnTouchStatusBeganPlatformPc();
	}

	protected override void OnTouchStatusMovedPlatformPc() {
		base.OnTouchStatusMovedPlatformPc();
		// 位置を更新
		dragCurrentPosition = currentTouchInfo.position;
	}

	protected override void OnTouchStatusStationaryPlatformPc() {
		base.OnTouchStatusStationaryPlatformPc();
	}

	protected override void OnTouchStatusEndedPlatformPc() {
		base.OnTouchStatusEndedPlatformPc();
	}

	protected override void OnTouchStatusCanceledPlatformPc() {
		base.OnTouchStatusCanceledPlatformPc();
	}

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

	/// <summary>
	/// ディスプレイサイズを設定する(タッチ位置取得時に使用)
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	void ISingleTouchDragActionable.SetDisplaySize(int width, int height) {
		SetDisplaySize(width, height);
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragNone() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kNone) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragBegan() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kBegan) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragMoved() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kMoved) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool ISingleTouchDragActionable.IsDragStationary() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kStationary) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool ISingleTouchDragActionable.IsDragEnded() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kEnded) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool ISingleTouchDragActionable.IsDragCanceled() {
        if (currentTouchInfo.status == TouchInfo.TouchStatus.kCanceled) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ドラッグ中かどうか
    /// </summary>
    /// <returns>ドラッグ中ならtrue</returns>
    bool ISingleTouchDragActionable.IsDragging() {
        TouchInfo.TouchStatus status = currentTouchInfo.status;
        if ((status == TouchInfo.TouchStatus.kBegan) || (status == TouchInfo.TouchStatus.kMoved) || (status == TouchInfo.TouchStatus.kStationary)) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// アプリケーション上でのドラッグ開始位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetApplicationDragStartPosition() {
        return GetTouchPosition(displayWidth, displayHeight, dragStartPosition);
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetRawDragStartPosition() {
        return dragStartPosition;
    }

    /// <summary>
    /// アプリケーション上でのドラッグ中の現在位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetApplicationDragCurrentPosition() {
        return GetTouchPosition(displayWidth, displayHeight, dragCurrentPosition);
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ中現在位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetRawDragCurrentPosition() {
        return dragCurrentPosition;
    }

    /// <summary>
    /// アプリケーション上でのドラッグ終了位置を取得する
    /// 必ずしもディスプレイサイズと同じではない
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetApplicationDragEndPosition() {
        return GetTouchPosition(displayWidth, displayHeight, dragEndPosition);
    }

    /// <summary>
    /// システムから取得できる無加工のドラッグ終了位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchDragActionable.GetRawDragEndPosition() {
        return dragEndPosition;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void ISingleTouchDragActionable.Initialize() {
		Initialize();
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    void ISingleTouchDragActionable.Update() {
		Update();
        //SetTouchInfo();
    }

    /// <summary>
    /// データのリセットを行う(displayWidthなどは例外)
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    void ISingleTouchDragActionable.Reset() {
		Reset();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void ISingleTouchDragActionable.Print() {
        Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void ISingleTouchDragActionable.PrintDifference() {
		PrintDifference();
    }

    private Vector3 dragStartPosition { set; get; }
    private Vector3 dragCurrentPosition { set; get; }
    private Vector3 dragEndPosition { set; get; }
}
