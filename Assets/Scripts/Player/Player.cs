using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D myRigidBody;
    public string groundTag;

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

    private float _currentSpeed;
    private bool _isJumping = false;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
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

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            myRigidBody.velocity = Vector2.up * forceJump;
            myRigidBody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidBody.transform);
            HandleJumpAnimate();
        }
    }

    private void HandleJumpAnimate()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) && _isJumping)
        {
            _isJumping = false;
            DOTween.Kill(myRigidBody.transform);
            HandleImpactAnimate();
        }
    }

    private void HandleImpactAnimate()
    {
        myRigidBody.transform.DOScaleY(impactScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(impactScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
