using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcePathDefine {

	// 定義
    public enum Type : int {
		kNormalEnemyPrefab, // 通常の敵のPrefab
        kStraightMoveEnemyPrefab, // 直線移動の敵のPrefab
        kPlayerBulletPrefab,// プレイヤーの弾のPrefab
        kExplosionPrefab,   // 爆発エフェクトのPrefab
        kExplosion002Prefab,// 爆発エフェクト002のPrefab
        kExplosion003Prefab,// 爆発エフェクト003のPrefab
		kMaxDefine,
    };
}
