using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public CharacterMovement charMov;
    public void PlayerAttack()
    {
        charMov.DoAttack();
    }
}
