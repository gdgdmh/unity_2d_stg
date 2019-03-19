using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MhCommon {

    /// <summary>
	/// デバッグ出力のラッパー
	/// </summary>
	/// <param name="message"></param>
    public static void Print(object message) {
        Debug.Log(message);
    }

    /// <summary>
	/// アサーションのラッパー
	/// </summary>
	/// <param name="expr"></param>
	/// <param name="message"></param>
    public static void Assert(int expr, object message) {
        if (expr == 0) {
            Debug.LogAssertion(message);
        }
    }

	/// <summary>
	/// アサーションのラッパー
	/// </summary>
	/// <param name="expr"></param>
	/// <param name="message"></param>
    public static void Assert(bool expr, object message) {
        if (expr == false) {
            Debug.LogAssertion(message);
        }
    }
}
