using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStgBulletFactory {

    /// <summary>
    /// 弾の生成
    /// </summary>
    /// <param name="type">弾の種類</param>
    /// <returns>生成された弾オブジェクト</returns>
	public abstract GameObject Create(StgBulletConstant.Type type);
}
