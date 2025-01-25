using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int demage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Kill";
    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;

        PlayerKillAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COllision");
        if (collision.gameObject.TryGetComponent<HealthBase>(out var health))
        {
            Debug.Log("HeaveHealth");

            health.Demage(demage);
            PlayAttackAnimation();

        }
    }

    public void Demage(int amount)
    {
        healthBase.Demage(amount);

    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayerKillAnimation()
    {
        animator.SetTrigger(triggerKill);
    }
}
