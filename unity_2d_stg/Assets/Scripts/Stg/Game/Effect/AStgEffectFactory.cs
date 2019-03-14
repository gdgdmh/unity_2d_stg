using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStgEffectFactory {
	/// <summary>
	/// エフェクトの生成
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public abstract GameObject Create(StgEffectConstant.Type type);
}
