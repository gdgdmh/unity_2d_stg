using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemMultiDropper : IStgItemDroppable {

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
	public IEnumerable<GameObject> Drop() {
		List<GameObject> list = new List<GameObject>();
		foreach (StgItemDropper dropper in dropList) {
			// アイテムのドロップ
			IEnumerable<GameObject> datas = dropper.Drop();
			// ドロップしたアイテムリストを返すために追加
			foreach (GameObject item in datas) {
				list.Add(item);
			}
		}
		return list;
	}

	private List<StgItemDropper> dropList = new List<StgItemDropper>();
}
