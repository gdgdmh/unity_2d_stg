using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵をランダムに出現させる
/// </summary>
public class StgEnemyRandomPopper : MonoBehaviour, IStgEnemyAppearable {
	
	StgEnemyRandomPopper() {
	}

	/// <summary>
	/// 定期的に実行するタスク(1フレームごと)
	/// </summary>
	public void TaskAppear() {
		//MhCommon.Print("TaskAppear");
	}
}
