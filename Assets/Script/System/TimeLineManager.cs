using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TimeLineManager : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public static TimeLineManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //同じゲームオブジェクトにあるPlayableDirectorを取得する
        playableDirector = GetComponent<PlayableDirector>();
    }
    //再生する
    public void PlayTimeline()
    {
        playableDirector.Play();
    }

    //一時停止する
    public void PauseTimeline()
    {
        playableDirector.Pause();
    }

    //一時停止を再開する
    public void ResumeTimeline()
    {
        playableDirector.Resume();
    }

    //停止する
    public void StopTimeline()
    {
        playableDirector.Stop();
    }
}
