using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] 
    private string videoURL= "http://43.200.177.36:5000/public/wolfgang/feed_wolfgang_2.mp4";
    [SerializeField]
    private VideoPlayer videoPlayer;

    private void Awake() 
    {
        videoPlayer.url=videoURL;
        videoPlayer.playOnAwake=false;
        videoPlayer.Prepare();
        
        videoPlayer.prepareCompleted+= OnVideoPrepared;
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        videoPlayer.Play();
    }
}
