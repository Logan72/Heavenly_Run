using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Slider slider;
    [SerializeField] TMP_Text healthTMP;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerCollisionHandler playerCollisionHandler;
    [SerializeField] LevelGenerator levelGenerator;
    PlayerController playerController;

    void Awake()
    {  
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        playerController = playerCollisionHandler.GetComponent<PlayerController>();
        UpdateSomeThings();
    }

    public void ChangeHealth(int amount)
    {
        slider.value += amount;

        if (slider.value == 0)
        {            
            playerCollisionHandler.Die();            
            gameManager.EndGameByDeath();
        }
        else if(amount < 0)
        {            
            playerCollisionHandler.Stumble();
        }

        UpdateSomeThings();
    }

    float GetInterpolationValue() => slider.value / 100;

    void UpdateSomeThings()
    {
        healthTMP.text = $"{slider.value.ToString()} %";
        float interpolationValue = GetInterpolationValue();
        levelGenerator.ChangeChunkMoveSpeed(interpolationValue);
        playerController.ChangePlayerSpeed(interpolationValue);
    }
}
