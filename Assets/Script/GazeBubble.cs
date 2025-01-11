using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeBubble : MonoBehaviour
{
    [SerializeField]
    private List<BubbleManager> bubbleManagerList = new List<BubbleManager>();
    
    private float gazeTimer = 0f;
    private float gazeThreshold = 2f;
    private bool isGazing = false;
    private BubbleManager currentGazedManager = null; // 현재 보고 있는 버블 매니저

    void CheckBubbleInFront()
    {
        float rayDistance = 100f;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Bubble"))
            {
                // 리스트에서 현재 보고 있는 버블 매니저 찾기
                BubbleManager hitManager = bubbleManagerList.Find(manager => 
                    manager.gameObject.transform.position == hit.collider.gameObject.transform.position);
                
                if (hitManager != null)
                {
                    // 같은 버블을 계속 보고 있는 경우
                    if (currentGazedManager == hitManager)
                    {
                        isGazing = true;
                        gazeTimer += Time.deltaTime;
                        
                        if (gazeTimer >= gazeThreshold)
                        {
                            hitManager.isActive = false; // 버블 매니저의 isActive를 false로 설정
                            gazeTimer = 0f;
                            isGazing = false;
                            currentGazedManager = null;
                        }
                    }
                    // 다른 버블을 보기 시작한 경우
                    else
                    {
                        currentGazedManager = hitManager;
                        gazeTimer = 0f;
                        isGazing = true;
                    }
                }
            }
            else
            {
                ResetGaze();
            }
        }
        else
        {
            ResetGaze();
        }
    }

    private void ResetGaze()
    {
        if (isGazing)
        {
            gazeTimer = 0f;
            isGazing = false;
            currentGazedManager = null;
        }
    }

    void Update()
    {
        CheckBubbleInFront();
    }
}