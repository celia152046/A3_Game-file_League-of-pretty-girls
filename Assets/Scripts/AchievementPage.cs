using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievementPage : BasePage
{
    public Button mBtnClose, mBtnGameRule;
    public List<Button> mLockImageList = new List<Button>();
    public List<Button> mUnLockList = new List<Button>();
    public List<GameObject> mTipsList = new List<GameObject>();
    public List<Button> mTipsBtnClose = new List<Button>();

    public GameObject mAchievementSystemRoot;
    public Button mBtnAchievementSsystemClose;
    private void Start()
    {
        mBtnClose.onClick.RemoveAllListeners();
        mBtnClose.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseLastPage();
        }));
        mBtnGameRule.onClick.RemoveAllListeners();
        mBtnGameRule.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mAchievementSystemRoot.SetActive(true);
        }));

        for (int i = 0; i < mLockImageList.Count; i++)
        {
            if (i == 0)
            {
                var bol = Config.GetValue(Config.Achievement1);
                mLockImageList[i].gameObject.SetActive(!bol);
                mUnLockList[i].gameObject.SetActive(bol);
            }
            else if (i == 1)
            {
                var bol = Config.GetValue(Config.Achievement2);
                mLockImageList[i].gameObject.SetActive(!bol);
                mUnLockList[i].gameObject.SetActive(bol);
            }
            else if (i == 2)
            {
                var bol = Config.GetValue(Config.Achievement3);
                mLockImageList[i].gameObject.SetActive(!bol);
                mUnLockList[i].gameObject.SetActive(bol);
            }
            else if (i == 3)
            {
                var bol = Config.GetValue(Config.Achievement4);
                mLockImageList[i].gameObject.SetActive(!bol);
                mUnLockList[i].gameObject.SetActive(bol);
            }
        }
        mLockImageList[0].onClick.RemoveAllListeners();
        mLockImageList[0].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (Config.GetValue(Config.Achievement1))
            {
                mLockImageList[0].gameObject.SetActive(false);
                mUnLockList[0].gameObject.SetActive(true);
            }
        }));
        mLockImageList[1].onClick.RemoveAllListeners();
        mLockImageList[1].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (Config.GetValue(Config.Achievement2))
            {
                mLockImageList[1].gameObject.SetActive(false);
                mUnLockList[1].gameObject.SetActive(true);
            }
        }));
        mLockImageList[2].onClick.RemoveAllListeners();
        mLockImageList[2].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (Config.GetValue(Config.Achievement3))
            {
                mLockImageList[2].gameObject.SetActive(false);
                mUnLockList[2].gameObject.SetActive(true);
            }
        }));
        mLockImageList[3].onClick.RemoveAllListeners();
        mLockImageList[3].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (Config.GetValue(Config.Achievement4))
            {
                mLockImageList[3].gameObject.SetActive(false);
                mUnLockList[3].gameObject.SetActive(true);
            }
        }));

        mUnLockList[0].onClick.RemoveAllListeners();
        mUnLockList[0].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mTipsList[0].SetActive(true);
        }));
        mUnLockList[1].onClick.RemoveAllListeners();
        mUnLockList[1].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mTipsList[1].SetActive(true);
        }));
        mUnLockList[2].onClick.RemoveAllListeners();
        mUnLockList[2].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mTipsList[2].SetActive(true);
        }));
        mUnLockList[3].onClick.RemoveAllListeners();
        mUnLockList[3].onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mTipsList[3].SetActive(true);
        }));

        mTipsBtnClose[0].onClick.RemoveAllListeners();
        mTipsBtnClose[0].onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mTipsList[0].SetActive(false); }));

        mTipsBtnClose[1].onClick.RemoveAllListeners();
        mTipsBtnClose[1].onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mTipsList[1].SetActive(false); }));

        mTipsBtnClose[2].onClick.RemoveAllListeners();
        mTipsBtnClose[2].onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mTipsList[2].SetActive(false); }));

        mTipsBtnClose[3].onClick.RemoveAllListeners();
        mTipsBtnClose[3].onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mTipsList[3].SetActive(false); }));

        mBtnAchievementSsystemClose.onClick.RemoveAllListeners();
        mBtnAchievementSsystemClose.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mAchievementSystemRoot.SetActive(false);
        }));
    }

    int mPageId;
    public void Init(int pageId)
    {
        mPageId = pageId;
    }

    public void OpenSpread()
    {
        UIManager.Instance.OpenPage(EPageType.Animation_Spread);
    }
    public void OpenMethod()
    {
        UIManager.Instance.OpenPage(EPageType.Animation_Method);
    }
    public void OpenForever()
    {
        UIManager.Instance.OpenPage(EPageType.Animation_FeverVoming);    
    }
}
