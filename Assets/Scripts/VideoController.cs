using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    private int videoNumber;

    public int GetRoundNumber()
    {
        return videoNumber;
    }


    // Use this for initialization
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Video");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
        videoNumber = 1;

        videoPlayer.url = Application.dataPath + "/Videos/Video" + videoNumber + ".mp4";

        //SceneManager.sceneLoaded += IncrementScene;
    }

    // currently busted
    public void IncrementScene()
    {
        videoNumber++;
        videoPlayer.url = Application.dataPath + "/Videos/Video" + videoNumber + ".mp4";
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

}