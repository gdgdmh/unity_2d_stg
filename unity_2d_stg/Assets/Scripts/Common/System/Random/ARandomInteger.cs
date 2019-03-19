using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 整数値の乱数を生成する
/// </summary>
public abstract class ARandomInteger {

	/// <summary>
	/// 乱数のシード値の設定
	/// </summary>
	public abstract void SetSeed(int seed);

	/// <summary>
	/// 乱数の取得(レンジ指定)
	/// </summary>
	/// <param name="min">乱数で返される最小値</param>
	/// <param name="max">乱数で返される最大値</param>
	/// <returns>min～maxまでの整数値</returns>
	public abstract int Get(int min, int max);

	/// <summary>
	/// 乱数の取得
	/// </summary>
	/// <returns>ランダムなint型整数値</returns>
	public abstract int Get();
}
