using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchActionSmartPhone : MonoBehaviour, ITouchActionable {

    private TouchInfo currentInfo { set; get; }
    private TouchInfo pastTouchInfo { set; get; }
    private int displayWidth { set; get; }
    private int displayHeight { set; get; }

    public TouchActionSmartPhone(int displayWidth, int displayHeight) {
        this.displayWidth = displayWidth;
        this.displayHeight = displayHeight;
    }

    private void Awake() {
        currentInfo = new TouchInfo();
        pastTouchInfo = new TouchInfo();
    }

    // Use this for initialization
    void Start () {
	}

    private void OnDestroy() {
        // 念のためにnullにして破棄
        currentInfo = null;
        pastTouchInfo = null;
    }

    // Update is called once per frame
    void Update () {
        SetTouchInfo();
    }

    /// <summary>
    /// タッチが全くされていない状態か
    /// </summary>
    /// <returns>タッチが全くされていない状態ならtrue</returns>
    bool ITouchActionable.IsTouchNone() {
        if (currentInfo.status == TouchInfo.TouchStatus.kNone) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが開始された状態か
    /// </summary>
    /// <returns>タッチが開始された状態ならtrue</returns>
    bool ITouchActionable.IsTouchBegan() {
        if (currentInfo.status == TouchInfo.TouchStatus.kBegan) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動中か
    /// </summary>
    /// <returns>タッチをし続けていて移動中ならtrue</returns>
    bool ITouchActionable.IsTouchMoved() {
        if (currentInfo.status == TouchInfo.TouchStatus.kMoved) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチをし続けていて移動していないか
    /// </summary>
    /// <returns>タッチをし続けていて移動していないならtrue</returns>
    bool ITouchActionable.IsTouchStationary() {
        if (currentInfo.status == TouchInfo.TouchStatus.kStationary) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチが終了したか(タッチをして持ち上げた)
    /// </summary>
    /// <returns>タッチが終了したならtrue</returns>
    bool ITouchActionable.IsTouchEnded() {
        if (currentInfo.status == TouchInfo.TouchStatus.kEnded) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// タッチがキャンセルされたか(タッチをして何らかの理由でキャンセルされた)
    /// </summary>
    /// <returns>タッチがキャンセルされたならtrue</returns>
    bool ITouchActionable.IsTouchCanceled() {
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
    Vector3 ITouchActionable.GetApplicationTouchPosition() {
        return GetTouchPosition(displayWidth, displayHeight, currentInfo.position);
    }

    /// <summary>
    /// システムから取得できる無加工のタッチ位置を取得する
    /// </summary>
    /// <returns></returns>
    Vector3 ITouchActionable.GetRawTouchPosition() {
        return currentInfo.position;
    }

    /// <summary>
    /// 前回とタッチ状態が異なっていたら出力
    /// </summary>
    public void PrintDifference() {
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

/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



void Update()
{

    // タッチ状態の更新
    if (IsTouchPlatform() == true)
    {
        // タッチプラットフォーム
        SetTouchInfoForTouchPlatform();
    }
    else
    {
        // PC
        SetTouchInfoForPC();
    }
}

public bool IsTouchNone()
{
    if (current_info_.status == TouchInfo.TouchStatus.kNone)
    {
        return true;
    }
    return false;
}


public bool IsTouchBegan()
{
    if (current_info_.status == TouchInfo.TouchStatus.kBegan)
    {
        return true;
    }
    return false;
}

public bool IsTouchMoved()
{
    if (current_info_.status == TouchInfo.TouchStatus.kMoved)
    {
        return true;
    }
    return false;
}

public bool IsTouchStationary()
{
    if (current_info_.status == TouchInfo.TouchStatus.kStationary)
    {
        return true;
    }
    return false;
}

public bool IsTouchEnded()
{
    if (current_info_.status == TouchInfo.TouchStatus.kEnded)
    {
        return true;
    }
    return false;
}

public bool IsTouchCanceled()
{
    if (current_info_.status == TouchInfo.TouchStatus.kCanceled)
    {
        return true;
    }
    return false;
}

public Vector3 GetTouchPosition()
{
    return GetTouchPosition(ApplicationConstant.GetWidth(), ApplicationConstant.GetHeight());
}

public Vector3 GetRawTouchPosition()
{
    return current_info_.position;
}

public Vector3 GetTouchPosition(float width, float height)
{
    Vector3 v;
    float ratio_x = ((float)width / (float)Screen.width);
    float ratio_y = ((float)height / (float)Screen.height);

    //float offset_x = width - ((float)Screen.width * ratio_x) / 2;

    v.x = current_info_.position.x * ratio_x;
    v.y = current_info_.position.y * ratio_y;
    v.z = current_info_.position.z;

    return v;
}

public void PrintCurrentInfo()
{
    // 前回とタッチ状態が異なっていたら出力
    if (current_info_.Equals(past_touch_info_) == false)
    {
        current_info_.Print();
    }
}

private bool IsTouchPlatform()
{
    // タッチ系のプラットフォーム
    if ((Application.platform == RuntimePlatform.Android)
        || (Application.platform == RuntimePlatform.IPhonePlayer))
    {
        // 今はAndroidとiOSのみ
        // 今後対応するタッチプラットフォームを拡大する際にはifの中に追加して下さい
        return true;
    }
    return false;
}

// TouchからTouchInfoへ設定
private void SetTouchToTouchInfo(Touch touch)
{
    current_info_.touchId = touch.fingerId;
    current_info_.position = touch.position;

    switch (touch.phase)
    {
        case TouchPhase.Began:
            current_info_.status = TouchInfo.TouchStatus.kBegan;
            break;
        case TouchPhase.Moved:
            current_info_.status = TouchInfo.TouchStatus.kMoved;
            break;
        case TouchPhase.Stationary:
            current_info_.status = TouchInfo.TouchStatus.kStationary;
            break;
        case TouchPhase.Ended:
            current_info_.status = TouchInfo.TouchStatus.kEnded;
            break;
        case TouchPhase.Canceled:
            current_info_.status = TouchInfo.TouchStatus.kCanceled;
            break;
        default:
            break;
    }
}

// タッチプラットフォーム系にTouchInfoを設定
private void SetTouchInfoForTouchPlatform()
{
    // 前の状態を保存
    past_touch_info_.Copy(current_info_);

    //MhCommon.Print("TouchManager::SetTouchInfoForTouchPlatform");
    int id = current_info_.touchId;
    // 情報をリセットしておく
    current_info_.Clear();

    // タッチ情報無し
    if (Input.touchCount <= 0)
    {
        //MhCommon.Print("touch none");
        return;
    }

    // タッチIdが有効なので前回と同じタッチを探す
    if (TouchInfo.IsTouchIdInvalid(id) == false)
    {
        //MhCommon.Print("not invalid");
        for (int i = 0; i < Input.touchCount; ++i)
        {
            //MhCommon.Print("finding id=" + id + " fid=" + Input.GetTouch(i).fingerId);
            if (id == Input.GetTouch(i).fingerId)
            {
                // 情報をセット
                SetTouchToTouchInfo(Input.GetTouch(i));
                return;
            }
        }
    }
    else
    {
        // 既存のタッチがないので新規タッチがあったら情報をセット
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SetTouchToTouchInfo(Input.GetTouch(0));
        }
    }
}

// PC系のプラットフォームにTouchInfoを設定
private void SetTouchInfoForPC()
{

    // 前の状態を保存
    past_touch_info_.Copy(current_info_);

    TouchInfo.TouchStatus status = current_info_.status;
    switch (status)
    {
        case TouchInfo.TouchStatus.kNone:
            // 押したりしていない状態で押されたらBeganへ移行
            if (Input.GetMouseButtonDown(0) == true)
            {
                // タッチidは0固定
                current_info_.touchId = 0;
                // 位置
                current_info_.position = Input.mousePosition;
                current_info_.status = TouchInfo.TouchStatus.kBegan;
            }
            else
            {
                // デフォルトの値
                current_info_.Clear();
            }
            break;
        case TouchInfo.TouchStatus.kBegan:
            // 位置を設定
            current_info_.position = Input.mousePosition;
            if (Input.GetMouseButton(0) == true)
            {
                // 押しっぱなしなのでMovedかStationaryへ移行
                if (current_info_.IsPositionEquals(past_touch_info_) == true)
                {
                    current_info_.status = TouchInfo.TouchStatus.kStationary;
                }
                else
                {
                    current_info_.status = TouchInfo.TouchStatus.kMoved;
                }
            }
            else
            {
                // 持ち上げられたのでkEndedへ
                current_info_.status = TouchInfo.TouchStatus.kEnded;
            }
            break;
        case TouchInfo.TouchStatus.kMoved:
            current_info_.position = Input.mousePosition;
            if (Input.GetMouseButton(0) == false)
            {
                // 持ち上げられたのでkEndedへ
                current_info_.status = TouchInfo.TouchStatus.kEnded;
            }
            else
            {
                // MovedかStationaryへ移行
                if (current_info_.IsPositionEquals(past_touch_info_) == true)
                {
                    current_info_.status = TouchInfo.TouchStatus.kStationary;
                }
                else
                {
                    current_info_.status = TouchInfo.TouchStatus.kMoved;
                }
            }
            break;
        case TouchInfo.TouchStatus.kStationary:

            current_info_.position = Input.mousePosition;
            MhCommon.Print("x " + current_info_.position.x + " y " + current_info_.position.y + " z " + current_info_.position.z);

            if (Input.GetMouseButton(0) == false)
            {
                // 持ち上げられたのでkEndedへ
                current_info_.status = TouchInfo.TouchStatus.kEnded;
            }
            else
            {
                // MovedかStationaryへ移行
                if (current_info_.IsPositionEquals(past_touch_info_) == true)
                {
                    current_info_.status = TouchInfo.TouchStatus.kStationary;
                }
                else
                {
                    current_info_.status = TouchInfo.TouchStatus.kMoved;
                }
            }
            break;
        case TouchInfo.TouchStatus.kEnded:
        case TouchInfo.TouchStatus.kCanceled:
            // kEndedになった瞬間に押されたらkBeganへ移行
            if (Input.GetMouseButton(0) == true)
            {
                // タッチidは0固定
                current_info_.touchId = 0;
                // 位置
                current_info_.position = Input.mousePosition;
                current_info_.status = TouchInfo.TouchStatus.kBegan;
            }
            else
            {
                // デフォルト状態に戻す
                current_info_.Clear();
            }
            break;
        default:
            break;
    }
}
}

*/
