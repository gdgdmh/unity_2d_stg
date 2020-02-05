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
	/// <param name="position">ドロップ位置</param>
	/// <param name="type">アイテムのタイプ</param>
	public void SetParameter(Vector3 position, StgItemConstant.Type type) {
		// データ追加
		StgItemDropper dropper = new StgItemDropper();
		dropper.SetPosition(position);
		dropper.SetType(type);
		dropList.Add(dropper);
	}

	/// <summary>
	/// ドロップ位置オフセットの設定
	/// </summary>
	/// <param name="offset">オフセット</param>
	public void SetOffset(Vector3 offset) {
		this.offset = offset;
	}

	/// <summary>
	/// アイテムのドロップ
	/// </summary>
	public IEnumerable<GameObject> Drop() {
		List<GameObject> list = new List<GameObject>();

		if (dropList.Count == 0) {
			// リストが空
			return list;
		}
		foreach (StgItemDropper dropper in dropList) {
			// オフセットと対象の位置の適用
			dropper.SetPosition(dropper.GetPosition() + offset);
			// アイテムのドロップ
			IEnumerable<GameObject> datas = dropper.Drop();
			// ドロップしたアイテムリストを返すために追加
			foreach (GameObject item in datas) {
				list.Add(item);
			}
		}
		return list;
	}

	/// <summary>
	/// データの中身を出力する
	/// </summary>
	public void Print() {
		foreach (StgItemDropper drop in dropList) {
			drop.Print();
		}
	}

	private List<StgItemDropper> dropList = new List<StgItemDropper>();
	protected Vector3 offset = new Vector3();
}
