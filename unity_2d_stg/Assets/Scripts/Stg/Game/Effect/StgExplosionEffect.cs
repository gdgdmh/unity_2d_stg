using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆発用エフェクトスクリプト
/// </summary>
public class StgExplosionEffect : MonoBehaviour {
	// エフェクト終了時イベント
	public void OnAnimationFinish() {
		// アニメーションが終了したら消滅
		Destroy(gameObject);
	}
}
