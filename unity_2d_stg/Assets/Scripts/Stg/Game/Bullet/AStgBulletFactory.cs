using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStgBulletFactory {

	/// <summary>
	/// 弾の生成
	/// </summary>
	/// <param name="type">弾の種類</param>
	/// <param name="position">弾の位置</param>
	/// <returns>成功したら弾ベースクラス失敗したらnull</returns>
	public abstract GameObject Create(StgBulletConstant.Type type, Object2dFloatPosition position);
	//public abstract StgBulletBase Create(StgBulletConstant.Type type, Object2dFloatPosition position);
}
