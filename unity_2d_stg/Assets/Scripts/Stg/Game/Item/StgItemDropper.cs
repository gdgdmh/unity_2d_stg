﻿using System.Collections;
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
	/// 出現位置の取得
	/// </summary>
	/// <returns>出現位置</returns>
	public Vector3 GetPosition() {
		return position;
	}

	/// <summary>
	/// アイテムのタイプの設定
	/// </summary>
	/// <param name="type">アイテムのタイプ</param>
	public void SetType(StgItemConstant.Type type) {
		this.type = type;
	}

	public StgItemConstant.Type GetItemType() {
		return type;
	}

	/// <summary>
	/// アイテムのドロップ
	/// </summary>
	/// <returns>ドロップしたアイテム</returns>
	public IEnumerable<GameObject> Drop() {
		StgItemFactory factory = new StgItemFactory();
		GameObject item = factory.Create(type);
		if (item == null) {
			throw new System.NullReferenceException("StgItemDropper::Drop() StgItemFactory Item Create Failure");
		}
		GameObject.Instantiate(item, position, Quaternion.identity);

		List<GameObject> list = new List<GameObject>();
		list.Add(item);
		return list;
	}

	/// <summary>
	/// データの中身を出力する
	/// </summary>
	public void Print() {
		Debug.Log(string.Format("StgItemDropper::Print() position={0} type={1}", position, type));
	}

	private Vector3 position; // ドロップ位置
	private StgItemConstant.Type type; // アイテムのタイプ
}
