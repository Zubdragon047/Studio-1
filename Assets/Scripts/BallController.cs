using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private float ballJumpForce = 1f;
    private bool isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void moveBall(Vector3 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.z);
        Vector3 inputYPlane = new(0, input.y, 0);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);
        if (isGrounded)
        {
            sphereRigidBody.AddForce(inputYPlane * ballJumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
