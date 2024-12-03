using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Transform positionToShot;

    public Transform playerSideReference;
    public ProjectileBase prefabProjectile;
    public float timeBetweenShoot = .3f;

    private Coroutine _currentCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentCoroutine = StartCoroutine(StartShot());
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = transform.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
