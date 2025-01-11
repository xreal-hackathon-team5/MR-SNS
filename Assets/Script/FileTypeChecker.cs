using UnityEngine;

public class FileTypeChecker : MonoBehaviour
{
    [SerializeField]
    private string fileURL = "http://example.com/file.mp4";

    public int ImageFile=1;
    public int VideoFile=3;


    private void Start()
    {
        if (IsVideo(fileURL))
        {
            VideoFile++;
        }
        if (IsImage(fileURL))
        {
            ImageFile++;
        }
    }

    private bool IsVideo(string url)
    {
        // 동영상 확장자 체크
        return url.EndsWith(".mp4") || url.EndsWith(".mov") || url.EndsWith(".avi");
    }

    private bool IsImage(string url)
    {
        // 이미지 확장자 체크
        return url.EndsWith(".png") || url.EndsWith(".jpg") || url.EndsWith(".jpeg");
    }
}