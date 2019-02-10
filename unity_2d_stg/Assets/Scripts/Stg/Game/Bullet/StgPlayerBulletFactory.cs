using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerBulletFactory : AStgBulletFactory {

	public StgPlayerBulletFactory() {
	}

	//GameObject
	
	/// <summary>
	/// 弾の生成
	/// </summary>
	/// <param name="type">弾の種類</param>
	/// <param name="position">弾の位置</param>
	/// <returns>成功したら弾ベースクラス失敗したらnull</returns>
	//public override StgBulletBase Create(StgBulletConstant.Type type, Object2dFloatPosition position) {
	public override GameObject Create(StgBulletConstant.Type type, Object2dFloatPosition position) {
		if (type == StgBulletConstant.Type.kPlayerNormal) {
			GameObject bullet = (GameObject)Resources.Load("PlayerBullet");
			//StgPlayerBullet bullet = Resources.Load<StgPlayerBullet>("PlayerBullet");//"Prefabs/Game/Bullet/PlayerBullet");
			MhCommon.Assert(bullet != null, "StgPlayerBulletFactory::Create() kPlayerNormal null");
			//Instantiate(bullet, new Vector3(0.0f, -3.0f, 0.0f), Quaternion.identity);
			return bullet;
		} else {
			// kUnknownか定義されているけど実装されていないtypeが指定された
			MhCommon.Assert(false, "StgPlayerBulletFactory::Create() StgBulletConstant.Type invalid type=" + type);
			return null;
		}
	}

}
