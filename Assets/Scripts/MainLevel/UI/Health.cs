using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float initialNormalisedHealth;
    [SerializeField] TMP_Text healthTMP;
    [SerializeField] GameManager gameManager;
    [SerializeField] LevelGenerator levelGenerator;
    Slider slider;
    PlayerCollisionHandler playerCollisionHandler;
    PlayerController playerController;

    public void Init(int maxHealth, PlayerCollisionHandler playerCollisionHandler)
    {
        slider = GetComponent<Slider>();
        this.playerCollisionHandler = playerCollisionHandler;
        playerController = playerCollisionHandler.GetComponent<PlayerController>();        
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue * initialNormalisedHealth;
        UpdateSomeThings();
    }

    public void ChangeHealth(int amount)
    {
        slider.value += amount;

        if (slider.value <= 0)
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

    float GetInterpolationValue() => slider.value / slider.maxValue;

    void UpdateSomeThings()
    {
        healthTMP.text = $"{slider.value.ToString()}";
        float interpolationValue = GetInterpolationValue();
        levelGenerator.ChangeChunkMoveSpeed(interpolationValue);
        playerController.ChangePlayerSpeed(interpolationValue);
    }
}
