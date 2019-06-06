using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResourcePathData {

	public GameResourcePathData() {
		constantDatas = null;
	}

	public void Initialize() {
		// Enumの大きさから配列を作成
        constantDatas = new string[System.Enum.GetNames(typeof(GameResourcePathDefine.Type)).Length];
	}

	/// <summary>
	/// 仮の値を設定(本来は外部データなどで初期化するを想定)
	/// </summary>
	public void InitializeValue() {
		MhCommon.Assert(constantDatas != null, "GameResourcePathData::InitializeValue() constantDatas null please call Inintialize");
        constantDatas[(int)GameResourcePathDefine.Type.kNormalEnemyPrefab] = "Prefabs/Game/Enemy/Enemy1";
        constantDatas[(int)GameResourcePathDefine.Type.kStraightMoveEnemyPrefab] = "Prefabs/Game/Enemy/StraightMoveEnemy";
        constantDatas[(int)GameResourcePathDefine.Type.kPlayerBulletPrefab] = "Prefabs/Game/Bullet/PlayerBullet";
        constantDatas[(int)GameResourcePathDefine.Type.kExplosionPrefab] = "Prefabs/Game/Effect/Explosion";
        constantDatas[(int)GameResourcePathDefine.Type.kExplosion002Prefab] = "Prefabs/Game/Effect/Explosion002";
        constantDatas[(int)GameResourcePathDefine.Type.kExplosion003Prefab] = "Prefabs/Game/Effect/Explosion003";
	}

    /// <summary>
    /// 値の取得
    /// </summary>
    /// <param name="type">取得する値のタイプ</param>
    /// <returns></returns>
    public string Get(GameResourcePathDefine.Type type) {
        return constantDatas[(int)type];
    }

    private string[] constantDatas;
}
