using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMoveEnemy : EnemyBase {

    public StraightMoveEnemy() {
        this.angle = kAngle;
        this.speed = kSpeedY;
        SetDirection(angle, speed);
    }

    public StraightMoveEnemy(float angle, float speed) {
        this.angle = angle;
        this.speed = speed;
        SetDirection(angle, speed);
    }

	public override void Initialize() {
        base.Initialize();
	}

	// Start is called before the first frame update
	public override void Start() {
        base.Start();
    }

    public override void Update() {
        base.Update();
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "DiagonalMoveEnemy::Update transform null");

		// Z軸回転するようにする
		rigidbody2D.angularVelocity = 30.0f;

        rigidbody2D.velocity = direction;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
		//MhCommon.Print("NormalEnemy::OnTriggerEnter2D tag=" + collision.tag);
		if ((collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayerBullet))
            ||(collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayer))) {
			// プレイヤーの弾と当たったら消滅する
			Destroy(this.gameObject);

			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            MhCommon.Assert(rigidbody2D != null, "DiagonalMoveEnemy::OnTriggerEnter2D() rigidbody2D null");
            CreateRandomEffect(rigidbody2D.position.x, rigidbody2D.position.y);

			AdditionalScore((int)(SceneShare.Instance.GetStgEnemyConstantData().Get(StgEnemyConstantDefine.Type.kNormalEnemyScore)));
		}
    }

    /// <summary>
    /// 死亡時のエフェクトをランダムで生成する
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void CreateRandomEffect(float x, float y) {
        StgEffectFactory factory = new StgEffectFactory();
        MhCommon.Assert(factory != null, "DiagonalMoveEnemy::CreateRandomEffect() StgEffectFactory null");
        RandomIntegerSystem random = new RandomIntegerSystem();
        MhCommon.Assert(random != null, "DiagonalMoveEnemy::CreateRandomEffect() RandomIntegerSystem null");
        int value = random.Get(1, 3);
        StgEffectConstant.Type type = StgEffectConstant.Type.kExplosion;
        MhCommon.Assert((value >= 1) && (value <= 3), "DiagonalMoveEnemy::CreateRandomEffect() random range failure");
        if (value == 1) {
            type = StgEffectConstant.Type.kExplosion;
        } else if (value == 2) {
            type = StgEffectConstant.Type.kExplosion002;
        } else {
            type = StgEffectConstant.Type.kExplosion003;
        }
		GameObject effect = factory.Create(type);
        MhCommon.Assert(effect != null, "DiagonalMoveEnemy::CreateRandomEffect() effect null");
		Instantiate(effect, new Vector3(x, y, 0), Quaternion.identity);
    }

    /// <summary>
    /// 方向変数の設定
    /// </summary>
    /// <param name="angle">角度(弧度法)</param>
    /// <param name="speed">移動スピード</param>
    private void SetDirection(float angle, float speed) {
        float radianAngle = Mathf.Deg2Rad * angle; // 弧度法からラジアンに変換
        direction = new Vector2(Mathf.Cos(radianAngle) * speed, Mathf.Sin(radianAngle) * speed); // 移動ベクトル
    }

    private static readonly float kAngle = 270.0f; // デフォルト値
    private static readonly float kSpeedY = 0.5f; // デフォルト値
    private float angle; // 移動角度(弧度法)
    private float speed; // 移動スピード
    private Vector2 direction;      // Updateで更新する移動ベクトル

}

/*
public class NormalEnemy : EnemyBase
{
	private void OnTriggerEnter2D(Collider2D collision) {
		//MhCommon.Print("NormalEnemy::OnTriggerEnter2D tag=" + collision.tag);
		if ((collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayerBullet))
            ||(collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayer))) {
			// プレイヤーの弾と当たったら消滅する
			Destroy(this.gameObject);

			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            MhCommon.Assert(rigidbody2D != null, "NormalEnemy::OnTriggerEnter2D() rigidbody2D null");
            CreateRandomEffect(rigidbody2D.position.x, rigidbody2D.position.y);


			AdditionalScore((int)(SceneShare.Instance.GetStgEnemyConstantData().Get(StgEnemyConstantDefine.Type.kNormalEnemyScore)));
		}
	}

    private void CreateRandomEffect(float x, float y) {
        StgEffectFactory factory = new StgEffectFactory();
        MhCommon.Assert(factory != null, "NormalEnemy::CreateRandomEffect() StgEffectFactory null");
        RandomIntegerSystem random = new RandomIntegerSystem();
        MhCommon.Assert(random != null, "NormalEnemy::CreateRandomEffect() RandomIntegerSystem null");
        int value = random.Get(1, 3);
        StgEffectConstant.Type type = StgEffectConstant.Type.kExplosion;
        MhCommon.Assert((value >= 1) && (value <= 3), "NormalEnemy::CreateRandomEffect() random range failure");
        if (value == 1) {
            type = StgEffectConstant.Type.kExplosion;
        } else if (value == 2) {
            type = StgEffectConstant.Type.kExplosion002;
        } else {
            type = StgEffectConstant.Type.kExplosion003;
        }
		GameObject effect = factory.Create(type);
        MhCommon.Assert(effect != null, "NormalEnemy::CreateRandomEffect() effect null");
		Instantiate(effect, new Vector3(x, y, 0), Quaternion.identity);
    }
}

*/
