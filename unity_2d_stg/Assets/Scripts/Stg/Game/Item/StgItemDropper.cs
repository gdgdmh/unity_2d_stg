using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgItemDropper : IStgItemDroppable {

	public StgItemDropper() {
		Initialize();
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public void Initialize() {
		position = new Vector3(0.0f, 0.0f, 0.0f);
		type = StgItemConstant.Type.kUnknown;
	}

	/// <summary>
	/// 出現位置の設定
	/// </summary>
	/// <param name="position">出現位置</param>
	public void SetPosition(Vector3 position) {
		this.position = position;
	}

	/// <summary>
	/// アイテムのタイプの設定
	/// </summary>
	/// <param name="type">アイテムのタイプ</param>
	public void SetType(StgItemConstant.Type type) {
		this.type = type;
	}

	/// <summary>
	/// アイテムのドロップ
	/// </summary>
	public void Drop() {
		StgItemFactory factory = new StgItemFactory();
		GameObject item = factory.Create(type);
		if (item == null) {
			throw new System.NullReferenceException("StgItemDropper::Drop() StgItemFactory Item Create Failure");
		}
		GameObject.Instantiate(item, position, Quaternion.identity);
	}

	private Vector3 position;
	private StgItemConstant.Type type;
}
