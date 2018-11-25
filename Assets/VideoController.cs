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
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        videoNumber = 1;

        videoPlayer.url = Application.dataPath + "/Videos/Video" + videoNumber + ".mp4";

        SceneManager.sceneLoaded += IncrementScene;
    }

    // currently busted
    void IncrementScene(Scene scene, LoadSceneMode mode)
    {
        // videoNumber++;
        videoPlayer.url = Application.dataPath + "/Videos/Video" + videoNumber + ".mp4";
    }

}