using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;

    private int _currentLife;
    private bool _isDead = false;

    public Action OnKill;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Demage(int demage)
    {
        if (_isDead)
            return;
        _currentLife -= demage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        OnKill.Invoke();
    }
}
