using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgEnemyConstantData {

	public StgEnemyConstantData() {
		constantDatas = null;
	}

	public void Initialize() {
		// Enumの大きさから配列を作成
		constantDatas = new float[System.Enum.GetNames(typeof(StgEnemyConstantDefine.Type)).Length];
	}

	/// <summary>
	/// 仮の値を初期化
	/// </summary>
	public void InitializeValue() {
		MhCommon.Assert(constantDatas != null, "StgEnemyConstantData::InitializeValue() constantDatas null please call Inintialize");
		constantDatas[(int)StgEnemyConstantDefine.Type.kNormalEnemyScore] = 100.0f;
        
	}


	private float[] constantDatas;
}
