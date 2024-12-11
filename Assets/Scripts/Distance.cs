using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    TMP_Text distanceTMP;
    public float distance = 0;
        
    void Awake()
    {
        distanceTMP = GetComponent<TMP_Text>();
    }
        
    void Update()
    {
        distanceTMP.text = distance.ToString("#####");
    }
}
