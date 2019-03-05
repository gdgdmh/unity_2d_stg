using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StgGameObjectTag {
	public enum Type : int {
		kPlayer,
		kEnemy,
		kPlayerBullet
	};
	
	public static string ToString(Type type) {
		string[] names = {"player", "enemy", "player_bullet"};
		return names[(int)type];
	}

	/// <summary>
	/// 整数値がenumで定義済みかどうか
	/// </summary>
	/// <param name="value">チェックする整数値</param>
	/// <returns>trueなら整数値がenumで定義済み falseなら整数値がenumで定義されていない</returns>
	public static bool IsDefined(int value) {
		return System.Enum.IsDefined(typeof(StgGameObjectTag.Type), value);
	}
}
