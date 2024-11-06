using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D myRigidBody;

    [Header("Player Config")]
    public Vector2 velocity;
    public float speed;

    private void Update()
    {
        PlayerMoviment();
    }
    private void PlayerMoviment()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        }


    }
}
