using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    private Vector3 targetScale;
    private Vector3 startScale = Vector3.zero;
    [SerializeField]
    private RectTransform rectTransform;
    
    [SerializeField]
    private float lerpSpeed = 5f;
    
    private bool isScaling = false;
    
    private void OnEnable()
    {
        targetScale = rectTransform.localScale;
        rectTransform.localScale = startScale;
        isScaling = true;
    }

    private void Update()
    {
        if(isScaling)
        {
            // RectTransform의 localScale을 사용하여 크기 조절
            rectTransform.localScale = Vector3.Lerp(
                rectTransform.localScale, 
                targetScale, 
                Time.deltaTime * lerpSpeed
            );
            
            // 거의 목표 크기에 도달했을 때
            if(Vector3.Distance(rectTransform.localScale, targetScale) < 0.01f)
            {
                rectTransform.localScale = targetScale;
                isScaling = false;
            }
        }
    }
}