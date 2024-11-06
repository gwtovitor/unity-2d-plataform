 using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D myRigidBody;

    [Header("Player Config")]
    public Vector2 friction = new Vector2(0.1f, 0);
    public float speed;
    public float forceJump = 2;

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }
    private void HandleMoviment()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        }

        if(myRigidBody.velocity.x > 0){
            myRigidBody.velocity -= friction;
        }else if(myRigidBody.velocity.x < 0){
            myRigidBody.velocity += friction;

        }

    }
    private void HandleJump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * forceJump   ;
        }
    }
}
