using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgExplosionEffect : MonoBehaviour {
	public void OnAnimationFinish() {
		// アニメーションが終了したら消滅
		Destroy(gameObject);
	}
}
