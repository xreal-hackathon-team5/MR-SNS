using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMobile : MonoBehaviour
{
    [SerializeField]
    private GameObject mobile;
    
    [SerializeField]
    private float proximityDistance = 0.2f; 

    private bool isActive= false;
    
    private void Update() 
    {
        if(mobile != null)
        {
            // 현재 오브젝트와 모바일 사이의 거리 계산
            float distance = Vector3.Distance(transform.position, mobile.transform.position);
            
            // 설정된 거리보다 가까워지면
            if(distance <= proximityDistance)
            {
                //gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
}