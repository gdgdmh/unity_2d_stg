using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// システムから取得できるint型の乱数を取得する
/// </summary>
public class RandomIntegerSystem : ARandomInteger {

	public RandomIntegerSystem() {
		random = new System.Random();
		MhCommon.Assert(random != null, "RandomIntegerSystem::RandomIntegerSystem random create failure");
	}

	/// <summary>
	/// 乱数のシード値の設定
	/// </summary>
	public override void SetSeed(int seed) {
		MhCommon.Assert(random != null, "RandomIntegerSystem::SetSeed random null");
		random = new System.Random(seed);
		MhCommon.Assert(random != null, "RandomIntegerSystem::SetSeed random create null");
	}

	/// <summary>
	/// 乱数の取得(レンジ指定)
	/// </summary>
	/// <param name="min">乱数で返される最小値</param>
	/// <param name="max">乱数で返される最大値</param>
	/// <returns>min～maxまでの整数値</returns>
	public override int Get(int min, int max) {
		MhCommon.Assert(random != null, "RandomIntegerSystem::Get(int min, int max) random null");
		int value = random.Next(max - min);
		value = value + min;
		MhCommon.Assert((value >= min) && (value <= max), "RandomIntegerSystem::Get value invalid=" + value);
		return value;
	}

	/// <summary>
	/// 乱数の取得
	/// </summary>
	/// <returns>ランダムなint型整数値</returns>
	public override int Get() {
		MhCommon.Assert(random != null, "RandomIntegerSystem::Get random null");
		return random.Next();
	}

	private System.Random random;
}
