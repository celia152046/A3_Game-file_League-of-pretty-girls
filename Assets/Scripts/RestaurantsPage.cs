using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RestaurantsPage : BasePage
{
    public Button mBtnJiangBei, mBtnResult, mBtnRestart, mBtnHome, mBtnScene, mBtnRule;
    //加减人数 plus/minus people
    public Button mBtnAdd1, mBtnMuduce1;
    public GameObject mMid1, mMid2, mMidGanRan1, mMidGanRan2;

    public Button mBtnAdd2, mBtnMuduce2;
    public GameObject mRightMid, mRightMidWeiGanRang, mRightMidGanRang;

    List<int> mLeftAddPerson = new List<int>();
    List<int> mRightPerson = new List<int>();
    public Transform mStartPos, mCenterPos, mRightPos;
    //病毒图片 virus 
    public Transform mBingDu01, mBingDu02;

    public GameObject mInfectedRoot, mNoInfectedRoot;
    public Button mBtnCloseInfected, mBtnCloseNoInfected;

    public GameObject mSceneListRoot;
    public Button mBtnLineUp;
    Transform mTweenEmpty;
    private void Start()
    {
        mTweenEmpty = new GameObject("_EmptyTween_").transform;
        #region 人物点击
        mBtnAdd1.onClick.RemoveAllListeners();
        mBtnAdd1.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (mLeftAddPerson.Count < 2)
            {
                //增加
                if (mLeftAddPerson.Count == 0)
                {
                    mBtnMuduce1.gameObject.SetActive(true);
                    mMid1.SetActive(true);
                    mLeftAddPerson.Add(0);
                }
                else if (mLeftAddPerson.Count == 1)
                {
                    mMid2.SetActive(true);
                    mLeftAddPerson.Add(0);
                }
            }
            else
            {

            }
        }));
        mBtnMuduce1.onClick.RemoveAllListeners();
        mBtnMuduce1.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (mLeftAddPerson.Count == 2)
            {
                mMid2.SetActive(false);
                mLeftAddPerson.RemoveAt(0);
            }
            else if (mLeftAddPerson.Count == 1)
            {
                mMid1.SetActive(false);
                mBtnMuduce1.gameObject.SetActive(false);
                mLeftAddPerson.RemoveAt(0);
            }
        }));

        mBtnAdd2.onClick.RemoveAllListeners();
        mBtnAdd2.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (mRightPerson.Count == 0)
            {
                mRightMid.SetActive(true);
                mBtnMuduce2.gameObject.SetActive(true);
                mRightPerson.Add(0);
            }
        }));
        mBtnMuduce2.onClick.RemoveAllListeners();
        mBtnMuduce2.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            if (mRightPerson.Count > 0)
            {
                mRightMid.SetActive(false);
                mBtnMuduce2.gameObject.SetActive(false);
                mRightPerson.RemoveAt(0);
            }
        }));
        #endregion
        mBtnJiangBei.onClick.RemoveAllListeners();
        mBtnJiangBei.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.OpenPage(EPageType.AchievementPage, false);
        }));
        mBtnResult.onClick.RemoveAllListeners();
        mBtnResult.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {

            if (mLeftAddPerson.Count > 0 && mRightPerson.Count > 0)
            {
                //中间到右边 middle to right
                mBingDu01.localPosition = mStartPos.localPosition;
                mBingDu01.gameObject.SetActive(true);
                mBingDu01.DOLocalMove(mCenterPos.localPosition, 2).OnComplete(() =>
                {
                    if (mLeftAddPerson.Count == 1) { mMidGanRan1.SetActive(true); }
                    else if (mLeftAddPerson.Count == 2) { mMidGanRan1.SetActive(true); mMidGanRan2.SetActive(true); }
                    mBingDu02.localPosition = mCenterPos.localPosition;
                    mBingDu02.gameObject.SetActive(true);
                    mBingDu02.DOLocalMove(mRightPos.localPosition, 2).OnComplete(() =>
                    {
                        Config.SetValue(Config.Achievement3, 1);
                        mRightMidGanRang.SetActive(true);
                        mRightMid.SetActive(false);

                        //延迟显示 appear result description after the animation
                        mTweenEmpty.localScale = Vector3.zero;
                        mTweenEmpty.DOScale(2, 2).OnComplete(()=> {
                            //显示结果 appear result
                            mInfectedRoot.SetActive(true);
                           
                        }).Play();
                       
                    }).Play();
                }).Play();
            }
            else if (mLeftAddPerson.Count == 0 && mRightPerson.Count > 0)
            {
                //直接飞右边  病毒不飞 no fly
                //mBingDu01.localPosition = mStartPos.localPosition;
                //mBingDu01.gameObject.SetActive(true);
                //mBingDu01.DOLocalMove(mRightPos.localPosition, 2).OnComplete(() =>
                //{
                    Config.SetValue(Config.Achievement4, 1);
                    mRightMidWeiGanRang.SetActive(true);
                    mRightMid.SetActive(false);

                    mTweenEmpty.localScale = Vector3.zero;
                    mTweenEmpty.DOScale(2, 2).OnComplete(() => {
                        //显示结果 appear result
                        mNoInfectedRoot.SetActive(true);
                       
                    }).Play();
                   
                //}).Play();
            }
            else if (mLeftAddPerson.Count > 0 && mRightPerson.Count == 0)
            {
                //飞中间 fly to middle
                mBingDu01.localPosition = mStartPos.localPosition;
                mBingDu01.gameObject.SetActive(true);
                mBingDu01.DOLocalMove(mCenterPos.localPosition, 2).OnComplete(() =>
                {
                    Config.SetValue(Config.Achievement3, 1);
                    mRightMidWeiGanRang.SetActive(false);
                    mRightMid.SetActive(false);

                    mMidGanRan1.SetActive(true);
                    if (mLeftAddPerson.Count == 2)
                    {
                        mMidGanRan2.SetActive(true);
                    }

                    mTweenEmpty.localScale = Vector3.zero;
                    mTweenEmpty.DOScale(2, 2).OnComplete(() => {
                        //显示结果 appear result
                        mInfectedRoot.SetActive(true);                       
                    }).Play();
                    
                }).Play();
            }
            else
            {

            }
        }));
        mBtnRestart.onClick.RemoveAllListeners();
        mBtnRestart.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseLastPage();
            UIManager.Instance.OpenPage(EPageType.ResaurantsPage);
        }));
        mBtnHome.onClick.RemoveAllListeners();
        mBtnHome.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseAllPage();
        }));
        mBtnScene.onClick.RemoveAllListeners();
        mBtnScene.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            mBtnScene.gameObject.SetActive(false);
            mSceneListRoot.SetActive(true);
        }));
        mBtnRule.onClick.RemoveAllListeners();
        mBtnRule.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseLastPage();
        }));


        mBtnCloseInfected.onClick.RemoveAllListeners();
        mBtnCloseInfected.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mInfectedRoot.SetActive(false); }));

        mBtnCloseNoInfected.onClick.RemoveAllListeners();
        mBtnCloseNoInfected.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { mNoInfectedRoot.SetActive(false); }));

        mBtnLineUp.onClick.RemoveAllListeners();
        mBtnLineUp.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIManager.Instance.CloseLastPage();
            UIManager.Instance.CloseLastPage();
            UIManager.Instance.CloseLastPage();
            UIManager.Instance.OpenPage(EPageType.LineUpPage);
        }));
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
