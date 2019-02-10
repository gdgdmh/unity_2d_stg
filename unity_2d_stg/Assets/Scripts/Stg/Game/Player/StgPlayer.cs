using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgPlayer : StgGameObject {

    StgPlayer() {
		isDragRaw = true;
    }

    private void Awake() {
        // 動的にスクリプトを追加
        if (stgPlayerController == null) {
            stgPlayerController = this.gameObject.AddComponent<StgPlayerController>() as StgPlayerController;
            MhCommon.Assert(stgPlayerController != null, "StgPlayer::Awake() StgPlayerController AddComponent failure");
			// 試しにcall
			stgPlayerController.Update();
        }

		// 攻撃クラス作成
		if (attack == null) {
			attack = this.gameObject.AddComponent<StgPlayerAttack>() as StgPlayerAttack;
			MhCommon.Assert(attack != null, "StgPlayer::Awake() StgPlayerAttack new failure");
		}
    }

    // Start is called before the first frame update
    public override void Start() {
        
    }

    // Update is called once per frame
    public override void Update() {
        UnitySingleTouchAction touchAction = SceneShare.Instance.GetInput().GetSingleTouchAction();
		UnitySingleTouchDragAction dragAction = SceneShare.Instance.GetInput().GetSingleTouchDragAction();
        touchAction.Update();
		dragAction.Update();

		// 移動処理
		Move();

		// 攻撃処理
		Attack();

    }

	private void Move() {
        //UnitySingleTouchAction touchAction = SceneShare.Instance.GetInput().GetSingleTouchAction();
		UnitySingleTouchDragAction dragAction = SceneShare.Instance.GetInput().GetSingleTouchDragAction();
		//dragAction.PrintDifference();
		if ((dragAction.IsDragMoved()) || (dragAction.IsDragStationary())) {
			// 前フレームとの差分からドラッグ移動を算出
			Vector3 before = dragAction.GetApplicationDragBefore1FramePosition();
			Vector3 current = dragAction.GetApplicationDragCurrentPosition();

			Vector3 diffarence = current - before;
			if (!isDragRaw) {
				// 正規化+速度をかけ合わせてドラッグを反映
				float speed = 9.0f;
				Vector2 direction = new Vector2(diffarence.x, diffarence.y).normalized;
				GetComponent<Rigidbody2D>().velocity = direction * speed;
			} else {
				// ほぼ無加工でドラッグを反映
				Vector2 direction = new Vector2(diffarence.x, diffarence.y);
				GetComponent<Rigidbody2D>().velocity = direction;
			}
		} else {
			Vector2 direction = new Vector2(0, 0).normalized;
            GetComponent<Rigidbody2D>().velocity = direction;
		}

		/*
        if (touchAction.IsTouchBegan()) {
            float x = 0.0f;
            float y = -0.2f;
            float speed = 1.0f;
            Vector2 direction = new Vector2(x, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
		*/		
	}

	private void Attack() {
		MhCommon.Assert(attack != null, "StgPlayer::Attack() StgPlayerAttack null");
		attack.Update();
	}

	private IStgPlayerController stgPlayerController;
    private I2dFloatPositionable position;
	private StgPlayerAttack attack;
	private bool isDragRaw;
}
