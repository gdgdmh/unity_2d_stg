using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵を出現させるインターフェース
/// </summary>
interface IStgEnemyAppearable {
	/// <summary>
	/// 敵を出現させる
	/// </summary>
	void TaskAppear();

	/// <summary>
	/// 出現処理が終了したか
	/// </summary>
	/// <returns>終了したらtrue</returns>
	bool IsEnd();
}
