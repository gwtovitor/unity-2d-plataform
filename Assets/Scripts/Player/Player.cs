using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D myRigidBody;
    public string groundTag;
    public string playerDeathTrigger = "Death";

    [Header("SpeedSetup")]
    public Vector2 friction = new Vector2(0.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("AnimationSetup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float impactScaleY = 0.8f;
    public float impactScaleX = 1.2f;
    public Ease ease = Ease.OutBack;
    public float animationDuration = .3f;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolFalling = "Falling";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    private float _currentSpeed;
    private bool _isJumping = false;

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
                myRigidBody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, playerSwipeDuration);
            }

            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
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
            _currentSpeed = speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }
    }

   private void HandleJump()
{
    if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
    {
        _isJumping = true;
        myRigidBody.velocity = Vector2.up * forceJump;
        Vector3 originalScale = myRigidBody.transform.localScale;

        DOTween.Kill(myRigidBody.transform);
        myRigidBody.transform.localScale = originalScale;

    }
}

    private void HandleJumpAnimate()
    {
        // myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        // myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            animator.SetBool(boolFalling, false);

            if (_isJumping)
            {
                _isJumping = false;
                DOTween.Kill(myRigidBody.transform);
                HandleImpactAnimate();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            animator.SetBool(boolFalling, true);
        }
    }

    private void HandleImpactAnimate()
    {
        // myRigidBody.transform.DOScaleY(impactScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        // myRigidBody.transform.DOScaleX(impactScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public void HandlePlayerDeath()
    {
        animator.SetTrigger(playerDeathTrigger);
    }
}
