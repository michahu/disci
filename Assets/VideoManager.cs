using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private int videoNumber;
    public VideoPlayer videoPlayer;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Video");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }


        if (RoundManager.instance == null) videoNumber = 1;
        else videoNumber = RoundManager.instance.GetRoundNumber();


        videoPlayer.url = Application.dataPath + "/Videos/Video" + videoNumber + ".mp4";
    }
}
