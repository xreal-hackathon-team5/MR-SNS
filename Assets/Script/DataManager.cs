using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Bubbles
{
    public List<BubbleData> bubbles;
}

[System.Serializable]
public class BubbleData
{
    public List<Feed> feeds;
    public int id;
    public string image_url;
    public float pos_x;
    public float pos_y;
    public float pos_z;
    public int size_level;
    public List<Tag> tags;
    public string title;
}

[System.Serializable]
public class Feed
{
    public int bubble_id;
    public string content;
    public string created_at;
    public int id;
    public bool is_advertisement;
    public bool is_liked;
    public int like_count;
    public string media_type;
    public string media_url;
    public List<Tag> tags;
    public User user;
    public int view_count;
}

[System.Serializable]
public class Tag
{
    public int bubble_id;
    public string content;
    public int id;
    public bool is_advertisement;
    public int size_level;
}

[System.Serializable]
public class User
{
    public int id;
    public bool is_sponsor;
    public string profile_image_url;
    public string username;
}

// JSON 파싱을 위한 매니저 클래스
public class DataManager : MonoBehaviour
{
    private List<BubbleData> bubbleDataList;
    [SerializeField]
    private GameObject bubbleGO;

    void Start()
    {
        // SSL 인증서 오류 무시
        ServicePointManager.ServerCertificateValidationCallback += 
            (sender, cert, chain, sslPolicyErrors) => true;
        StartCoroutine(SendGetRequest());
    }

    IEnumerator SendGetRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://t5.jdn.kr/bubbles");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            ParseJsonData(request.downloadHandler.text);
            foreach (BubbleData bubbleData in bubbleDataList)
            {
                _ = Instantiate<GameObject>(bubbleGO, new Vector3(bubbleData.pos_x, bubbleData.pos_y, bubbleData.pos_z), Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
    }

    void ParseJsonData(string jsonString)
    {
        // JSON 문자열을 BubbleData 리스트로 변환
        Bubbles bubbles = JsonUtility.FromJson<Bubbles>(jsonString);
        bubbleDataList = bubbles.bubbles;
    }

    // 특정 버블의 데이터 가져오기
    public BubbleData GetBubbleData(int bubbleId)
    {
        return bubbleDataList?.Find(x => x.id == bubbleId);
    }

    // 특정 버블의 피드 가져오기
    public List<Feed> GetBubbleFeeds(int bubbleId)
    {
        var bubble = GetBubbleData(bubbleId);
        return bubble?.feeds;
    }

    // 특정 버블의 태그 가져오기
    public List<Tag> GetBubbleTags(int bubbleId)
    {
        var bubble = GetBubbleData(bubbleId);
        return bubble?.tags;
    }
}