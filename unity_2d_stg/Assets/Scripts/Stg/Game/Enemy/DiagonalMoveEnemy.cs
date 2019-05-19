using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMoveEnemy : EnemyBase {

    public DiagonalMoveEnemy() {
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

        // 左下へ移動
        Vector2 direction = new Vector2(-1.0f, -1.0f).normalized; // 左下
        rigidbody2D.velocity = direction * kSpeedY;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
    }

    private static readonly float kSpeedY = 0.5f;
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
