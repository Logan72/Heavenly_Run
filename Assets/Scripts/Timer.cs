using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    TMP_Text timerTMP;
    [SerializeField] float timeLeft;
    public float TimeLeft { get { return timeLeft; } }

    void Awake()
    {
        timerTMP = GetComponent<TMP_Text>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerTMP.text = timeLeft.ToString("###0");
    }

    public void ModifyTime(float timeAmount)
    {
        timeLeft += timeAmount;
    }
}
