using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LineUpPage : BasePage
{
    public RectTransform mBgImage;
    public Transform mPlayer; Animator mPlayerAnimator;
    public Button mBtnRule, mBtnLockach, mBtnUnLockach, mBtnResult, mBtnRestart, mBtnHome;

    public Animator mInject, mWalk, mJump;
    public Image mBingDuImg;
    public Transform mFixedRoot;
    public Transform mStartPoint;
    public Transform mDeskPoint;
    public Transform mPlayerTips;

    //将被提示框 tips 
    public Button mBtnLockTips, mBtnUnLockTips;

    //小于1m提示 less than 1m tips
    public GameObject mLessThanonemRoot;
    public Button mBtnCloseLessThanonem;
    //>=1m提示 more than 1m tips
    public GameObject mMoreThanonemRoot;
    public Button mBtnCloseMoreThanonem;
    //SceneList
    public Button mBtnSceneListLock, mBtnSceneListUnLock;
    //移动速度 moving speed
    public float mSpeed = 5;
    //是否点击了结果页面 click result
    bool mIsClickResult = false;
    bool mIsWin = true;

    Transform mTweenEmpty;
    private void Start()
    {
        if (Config.GetValue(Config.Achievement1) && Config.GetValue(Config.Achievement2))
        {
            mBtnSceneListUnLock.gameObject.SetActive(true);
        }
        mTweenEmpty = new GameObject("_TweenEmpty001_").transform;
        if (Config.GetValue(Config.Achievement1) || Config.GetValue(Config.Achievement2))
        {
            mBtnLockach.gameObject.SetActive(false);
            mBtnUnLockach.gameObject.SetActive(true);
        }
        mPlayerAnimator = mPlayer.GetComponent<Animator>();
        mBtnRule.onClick.RemoveAllListeners();
        mBtnRule.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseLastPage();
        }));
        mBtnLockach.onClick.RemoveAllListeners();
        mBtnLockach.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (mIsClickResult)
            {
                mBtnUnLockach.gameObject.SetActive(true);
                mBtnLockach.gameObject.SetActive(false);
                mBtnUnLockTips.gameObject.SetActive(true);
                mBtnLockTips.gameObject.SetActive(true);
            }
            else
            {
                mBtnLockTips.gameObject.SetActive(true);
            }
        }));
        mBtnUnLockach.onClick.RemoveAllListeners();
        mBtnUnLockach.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.OpenPage(EPageType.AchievementPage, false);
        }));
        mBtnLockach.onClick.RemoveAllListeners();
        mBtnLockach.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mBtnLockTips.gameObject.SetActive(true); }));
        mBtnResult.onClick.RemoveAllListeners();
        mBtnResult.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mIsClickResult = true;
            //检测当前角色所在位置 check the location of player
            //if (mPlayer.transform.localPosition.x <= -88)//小于1M
            //{
            //    mIsWin = false;
            //    mLessThanonemRoot.SetActive(true);
            //    Config.SetValue(Config.Achievement2, 1);
            //}
            //else
            //{
            //    mIsWin = true;
            //    mMoreThanonemRoot.SetActive(true);
            //    Config.SetValue(Config.Achievement1, 1);
            //}

            if (mPlayer.transform.localPosition.x <= -90)
            {
                mPlayerTips.gameObject.SetActive(true);
                //病毒开始转移到角色头顶 virus follow the player
                mBingDuImg.transform.position = mStartPoint.position;
                mBingDuImg.transform.SetParent(mPlayer.transform);
                mBingDuImg.transform.DOLocalMoveX(0, 2).OnComplete(() =>
                {
                    //播放感染动作 player infected animation
                    mPlayerAnimator.runtimeAnimatorController = mInject.runtimeAnimatorController;

                    mIsWin = false;
                    Config.SetValue(Config.Achievement1, 1);
                    mTweenEmpty.localScale = Vector3.zero;
                    mTweenEmpty.DOScale(2, 2).OnComplete(()=> {
                        mLessThanonemRoot.SetActive(true);
                    }).Play();
                }).Play();
            }
            else
            {
                mPlayerTips.gameObject.SetActive(false);
                mPlayerAnimator.runtimeAnimatorController = mJump.runtimeAnimatorController;

                mBingDuImg.transform.SetParent(mFixedRoot);
                mBingDuImg.transform.DOMove(mDeskPoint.position, 2).OnComplete(() =>
                {
                    mIsWin = true;
                    Config.SetValue(Config.Achievement2, 1);

                    mTweenEmpty.localScale = Vector3.zero;
                    mTweenEmpty.DOScale(2, 2).OnComplete(() => {
                        mMoreThanonemRoot.SetActive(true);
                    }).Play();
                }).Play();
            }
        }));
        mBtnRestart.onClick.RemoveAllListeners();
        mBtnRestart.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //关闭自己再打开 Close 
            UIManager.Instance.CloseLastPage();
            UIManager.Instance.OpenPage(EPageType.LineUpPage);
        }));
        mBtnHome.onClick.RemoveAllListeners();
        mBtnHome.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { UIManager.Instance.CloseAllPage(); }));

        mBtnLockTips.onClick.RemoveAllListeners();
        mBtnLockTips.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mBtnLockTips.gameObject.SetActive(false); }));
        mBtnUnLockTips.onClick.RemoveAllListeners();
        mBtnUnLockTips.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mBtnUnLockTips.gameObject.SetActive(false); }));

        //小于1m点击关闭 less than 1m close
        mBtnCloseLessThanonem.onClick.RemoveAllListeners();
        mBtnCloseLessThanonem.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mLessThanonemRoot.SetActive(false); }));
        mBtnCloseMoreThanonem.onClick.RemoveAllListeners();
        mBtnCloseMoreThanonem.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mMoreThanonemRoot.SetActive(false); }));

        //SceneList
        mBtnSceneListLock.onClick.RemoveAllListeners();
        mBtnSceneListLock.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (mIsClickResult)
            {
                mBtnSceneListLock.gameObject.SetActive(false);
                mBtnSceneListUnLock.gameObject.SetActive(true);
            }
        }));
        mBtnSceneListUnLock.onClick.RemoveAllListeners();
        mBtnSceneListUnLock.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.OpenPage(EPageType.IntroductionPage5, false);
        }));
    }
    bool mIsGanRang = false;
    bool mIsGanRang_MoveOut = false;
    private void Update()
    {
        if (mMoveLeft || Input.GetKey(KeyCode.A))
        {
            mPlayerAnimator.SetBool("walk", true);
            //玩家跟随移动 且向左方 player walk
            mPlayer.localScale = new Vector3(60, 60, 60);
            mPlayer.localPosition = new Vector3(mPlayer.localPosition.x - .5f * mSpeed, mPlayer.localPosition.y, 0);
            if (mPlayer.localPosition.x < -240)
            {
                mPlayer.localPosition = new Vector3(-240, mPlayer.localPosition.y, 0);
            }
            //背景图跟随移动且限定最小位置 background follow player moving
            mBgImage.localPosition = new Vector3(mBgImage.localPosition.x + .5f * mSpeed, mBgImage.localPosition.y, 0);
            if (mBgImage.localPosition.x > -1024)
            {
                mBgImage.localPosition = new Vector3(-1024, mBgImage.localPosition.y, 0);
            }
        }
        else if (mMoveRight || Input.GetKey(KeyCode.D))
        {
            mPlayerAnimator.SetBool("walk", true);
            mPlayer.localScale = new Vector3(-60, 60, 60);
            mPlayer.localPosition = new Vector3(mPlayer.localPosition.x + .5f * mSpeed, mPlayer.localPosition.y, 0);
            if (mPlayer.localPosition.x >= 740)
            {
                mPlayer.localPosition = new Vector3(740, mPlayer.localPosition.y, 0);
            }
            //背景图跟随移动且限定最小位置 background moving to maximum location
            mBgImage.localPosition = new Vector3(mBgImage.localPosition.x - .5f * mSpeed, mBgImage.localPosition.y, 0);
            if (mBgImage.localPosition.x < -1970)
            {
                mBgImage.localPosition = new Vector3(-1970, mBgImage.localPosition.y, 0);
            }

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || (!mMoveLeft && !mMoveRight))
        {
            mPlayerAnimator.SetBool("walk", false);
        }
        //if (mIsGanRang == false)
        //{
        if (mPlayer.transform.localPosition.x <= -90)
        {
            mPlayerTips.gameObject.SetActive(true);
        }
        else { mPlayerTips.gameObject.SetActive(false); }
        //}
        //if (mIsGanRang)
        //{
        //    if (mIsGanRang_MoveOut == false)
        //    {
        //        if (mPlayer.transform.localPosition.x >= -80)
        //        {
        //            mPlayerTips.gameObject.SetActive(false);
        //            mPlayerAnimator.runtimeAnimatorController = mJump.runtimeAnimatorController;
        //            mIsGanRang = false;
        //            mIsGanRang_MoveOut = true;

        //            mBingDuImg.transform.SetParent(mFixedRoot);
        //            mBingDuImg.transform.DOMove(mDeskPoint.position, 2).Play();
        //        }
        //    }
        //}
    }
    private bool mMoveLeft, mMoveRight;
    public void LeftPointer()
    {
        mMoveLeft = true;
    }
    public void LeftExit()
    {
        mMoveLeft = false;
    }
    public void RightPointer()
    {
        mMoveRight = true;
    }
    public void RightExit()
    {
        mMoveRight = false;
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
