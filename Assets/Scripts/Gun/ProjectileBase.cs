using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    public float timeToDestroy = 2f;
    public float side = 1;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        Debug.Log("CollisionEnter");
        var enemy = other.transform.GetComponent<EnemyBase>();
        Debug.Log(enemy);
        if (enemy != null)
        {
            enemy.Demage(1);
            Destroy(gameObject);
        }
    }
}
