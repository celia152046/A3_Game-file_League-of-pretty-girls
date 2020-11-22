using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpecialController : MonoBehaviour
{
    public GameObject mDisableRoot;

    GameObject mTempTween;
    private void Start()
    {
        mTempTween = new GameObject("__temp__");
        PlayTween();
        mDisableRoot.SetActive(true);
    }
    Tweener mTweener;
    void PlayTween()
    {
        if (mTweener != null) { mTweener.Pause(); }
        mTweener = mTempTween.transform.DOScale(2, 3).OnComplete(() =>
        {
            mDisableRoot.SetActive(false);
        }).Play();
    }
}
