using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D myRigidBody;
    public Vector2 friction = new Vector2(0.1f, 0);
    public Animator animator;

    private float _currentSpeed;
    private bool _isJumping = false;

    public SOPlayerSetup sOPlayerSetup;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
        Runing();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }

            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(sOPlayerSetup.boolRun, false);
        }

        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void Runing()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = sOPlayerSetup.speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
            animator.speed = 1;
        }
    }

   private void HandleJump()
{
    if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
    {
        _isJumping = true;
        myRigidBody.velocity = Vector2.up * sOPlayerSetup.forceJump;
        Vector3 originalScale = myRigidBody.transform.localScale;

        DOTween.Kill(myRigidBody.transform);
        myRigidBody.transform.localScale = originalScale;

    }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(sOPlayerSetup.groundTag))
        {
            animator.SetBool(sOPlayerSetup.boolFalling, false);

            if (_isJumping)
            {
                _isJumping = false;
                DOTween.Kill(myRigidBody.transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(sOPlayerSetup.groundTag))
        {
            animator.SetBool(sOPlayerSetup.boolFalling, true);
        }
    }

    public void HandlePlayerDeath()
    {
        animator.SetTrigger(sOPlayerSetup.playerDeathTrigger);
    }
}
