using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInfo {
    public enum DragStatus : int {
        kNone,        // ドラッグをしていない
        kBegan,       // ドラッグ開始
        kMoved,       // ドラッグし続けていて移動中
        kStationary,  // ドラッグしているけど動いてない
        kEnded,       // ドラッグ終了
        kCanceled     // ドラッグ状態がキャンセルされた
    };

    void test() {
    }
}
