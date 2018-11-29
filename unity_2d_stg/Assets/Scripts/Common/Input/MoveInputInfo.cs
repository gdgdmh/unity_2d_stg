using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputInfo {

    // デバイスのタイプ
    public enum Device
    {
        kNone, // なし
        kKeyboard,// キーボード
        kPad, // ゲームパッド
        kDeviceMax
    };

    // 移動の方向
    public enum Direction
    {
        kNone,
        kLeft,          // 左
        kTop,           // 上
        kRight,         // 右
        kBottom,        // 下
        kDirectionMax
    };

    public Device device_
    {
        protected set { this.device_ = value; }
        get { return this.device_; }
    }

    public Direction direction_
    {
        protected set { this.direction_ = value; }
        get { return this.direction_; }
    }

    public MoveInputInfo()
    {
        Clear(Device.kNone);
    }

    // 初期状態にする
    public void Clear(Device device)
    {
        this.direction_ = Direction.kNone;
        this.device_ = device;
    }
}
