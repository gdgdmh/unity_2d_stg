using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StgEnemyConstant {
	// 敵の種類
    public enum Type {
		kEnemyNormal,
        kStraightMoveEnemy,
		kUnknown
    };

	public static readonly string kStringEnemyNormal = "normal_enemy";
	public static readonly string kStringStraightMoveEnemy = "straight_move_enemy";
	public static readonly string kUnknown = "";

	public static Type GetStringToType(string enemyType) {
		if (enemyType == kStringEnemyNormal) {
			return Type.kEnemyNormal;
		} else if (enemyType == kStringStraightMoveEnemy) {
			return Type.kStraightMoveEnemy;
		}
		return Type.kUnknown;
	}
}
