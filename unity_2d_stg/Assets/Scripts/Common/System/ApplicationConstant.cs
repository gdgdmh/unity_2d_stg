using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationConstant {

    // 将来的にはXMLから設定できるようにするかもしれないのでメソッド経由でアクセスさせる
    public static float GetWidth() {
        return 720;
    }

    public static float GetHeight() {
        return 1200;
    }
}
