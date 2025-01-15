using UnityEngine;
using UnityEngine.UI;

public class SpecialSkill : MonoBehaviour
{
    Slider specialSlider;
    public bool isCooledDown { get {  return specialSlider.value >= specialSlider.maxValue; } }

    public void Init(float coolDownTime)
    {
        specialSlider = GetComponent<Slider>();
        specialSlider.maxValue = coolDownTime;
    }

    void Update()
    {
        specialSlider.value += Time.deltaTime;
    }

    public void Reset()
    {
        specialSlider.value = 0;
    }
}
