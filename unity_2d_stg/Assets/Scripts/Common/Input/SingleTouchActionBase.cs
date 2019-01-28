using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleTouchActionBase {

	public SingleTouchActionBase() {
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public virtual void Initialize() {
		touchInfo = new TouchInfo[kTouchInfoMax];
		for (int i = 0; i < kTouchInfoMax; ++i) {
			touchInfo[i] = new TouchInfo();
		}
		displayWidth = 0;
		displayHeight = 0;
	}

	/// <summary>
	/// 更新処理
	/// </summary>
	public virtual void Update() {
	}

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
	public virtual void Reset() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionBase::Reset touchInfo null");
		int size = touchInfo.Length;
		for (int i = 0; i < size; ++i) {
			MhCommon.Assert(touchInfo[i] != null, "SingleTouchActionBase::Reset touchInfo[i] null");
			touchInfo[i].Clear();
		}
	}

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
	public virtual void Print() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionBase::Print touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionBase::Print touchInfo[kCurrentFrame] null");
		MhCommon.Assert(touchInfo[kBefore1Frame] != null, "SingleTouchActionBase::Print touchInfo[kBefore1Frame] null");
		touchInfo[kCurrentFrame].Print();
		touchInfo[kBefore1Frame].Print();
	}

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
	public virtual void PrintDifference() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionBase::PrintDifference touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionBase::PrintDifference touchInfo[kCurrentFrame] null");
		MhCommon.Assert(touchInfo[kBefore1Frame] != null, "SingleTouchActionBase::PrintDifference touchInfo[kBefore1Frame] null");
        if (touchInfo[kCurrentFrame].Equals(touchInfo[kBefore1Frame]) == false) {
            touchInfo[kCurrentFrame].Print();
        }
	}

	/// <summary>
	/// ディスプレイサイズを設定(初期化後に行うこと)
	/// </summary>
	/// <param name="width">ディスプレイサイズ横幅</param>
	/// <param name="height">ディスプレイサイズ縦幅</param>
    public virtual void SetDisplaySize(int width, int height) {
        displayWidth = width;
        displayHeight = height;
    }

    /// <summary>
    /// システムから取得した情報から現在の情報を設定
    /// </summary>
    protected virtual void SetTouchInfoPc() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionBase::SetTouchInfoPc touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionBase::SetTouchInfoPc touchInfo[kCurrentFrame] null");
		MhCommon.Assert(touchInfo[kBefore1Frame] != null, "SingleTouchActionBase::SetTouchInfoPc touchInfo[kBefore1Frame] null");

        // 前の状態を保存
        touchInfo[kBefore1Frame].Copy(touchInfo[kCurrentFrame]);

        TouchInfo.TouchStatus status = touchInfo[kCurrentFrame].status;
		TouchInfo.TouchStatus beforeStatus = touchInfo[kBefore1Frame].status;
        switch (status) {
            case TouchInfo.TouchStatus.kNone:
                // 押したりしていない状態で押されたらBeganへ移行
                if (Input.GetMouseButtonDown(0) == true) {
                    touchInfo[kCurrentFrame].touchId = 0;
                    touchInfo[kCurrentFrame].position = Input.mousePosition;
                    touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kBegan;
					ChangeTouchStatusBeganPlatformPc(beforeStatus);
					OnTouchStatusBeganPlatformPc();
                } else {
                    // デフォルト
                    touchInfo[kCurrentFrame].Clear();
					OnTouchStatusNonePlatformPc();
                }
                break;
            case TouchInfo.TouchStatus.kBegan:
                // 位置を設定
                touchInfo[kCurrentFrame].position = Input.mousePosition;
                if (Input.GetMouseButton(0) == true) {
                    if (touchInfo[kCurrentFrame].IsPositionEquals(touchInfo[kBefore1Frame]) == true) {
                        touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kStationary;
						ChangeTouchStatusStationaryPlatformPc(beforeStatus);
						OnTouchStatusStationaryPlatformPc();
                    } else {
                        touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kMoved;
						ChangeTouchStatusMovedPlatformPc(beforeStatus);
						OnTouchStatusMovedPlatformPc();
                    }
                } else {
                    // 持ち上げられたのでkEndedへ
                    touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kEnded;
					ChangeTouchStatusEndedPlatformPc(beforeStatus);
					OnTouchStatusEndedPlatformPc();
                }
                break;
            case TouchInfo.TouchStatus.kMoved:
                touchInfo[kCurrentFrame].position = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kEnded;
					ChangeTouchStatusEndedPlatformPc(beforeStatus);
					OnTouchStatusEndedPlatformPc();
                } else {
                    // 移動してないならkStationary 移動していたらkMoved
                    if (touchInfo[kCurrentFrame].IsPositionEquals(touchInfo[kBefore1Frame]) == true) {
                        touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kStationary;
						ChangeTouchStatusStationaryPlatformPc(beforeStatus);
						OnTouchStatusStationaryPlatformPc();
                    } else {
                        touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kMoved;
						//ChangeTouchStatusMovedPlatformPc(beforeStatus);
						OnTouchStatusMovedPlatformPc();
                    }
                }
                break;
            case TouchInfo.TouchStatus.kStationary:
                touchInfo[kCurrentFrame].position = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kEnded;
					ChangeTouchStatusEndedPlatformPc(beforeStatus);
					OnTouchStatusEndedPlatformPc();
                } else {
                    // 移動してないならkStationary 移動していたらkMoved
                    if (touchInfo[kCurrentFrame].IsPositionEquals(touchInfo[kBefore1Frame]) == true) {
                        touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kStationary;
						//ChangeTouchStatusStationaryPlatformPc(beforeStatus);
						OnTouchStatusStationaryPlatformPc();
                    } else {
                        touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kMoved;
						ChangeTouchStatusMovedPlatformPc(beforeStatus);
						OnTouchStatusMovedPlatformPc();
                    }
                }
                break;
            case TouchInfo.TouchStatus.kEnded:
            case TouchInfo.TouchStatus.kCanceled:
                // 終わった後に押されたらkBeganへ移行
                if (Input.GetMouseButton(0) == false) {
                    // デフォルト状態に戻す
                    touchInfo[kCurrentFrame].Clear();
					ChangeTouchStatusNonePlatformPc(beforeStatus);
					OnTouchStatusNonePlatformPc();
                } else {
                    // タッチIDは0固定
                    touchInfo[kCurrentFrame].touchId = 0;
                    // 位置
                    touchInfo[kCurrentFrame].position = Input.mousePosition;
                    touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kBegan;
					ChangeTouchStatusBeganPlatformPc(beforeStatus);
					OnTouchStatusBeganPlatformPc();
                }
                break;
            default:
                break;
        }
    }

	/// <summary>
	/// ステータスがなしに切り替わり時に呼ばれる
	/// </summary>
	/// <param name="beforeStatus"></param>
	protected virtual void ChangeTouchStatusNonePlatformPc(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusBeganPlatformPc(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusMovedPlatformPc(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusStationaryPlatformPc(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusEndedPlatformPc(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusCanceledPlatformPc(TouchInfo.TouchStatus beforeStatus) {
	}

	/// <summary>
	/// ステータスがなしのときにずっと呼ばれる
	/// </summary>
	protected virtual void OnTouchStatusNonePlatformPc() {
	}

	protected virtual void OnTouchStatusBeganPlatformPc() {
	}

	protected virtual void OnTouchStatusMovedPlatformPc() {
	}

	protected virtual void OnTouchStatusStationaryPlatformPc() {
	}

	protected virtual void OnTouchStatusEndedPlatformPc() {
	}

	protected virtual void OnTouchStatusCanceledPlatformPc() {
	}


    /// <summary>
    /// システムの情報から現在の情報を設定
    /// </summary>
    /// <param name="touch"></param>
    protected virtual void SetCurrentInfoByTouch(Touch touch) {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionBase::SetCurrentInfoByTouch touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionBase::SetCurrentInfoByTouch touchInfo[kCurrentFrame] null");

        touchInfo[kCurrentFrame].touchId = touch.fingerId;
        touchInfo[kCurrentFrame].position = touch.position;

        switch (touch.phase) {
            case TouchPhase.Began:
                touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kBegan;
                break;
            case TouchPhase.Moved:
                touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kMoved;
                break;
            case TouchPhase.Stationary:
                touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kStationary;
                break;
            case TouchPhase.Ended:
                touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kEnded;
                break;
            case TouchPhase.Canceled:
                touchInfo[kCurrentFrame].status = TouchInfo.TouchStatus.kCanceled;
                break;
            default:
                break;
        }
    }

	protected virtual void ChangeTouchStatusNonePlatformSmartPhone(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusBeganPlatformSmartPhone(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusMovedPlatformSmartPhone(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusStationaryPlatformSmartPhone(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusEndedPlatformSmartPhone(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void ChangeTouchStatusCanceledPlatformSmartPhone(TouchInfo.TouchStatus beforeStatus) {
	}

	protected virtual void SetTouchInfoSmartPhone() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionBase::SetTouchInfoSmartPhone touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionBase::SetTouchInfoSmartPhone touchInfo[kCurrentFrame] null");
		MhCommon.Assert(touchInfo[kBefore1Frame] != null, "SingleTouchActionBase::SetTouchInfoSmartPhone touchInfo[kBefore1Frame] null");

        // 前の状態を保存
        touchInfo[kBefore1Frame].Copy(touchInfo[kCurrentFrame]);

        int id = touchInfo[kCurrentFrame].touchId;
        int touchCount = Input.touchCount;
		TouchInfo.TouchStatus beforeStatus = touchInfo[kBefore1Frame].status;
        // 情報をリセット
        touchInfo[kCurrentFrame].Clear();

        if (touchCount <= 0) {
            // タッチ情報なし
			if (touchInfo[kBefore1Frame].status != TouchInfo.TouchStatus.kNone) {
				// タッチ情報なしに切り替わった
				ChangeTouchStatusNonePlatformSmartPhone(beforeStatus);
			}
            return;
        }

        // タッチIDが有効なので前回と同じタッチIDを探す
        if (TouchInfo.IsTouchIdInvalid(id) == false) {
            for (int i = 0; i < touchCount; ++i) {
                if (id == Input.GetTouch(i).fingerId) {
                    // 情報をセット
                    SetCurrentInfoByTouch(Input.GetTouch(i));
					if (touchInfo[kBefore1Frame].status != touchInfo[kCurrentFrame].status) {
						if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kBegan) {
							ChangeTouchStatusBeganPlatformSmartPhone(beforeStatus);
						} else if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kMoved) {
							ChangeTouchStatusMovedPlatformSmartPhone(beforeStatus);
						} else if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kStationary) {
							ChangeTouchStatusStationaryPlatformSmartPhone(beforeStatus);
						} else if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kEnded) {
							ChangeTouchStatusEndedPlatformSmartPhone(beforeStatus);
						} else if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kCanceled) {
							ChangeTouchStatusCanceledPlatformSmartPhone(beforeStatus);
						}
					}
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
                SetCurrentInfoByTouch(Input.GetTouch(0));
				ChangeTouchStatusBeganPlatformSmartPhone(beforeStatus);
            }
        }
	}

    /// <summary>
    /// ディスプレイの縦横比を加味したpositionを取得
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    protected Vector3 GetTouchPosition(float width, float height, Vector3 position) {
        Vector3 v;
        float ratioX = ((float)width / (float)Screen.width);
        float ratioY = ((float)height / (float)Screen.height);

        //float offset_x = width - ((float)Screen.width * ratio_x) / 2;

        v.x = position.x * ratioX;
        v.y = position.y * ratioY;
        v.z = position.z;
        return v;
    }

	protected static readonly int kTouchInfoMax = 2;
	protected static readonly int kCurrentFrame = 0;
	protected static readonly int kBefore1Frame = 1;

	protected TouchInfo[] touchInfo { set; get; } // タッチ情報配列[0]が最新[1]が前フレーム[2]が前々フレーム
    //protected TouchInfo currentTouchInfo { set; get; }
    //protected TouchInfo touchInfo[kBefore1Frame] { set; get; }
    protected int displayWidth { set; get; }
    protected int displayHeight { set; get; }
}
