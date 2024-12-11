using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{    
    TMP_Text timerTMP;
    public float timeLeft;
    public static Timer _timer;
    
    void Awake()
    {
        timerTMP = GetComponent<TMP_Text>();
        _timer = this;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            timeLeft = 0;
            timerTMP.text = timeLeft.ToString("###0");
        }
        
        timerTMP.text = timeLeft.ToString("###0");
    }
}
