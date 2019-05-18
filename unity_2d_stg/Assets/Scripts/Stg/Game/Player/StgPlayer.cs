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
			// プレイヤーのGameObjectを取得
			GameObject player = GameObject.Find("Player");
			MhCommon.Assert(player != null, "GameMainSceneTask::Start() player null");

			attack = this.gameObject.AddComponent<StgPlayerAttack>() as StgPlayerAttack;
			attack.SetPlayer(ref player);
			MhCommon.Assert(attack != null, "StgPlayer::Awake() StgPlayerAttack new failure");
		}

        healthObservable = new StgPlayerHealthObservable();


		//if (stgGameObjectSubject == null) {
		//	stgGameObjectSubject = new StgGameObjectSubject();
		//}
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

        // HP変更通知
        //healthObservable.NotifyObservers(10, 10, 0);
    }

	public Vector3 GetShootPosition() {
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "StgPlayer::Attack() rigidbody2D null");
		Vector3 position = rigidbody2D.position;
		position.y += kShootOffsetY; // 自機の本体分ずらす
		return position;
	}

    /// <summary>
    /// 体力変化のオブザーバーを登録
    /// </summary>
    /// <param name="observer">登録するオブザーバー</param>
    public void SetHealthObserver(IStgPlayerHealthObserver observer) {
        healthObservable.Add(observer);
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
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "StgPlayer::Attack() rigidbody2D null");
		MhCommon.Assert(attack != null, "StgPlayer::Attack() StgPlayerAttack null");

		// 発射位置を設定
		attack.Update();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		
		MhCommon.Print("StgPlayer::OnTriggerEnter2D tag=" + collision.tag);
	}

	private static readonly float kShootOffsetY = 1.0f;

	private IStgPlayerController stgPlayerController;
    private I2dFloatPositionable position;
	private StgPlayerAttack attack;
    private StgPlayerHealthObservable healthObservable;
	private bool isDragRaw;
}
