using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBulletExplosion : BulletTrans
{
    const string pushName = "BlueBulletExplosion_3";
    SpriteRenderer _spriter;
    [SerializeField] Sprite ThisSprite;
    public override void Reset()
    {
        _spriter.sprite = ThisSprite;
        HP = 100;
    }



    // Start is called before the first frame update
    void Awake()
    {
        _spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_spriter.sprite.name == pushName)
        {
            PoolManager.Instance.Push(this);
        }
    }
}
