using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerBulletFactory : AStgBulletFactory {

	public StgPlayerBulletFactory(GameObject player) {
		this.player = player;
		StgPlayer playerScript = this.player.GetComponent<StgPlayer>();
		MhCommon.Assert(playerScript != null, "StgPlayerBulletFactory::StgPlayerBulletFactory() playerScript null");
	}

	/// <summary>
	/// 弾の生成
	/// </summary>
	/// <param name="type">弾の種類</param>
	/// <param name="position">弾の位置</param>
	/// <returns>成功したら弾ベースクラス失敗したらnull</returns>
	public override GameObject Create(StgBulletConstant.Type type) {
		if (type == StgBulletConstant.Type.kPlayerNormal) {
			GameObject bullet = (GameObject)Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kPlayerBulletPrefab));
			MhCommon.Assert(bullet != null, "StgPlayerBulletFactory::Create() kPlayerNormal null");
			return bullet;
		} else {
			// kUnknownか定義されているけど実装されていないtypeが指定された
			MhCommon.Assert(false, "StgPlayerBulletFactory::Create() StgBulletConstant.Type invalid type=" + type);
			return null;
		}
	}

	protected GameObject player;
	protected StgPlayer playerScript;
}
