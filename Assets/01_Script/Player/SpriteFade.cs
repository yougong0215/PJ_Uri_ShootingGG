using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpriteFade : MonoBehaviour
{
    Sequence seq;
    SpriteRenderer Spi;
    [SerializeField] PlayerHP Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Spi = gameObject.GetComponent<SpriteRenderer>();
        Spi.color = new Color(1,1,1,1);
        seq = DOTween.Sequence().SetAutoKill(false).
        Append(Spi.DOFade(0.0f, 0.25f)).
        Append(Spi.DOFade(1.0f, 0.25f)).
        Append(Spi.DOFade(0.0f, 0.25f)).
        Append(Spi.DOFade(1.0f, 0.25f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetOnCR() == true)
        {
            Spi.color = new Color(1, 1, 1, 0);
            seq.Restart();
        }
    }
}
