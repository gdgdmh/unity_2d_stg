using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEffectFactory : AStgEffectFactory {

	public StgEffectFactory() {
	}

	/// <summary>
	/// エフェクトの生成
	/// </summary>
	/// <param name="type">エフェクトの種類</param>
	/// <returns>成功ならエフェクト、失敗したらnull</returns>
	public override GameObject Create(StgEffectConstant.Type type) {
		if (type == StgEffectConstant.Type.kExplosion) {
			GameObject effect = (GameObject)Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kExplosionPrefab));
			MhCommon.Assert(effect != null, "StgEffectFactory::Create() kExplosion null");
			return effect;
		} else {
			// kUnknownもしくは定義されているが実装されていないtypeが指定された
			MhCommon.Assert(false, "StgEffectFactory::Create() StgEffectConstant.Type invalid type=" + type);
			return null;
		}
	}
}
