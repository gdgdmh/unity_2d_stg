using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemMultiDropper {

	public StgItemMultiDropper() {
		Initialize();
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize() {
		dropList.Clear();
	}

	/// <summary>
	/// パラメータの設定
	/// </summary>
	/// <param name="position">出現位置</param>
	/// <param name="type">アイテムのタイプ</param>
	public void SetParameter(Vector3 position, StgItemConstant.Type type) {
		// データ追加
		StgItemDropper dropper = new StgItemDropper();
		dropper.SetPosition(position);
		dropper.SetType(type);
		dropList.Add(dropper);
	}

	/// <summary>
	/// アイテムのドロップ
	/// </summary>
	public void Drop() {
		foreach (StgItemDropper dropper in dropList) {
			dropper.Drop();
		}
	}

	private List<StgItemDropper> dropList = new List<StgItemDropper>();
}
