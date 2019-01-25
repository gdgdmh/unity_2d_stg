using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTouchActionSmartPhone : SingleTouchActionBase, ISingleTouchActionable {

    public SingleTouchActionSmartPhone() {
		Initialize();
    }

    public SingleTouchActionSmartPhone(int displayWidth, int displayHeight) {
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
		SetTouchInfoSmartPhone();
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
        return false;
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
		Initialize();
    }

    /// <summary>
    /// 更新処理
    /// (毎フレーム処理する)
    /// </summary>
    void ISingleTouchActionable.Update() {
		Update();
        //SetTouchInfo();
    }

    /// <summary>
    /// データのリセットを行う
    /// シーン移動などで以前のデータが残らないようにする
    /// </summary>
    void ISingleTouchActionable.Reset() {
		Reset();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void ISingleTouchActionable.Print() {
		Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void ISingleTouchActionable.PrintDifference() {
		PrintDifference();
    }

	/*
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
	*/
}
