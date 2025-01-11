using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    private DataManager dataManager;
    /*
    [SerializeField]
    private List<GameObject> tagObjects = new List<GameObject>(); // 태그 오브젝트 리스트
    [SerializeField]
    private List<GameObject> infoUI= new List<GameObject>();
    [SerializeField]
    private List<GameObject> VideoUI= new List<GameObject>();
    
    [SerializeField]
    private FileTypeChecker fileTypeChecker;
    */
    [SerializeField]
    private List<GameObject> infoUI= new List<GameObject>();
    public bool isActive = true;
    private void CreateTag()
    {   

        /*float radius = 5f; // 구의 반지름
        
        for (int i = 0; i < tagCount; i++)
        {
            // 구면 좌표계 사용하여 랜덤한 위치 계산
            float phi = Random.Range(0f, 2f * Mathf.PI);
            float theta = Random.Range(0f, Mathf.PI);
            
            // 구면 좌표를 직교 좌표로 변환
            float x = radius * Mathf.Sin(theta) * Mathf.Cos(phi);
            float y = radius * Mathf.Sin(theta) * Mathf.Sin(phi);
            float z = radius * Mathf.Cos(theta);
            
            Vector3 position = new Vector3(dataManager.pos_x, dataManager.pos_y, dataManager.pos_z);
            
            // 태그 오브젝트 생성
            GameObject tag = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            tag.transform.position = position;
        }*/
    }

    private void Update() 
    {

        /*if(!isActive)
        {
            for(int i=0; i<tagHandler.tagCount; i++)
            {
                tag[i].SetActive(false);
            }

            foreach(GameObject info in infoUI)
            {
                if(info != null)
                {
                    info.SetActive(true);
                }
            }
        }

        */
        
    }
}