using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵生成クラス
/// </summary>
public abstract class AStgEnemyFactory {
	/// <summary>
	/// 敵を生成する
	/// </summary>
	/// <param name="type">敵のタイプ</param>
	/// <returns></returns>
	public abstract GameObject Create(StgEnemyConstant.Type type);

	public abstract GameObject Create(StgEnemyConstant.Type type, StgStageJsonEnemyItemDropDatas itemDropDatas);
}
