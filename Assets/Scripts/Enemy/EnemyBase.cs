using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int demage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthBase>(out var health))
        {
            health.Demage(demage);
            PlayAttackAnimation();

        }
    }

    private void PlayAttackAnimation(){
        animator.SetTrigger(triggerAttack);

    }
}
