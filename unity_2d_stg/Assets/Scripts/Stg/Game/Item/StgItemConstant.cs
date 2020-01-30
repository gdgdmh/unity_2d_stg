using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StgItemConstant {
	public enum Type {
		kPowerup,
		kScoreup,
		kUnknown
	};

	public static readonly int kScorePowerup = 100;
	public static readonly int kScoreScoreup = 500;
}
