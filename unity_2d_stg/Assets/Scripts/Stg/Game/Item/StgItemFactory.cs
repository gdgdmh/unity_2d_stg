using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemFactory {
	public StgItemFactory() {
	}

	public GameObject Create(StgItemConstant.Type type) {
		if (type == StgItemConstant.Type.kPowerup) {
		} else if (type == StgItemConstant.Type.kScoreup) {
		}
		return null;
	}
}
