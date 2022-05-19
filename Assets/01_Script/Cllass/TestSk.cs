using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestSk : MonoBehaviour
{
    // DoMoveX 10�� 1�ʵ���
    // SetEase �� �������� ȿ�� ���� ����
    // SetDelay �� ������ ����

    // �����ϰ� �������ִ°� tweener

    private Sequence mySequence; // Tweener ����ִ°ǵ� �̰� �׳� clip�̶� �����
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
    
    [ContextMenu("����")]
    public void ReStartDotween()
    {
        myTween.Restart();
    }

    void Update()
    {
        
    }
}
