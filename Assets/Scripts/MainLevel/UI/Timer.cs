using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] float time;
    TMP_Text timerTMP;
    bool isLimited;
    public float Time { get { return time; } }

    void Awake()
    {
        timerTMP = GetComponent<TMP_Text>();
        enabled = false;
    }

    public void Init(int? time)
    {
        if(time == null)
        {
            this.time = 0f;
            isLimited = false;
        }
        else
        {
            this.time = time.Value;
            isLimited = true;
        }
    }

    void Update()
    {
        if (isLimited)
        {
            time -= UnityEngine.Time.deltaTime;

            if (time <= 0f)
            {
                gameManager.EndGameByTime();
            }
        }
        else
        {
            time += UnityEngine.Time.deltaTime;
        }

        timerTMP.text = time.ToString("###0");
    }
}
