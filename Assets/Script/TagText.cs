using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TagText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp2;

    private string text= "UpdateTag";

    private void Update() 
    {
        tmp2.text = text;
    }
}
