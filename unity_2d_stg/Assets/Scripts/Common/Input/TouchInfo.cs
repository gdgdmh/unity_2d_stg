using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInfo {

    public enum TouchStatus : int {
        kNone,        // タッチ状態が何もない
        kBegan,       // 押し始め
        kMoved,       // 押し続けていて移動中
        kStationary,  // 押し続けているけど動いてない
        kEnded,       // タッチ終了
        kCanceled     // タッチ状態がキャンセルされた
    };

    // 無効なタッチId(直接値を参照するのは非推奨 調べるときはIsTouchIdInvalidを使用する)
    public static int kInvalidTouchId = -1;

    // 現在のタッチID(デフォルトは-1)
    public int touchId { set; get; }
    // タッチ位置
    public Vector3 position { set; get; }
    // タッチ状態
    public TouchStatus status { set; get; }

    public TouchInfo() {
        Clear();
    }

    // 初期状態にする
    public void Clear() {
        touchId = kInvalidTouchId;
        position = Vector3.zero; // (0, 0, 0)に設定
        status = TouchStatus.kNone;
    }

    // 情報をコピーする
    public void Copy(TouchInfo copySource) {
        touchId = copySource.touchId;
        position = copySource.position;
        status = copySource.status;
    }

    // 位置が等しいかを比較
    public bool IsPositionEquals(TouchInfo copySource) {
        if ((position.x == copySource.position.x)
            && (position.y == copySource.position.y)
            && (position.z == copySource.position.z)) {
            return true;
        }
        return false;
    }

    public bool Equals(TouchInfo info) {
        if (info == null) {
            return false;
        }

        if ((touchId == info.touchId)
            && (position.x == info.position.x)
            && (position.y == info.position.y)
            && (position.z == info.position.z)
            && (status == info.status)
            ) {
            return true;
        }
        return false;
    }

    // タッチIdが無効かどうか
    public bool IsTouchIdInvalid() {
        return IsTouchIdInvalid(touchId);
    }

    // タッチIdが無効かどうか
    public static bool IsTouchIdInvalid(int id) {
        if (id == kInvalidTouchId) {
            return true;
        }
        return false;
    }

    // ステータスによって文字列を返す
    public static string GetStatusString(TouchStatus touchStatus) {
        switch (touchStatus) {
            case TouchStatus.kNone:
                return "None";
            case TouchStatus.kBegan:
                return "Began";
            case TouchStatus.kMoved:
                return "Moved";
            case TouchStatus.kStationary:
                return "Stationary";
            case TouchStatus.kEnded:
                return "Ended";
            case TouchStatus.kCanceled:
                return "Canceled";
            default:
                return "Unknown";
        }
    }

    /**
     * 現在の状態の出力
     */
    public void Print() {
        MhCommon.Print("TouchInfo::Print touchId=" + touchId +
            " position x=" + position.x + " y=" + position.y + " z=" + position.z +
            "status=" + GetStatusString(status));
    }
}
