using UnityEngine;

public class ContinuousSpecialController : PlayerController
{
    [SerializeField] float specialSkillTime;

    protected override void DoSpecial()
    {
        animator.SetBool(specialParameter, true);

        StartCoroutine(Utility.DoCoroutine(() => animator.SetBool(specialParameter, false), specialSkillTime));
    }
}
