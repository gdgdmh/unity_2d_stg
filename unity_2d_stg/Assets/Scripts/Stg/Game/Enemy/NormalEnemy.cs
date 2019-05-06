using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyBase
{
	public NormalEnemy() {
	}

	public override void Initialize() {
	}

	// Start is called before the first frame update
	public override void Start() {
    }

    // Update is called once per frame
    public override void Update() {
		//Transform transform = GetComponent<Transform>();
		//MhCommon.Assert(transform != null, "NormalEnemy::Update transform null");
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		MhCommon.Assert(rigidbody2D != null, "NormalEnemy::Update transform null");

		// Z軸回転するようにする
		rigidbody2D.angularVelocity = 30.0f;
		// 真下に進む
		rigidbody2D.velocity = new Vector2(0.0f, -0.5f);
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		MhCommon.Print("NormalEnemy::OnTriggerEnter2D tag=" + collision.tag);
		if (collision.tag == StgGameObjectTag.ToString(StgGameObjectTag.Type.kPlayerBullet)) {
			// プレイヤーの弾と当たったら消滅する
			Destroy(this.gameObject);

			Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            MhCommon.Assert(rigidbody2D != null, "NormalEnemy::OnTriggerEnter2D() rigidbody2D null");
            CreateRandomEffect(rigidbody2D.position.x, rigidbody2D.position.y);

            /*
			StgEffectFactory factory = new StgEffectFactory();
			MhCommon.Assert(factory != null, "NormalEnemy::OnTriggerEnter2D() StgEffectFactory null");
			GameObject effect = factory.Create(StgEffectConstant.Type.kExplosion);
			Instantiate(effect, new Vector3(rigidbody2D.position.x, rigidbody2D.position.y, 0), Quaternion.identity);
            */

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
