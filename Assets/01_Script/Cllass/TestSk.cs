using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestSk : MonoBehaviour
{
    // DoMoveX 10에 1초동안
    // SetEase 로 여러가지 효과 적용 가능
    // SetDelay 로 딜레이 ㄱㄴ

    // 간단하게 저장해주는게 tweener

    private Sequence mySequence; // Tweener 모와주는건데 이거 그냥 clip이라 보면됨
    private Tweener myTweener;
    private Tween myTween;

    void Start()
    {
        //myTween = transform.DOMoveX(10, 1).SetEase(Ease.InElastic).SetDelay(0.5f).SetAutoKill(false) 
        // mySequence = DOTween.Sequence()
        //    .Append(transform.DOMoveX(7, 1).SetEase(Ease.InElastic).SetDelay(0.5f))
        //   .Append(transform.DOMoveY(3, 1).SetEase(Ease.InElastic).SetDelay(0.5f))
        //  .Append(transform.DOMove(new Vector3(0,0,0), 1).SetEase(Ease.InElastic).SetDelay(0.5f));

        myTween = transform.DOMoveX(10, 1)
            .OnComplete(() => 
            { 
                transform.DOMoveX(-10, 1); 
            
            } ).SetAutoKill(false);
    }
    
    [ContextMenu("샌즈")]
    public void ReStartDotween()
    {
        myTween.Restart();
    }

    void Update()
    {
        
    }
}
