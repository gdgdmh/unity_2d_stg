using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayerAttackNew {

	public StgPlayerAttackNew() {
	}

	public void SetPlayer(ref GameObject player) {
		MhCommon.Print("SetPlayer");
		this.player = player;
		MhCommon.Assert(this.player != null, "StgPlayerAttackNew::SetPlayer() player null");
		attackStateContext = new StgPlayerAttackStateContext(ref player);
	}

	public void Start() {
		attackStateContext.Initialize();
	}

	public void Update(float elapsedTime, UnitySingleTouchAction touchAction, UnitySingleTouchDragAction dragAction) {
		attackStateContext.Update(elapsedTime, touchAction, dragAction);
	}

	public void Powerup() {
		attackStateContext.Powerup();
	}

	protected GameObject player;
	private StgPlayerAttackStateContext attackStateContext;
}
