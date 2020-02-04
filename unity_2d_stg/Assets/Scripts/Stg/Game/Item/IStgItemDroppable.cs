using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムドロップするインターフェース
/// </summary>
interface IStgItemDroppable {
	/// <summary>
	/// アイテムをドロップする
	/// </summary>
	/// <returns>ドロップしたアイテム</returns>
	IEnumerable<GameObject> Drop();
}
