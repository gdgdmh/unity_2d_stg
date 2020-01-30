using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemFactory {
	public StgItemFactory() {
	}

	public GameObject Create(StgItemConstant.Type type) {
		if (type == StgItemConstant.Type.kPowerup) {
			return Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kItemPowerup)) as GameObject;
		} else if (type == StgItemConstant.Type.kScoreup) {
			return Resources.Load(SceneShare.Instance.GetGameResourcePathData().Get(GameResourcePathDefine.Type.kItemScoreup)) as GameObject;
		}
		throw new System.ArgumentException("StgItemFactory::Create() invalid argument");
	}
}
