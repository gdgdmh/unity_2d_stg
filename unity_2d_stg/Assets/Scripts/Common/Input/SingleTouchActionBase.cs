using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleTouchActionBase {

	public SingleTouchActionBase() {
	}

	public virtual void Initialize() {
	}

    public virtual void SetDisplaySize(int width, int height) {
        displayWidth = width;
        displayHeight = height;
    }

    /// <summary>
    /// システムから取得した情報から現在の情報を設定
    /// </summary>
    protected virtual void SetTouchInfoPc() {
        // 前の状態を保存
        pastTouchInfo.Copy(currentTouchInfo);

        TouchInfo.TouchStatus status = currentTouchInfo.status;
        switch (status) {
            case TouchInfo.TouchStatus.kNone:
                // 押したりしていない状態で押されたらBeganへ移行
                if (Input.GetMouseButtonDown(0) == true) {
                    currentTouchInfo.touchId = 0;
                    currentTouchInfo.position = Input.mousePosition;
                    currentTouchInfo.status = TouchInfo.TouchStatus.kBegan;
					ChangeTouchStatusBeganPlatformPc();
                } else {
                    // デフォルト
                    currentTouchInfo.Clear();
                }
                break;
            case TouchInfo.TouchStatus.kBegan:
                // 位置を設定
                currentTouchInfo.position = Input.mousePosition;
                if (Input.GetMouseButton(0) == true) {
                    if (currentTouchInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentTouchInfo.status = TouchInfo.TouchStatus.kStationary;
						ChangeTouchStatusStationaryPlatformPc();
                    } else {
                        currentTouchInfo.status = TouchInfo.TouchStatus.kMoved;
						ChangeTouchStatusMovedPlatformPc();
                    }
                } else {
                    // 持ち上げられたのでkEndedへ
                    currentTouchInfo.status = TouchInfo.TouchStatus.kEnded;
					ChangeTouchStatusEndedPlatformPc();
                }
                break;
            case TouchInfo.TouchStatus.kMoved:
                currentTouchInfo.position = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    currentTouchInfo.status = TouchInfo.TouchStatus.kEnded;
					ChangeTouchStatusEndedPlatformPc();
                }
                else {
                    // 移動してないならkStationary 移動していたらkMoved
                    if (currentTouchInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentTouchInfo.status = TouchInfo.TouchStatus.kStationary;
						ChangeTouchStatusStationaryPlatformPc();
                    } else {
                        currentTouchInfo.status = TouchInfo.TouchStatus.kMoved;
						ChangeTouchStatusMovedPlatformPc();
                    }
                }
                break;
            case TouchInfo.TouchStatus.kStationary:
                currentTouchInfo.position = Input.mousePosition;
                if (Input.GetMouseButton(0) == false) {
                    // 持ち上げられたのでkEndedへ
                    currentTouchInfo.status = TouchInfo.TouchStatus.kEnded;
					ChangeTouchStatusEndedPlatformPc();
                }
                else {
                    // 移動してないならkStationary 移動していたらkMoved
                    if (currentTouchInfo.IsPositionEquals(pastTouchInfo) == true) {
                        currentTouchInfo.status = TouchInfo.TouchStatus.kStationary;
						ChangeTouchStatusStationaryPlatformPc();
                    } else {
                        currentTouchInfo.status = TouchInfo.TouchStatus.kMoved;
						ChangeTouchStatusMovedPlatformPc();
                    }
                }
                break;
            case TouchInfo.TouchStatus.kEnded:
            case TouchInfo.TouchStatus.kCanceled:
                // 終わった後に押されたらkBeganへ移行
                if (Input.GetMouseButton(0) == false) {
                    // デフォルト状態に戻す
                    currentTouchInfo.Clear();
					ChangeTouchStatusNonePlatformPc();
                } else {
                    // タッチIDは0固定
                    currentTouchInfo.touchId = 0;
                    // 位置
                    currentTouchInfo.position = Input.mousePosition;
                    currentTouchInfo.status = TouchInfo.TouchStatus.kBegan;
					ChangeTouchStatusBeganPlatformPc();
                }
                break;
            default:
                break;
        }
    }

	protected virtual void ChangeTouchStatusNonePlatformPc() {
	}

	protected virtual void ChangeTouchStatusBeganPlatformPc() {
	}

	protected virtual void ChangeTouchStatusMovedPlatformPc() {
	}

	protected virtual void ChangeTouchStatusStationaryPlatformPc() {
	}

	protected virtual void ChangeTouchStatusEndedPlatformPc() {
	}

	protected virtual void ChangeTouchStatusCanceledPlatformPc() {
	}

    /// <summary>
    /// システムの情報から現在の情報を設定
    /// </summary>
    /// <param name="touch"></param>
    protected virtual void SetCurrentInfoByTouch(Touch touch) {
        currentTouchInfo.touchId = touch.fingerId;
        currentTouchInfo.position = touch.position;

        switch (touch.phase) {
            case TouchPhase.Began:
                currentTouchInfo.status = TouchInfo.TouchStatus.kBegan;
                break;
            case TouchPhase.Moved:
                currentTouchInfo.status = TouchInfo.TouchStatus.kMoved;
                break;
            case TouchPhase.Stationary:
                currentTouchInfo.status = TouchInfo.TouchStatus.kStationary;
                break;
            case TouchPhase.Ended:
                currentTouchInfo.status = TouchInfo.TouchStatus.kEnded;
                break;
            case TouchPhase.Canceled:
                currentTouchInfo.status = TouchInfo.TouchStatus.kCanceled;
                break;
            default:
                break;
        }
    }

	protected virtual void ChangeTouchStatusNonePlatformSmartPhone() {
	}

	protected virtual void ChangeTouchStatusBeganPlatformSmartPhone() {
	}

	protected virtual void ChangeTouchStatusMovedPlatformSmartPhone() {
	}

	protected virtual void ChangeTouchStatusStationaryPlatformSmartPhone() {
	}

	protected virtual void ChangeTouchStatusEndedPlatformSmartPhone() {
	}

	protected virtual void ChangeTouchStatusCanceledPlatformSmartPhone() {
	}

	protected virtual void SetTouchInfoSmartPhone() {
        // 前の状態を保存
        pastTouchInfo.Copy(currentTouchInfo);

        int id = currentTouchInfo.touchId;
        int touchCount = Input.touchCount;
        // 情報をリセット
        currentTouchInfo.Clear();

        if (touchCount <= 0) {
            // タッチ情報なし
			if (pastTouchInfo.status != TouchInfo.TouchStatus.kNone) {
				// タッチ情報なしに切り替わった
				ChangeTouchStatusNonePlatformSmartPhone();
			}
            return;
        }

        // タッチIDが有効なので前回と同じタッチIDを探す
        if (TouchInfo.IsTouchIdInvalid(id) == false) {
            for (int i = 0; i < touchCount; ++i) {
                if (id == Input.GetTouch(i).fingerId) {
                    // 情報をセット
                    SetCurrentInfoByTouch(Input.GetTouch(i));
					if (pastTouchInfo.status != currentTouchInfo.status) {
						if (currentTouchInfo.status == TouchInfo.TouchStatus.kBegan) {
							ChangeTouchStatusBeganPlatformSmartPhone();
						} else if (currentTouchInfo.status == TouchInfo.TouchStatus.kMoved) {
							ChangeTouchStatusMovedPlatformSmartPhone();
						} else if (currentTouchInfo.status == TouchInfo.TouchStatus.kStationary) {
							ChangeTouchStatusStationaryPlatformSmartPhone();
						} else if (currentTouchInfo.status == TouchInfo.TouchStatus.kEnded) {
							ChangeTouchStatusEndedPlatformSmartPhone();
						} else if (currentTouchInfo.status == TouchInfo.TouchStatus.kCanceled) {
							ChangeTouchStatusCanceledPlatformSmartPhone();
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
				ChangeTouchStatusBeganPlatformSmartPhone();
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

    private TouchInfo currentTouchInfo { set; get; }
    private TouchInfo pastTouchInfo { set; get; }
    protected int displayWidth { set; get; }
    protected int displayHeight { set; get; }
}
