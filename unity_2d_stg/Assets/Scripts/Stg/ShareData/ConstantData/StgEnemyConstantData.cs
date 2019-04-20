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
	/// 仮の値を設定(本来は外部データなどで初期化するを想定)
	/// </summary>
	public void InitializeValue() {
		MhCommon.Assert(constantDatas != null, "StgEnemyConstantData::InitializeValue() constantDatas null please call Inintialize");
		constantDatas[(int)StgEnemyConstantDefine.Type.kNormalEnemyScore] = 100.0f;
        
	}

    /// <summary>
    /// 値の取得
    /// </summary>
    /// <param name="type">取得する値のタイプ</param>
    /// <returns></returns>
    public float Get(StgEnemyConstantDefine.Type type) {
        return constantDatas[(int)type];
    }

	private float[] constantDatas;
}
