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
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsTouchNone touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsTouchNone touchInfo[kCurrentFrame] null");
        if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kNone) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool ISingleTouchActionable.IsTouchBegan() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsTouchBegan touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsTouchBegan touchInfo[kCurrentFrame] null");
        if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kBegan) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool ISingleTouchActionable.IsTouchMoved() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsTouchMoved touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsTouchMoved touchInfo[kCurrentFrame] null");
        if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kMoved) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool ISingleTouchActionable.IsTouchStationary() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsTouchStationary touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsTouchStationary touchInfo[kCurrentFrame] null");
        if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kStationary) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool ISingleTouchActionable.IsTouchEnded() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsTouchEnded touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsTouchEnded touchInfo[kCurrentFrame] null");
        if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kEnded) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool ISingleTouchActionable.IsTouchCanceled() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsTouchCanceled touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsTouchCanceled touchInfo[kCurrentFrame] null");
        if (touchInfo[kCurrentFrame].status == TouchInfo.TouchStatus.kCanceled) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ドラッグ動作をしているか
    /// </summary>
    /// <returns><c>true</c>ドラッグ動作をしている<c>false</c>ドラッグ動作をしていない</returns>
    bool ISingleTouchActionable.IsDragging() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::IsDragging touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::IsDragging touchInfo[kCurrentFrame] null");
        TouchInfo.TouchStatus status = touchInfo[kCurrentFrame].status;
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
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::GetApplicationTouchPosition touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::GetApplicationTouchPosition touchInfo[kCurrentFrame] null");
        return GetTouchPosition(displayWidth, displayHeight, touchInfo[kCurrentFrame].position);
    }


    /// <summary>
    /// システムから取得できる無加工のタッチ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ISingleTouchActionable.GetRawTouchPosition() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::GetRawTouchPosition touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::GetRawTouchPosition touchInfo[kCurrentFrame] null");
        return touchInfo[kCurrentFrame].position;
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
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::Reset touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::Reset touchInfo[kCurrentFrame] null");
		MhCommon.Assert(touchInfo[kBefore1Frame] != null, "SingleTouchActionPc::Reset touchInfo[kBefore1Frame] null");
		base.Reset();
    }

    /// <summary>
    /// デバッグ用データの出力
    /// </summary>
    void ISingleTouchActionable.Print() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::Print touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::Print touchInfo[kCurrentFrame] null");
        touchInfo[kCurrentFrame].Print();
    }

    /// <summary>
    /// デバッグ用のデータ出力
    /// 前回のフレームからタッチ状態から異なっていたら出力
    /// </summary>
    void ISingleTouchActionable.PrintDifference() {
		MhCommon.Assert(touchInfo != null, "SingleTouchActionPc::PrintDifference touchInfo null");
		MhCommon.Assert(touchInfo[kCurrentFrame] != null, "SingleTouchActionPc::PrintDifference touchInfo[kCurrentFrame] null");
		MhCommon.Assert(touchInfo[kBefore1Frame] != null, "SingleTouchActionPc::PrintDifference touchInfo[kBefore1Frame] null");
        if (touchInfo[kCurrentFrame].Equals(touchInfo[kBefore1Frame]) == false) {
            touchInfo[kCurrentFrame].Print();
        }
    }
}
