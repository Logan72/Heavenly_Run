using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text scoreTMP;
    float value = 0;
    bool isGameOver = false;
        
    void Awake()
    {
        scoreTMP = GetComponent<TMP_Text>();
        enabled = false;
    }

    public void ChangeScore(float amount)
    {
        if (!isGameOver)
        {
            value += amount;
            scoreTMP.text = value.ToString("######0");
        }
    }

    public void SetGameOver() => isGameOver = true;
}
