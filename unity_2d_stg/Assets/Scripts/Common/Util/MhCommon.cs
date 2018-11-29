using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MhCommon {

    // ログ出力
    public static void Print(object message)
    {
        Debug.Log(message);
    }

    // アサーション
    public static void Assert(int expr, object message)
    {
        if (expr == 0)
        {
            Debug.LogAssertion(message);
        }
    }

    public static void Assert(bool expr, object message)
    {
        if (expr == false)
        {
            Debug.LogAssertion(message);
        }
    }
}
