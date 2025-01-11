using Oculus.Interaction;
using UnityEngine;

public class CheckInteractableState : MonoBehaviour
{
    [SerializeField]
    private RayInteractable rayInteractable; // RayInteractable 컴포넌트 참조
    public GameObject gameObject;

    void Update()
    {
        if (rayInteractable != null)
        {
            // 현재 상태 가져오기
            InteractableState currentState = rayInteractable.State;

            // 상태가 Disabled일 때 특정 작업 수행
            if (currentState == InteractableState.Hover)
            {
                PerformActionOnDisabled();
            }
        }
    }

    private void PerformActionOnDisabled()
    {
        gameObject.SetActive(false);
    }
}