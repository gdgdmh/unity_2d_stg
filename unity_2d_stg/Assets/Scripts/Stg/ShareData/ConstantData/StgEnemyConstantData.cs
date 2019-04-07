using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyConstantData {

	public StgEnemyConstantData() {
		// Enumの大きさから配列を作成
		constantDatas = new float[System.Enum.GetNames(typeof(StgEnemyConstantDefine.Type)).Length];
	}


	private float[] constantDatas;
}
