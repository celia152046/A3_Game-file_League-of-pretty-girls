using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationPage : BasePage
{
    public Button mBtnClose;
    private void Start()
    {
        mBtnClose.onClick.RemoveAllListeners();
        mBtnClose.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseLastPage();
        }));
    }
}
