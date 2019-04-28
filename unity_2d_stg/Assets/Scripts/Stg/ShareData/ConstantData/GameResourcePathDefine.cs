using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcePathDefine {

	// 定義
    public enum Type : int {
		kNormalEnemyPrefab, // 通常の敵のPrefab
        kPlayerBulletPrefab,// プレイヤーの弾のPrefab
        kExplosionPrefab,   // 爆発エフェクトのPrefab
		kMaxDefine,
    };
}
