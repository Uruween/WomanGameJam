using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalAxis;
    [SerializeField] float verticalAxis;
    [SerializeField] float speed;
    [SerializeField] CharacterController character;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform foots;
    [SerializeField] float radius;
    [SerializeField] int jumpHeight;


    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(foots.position, radius, ground);

        if (isGrounded && velocity.y < -2)
        {
            velocity.y = -2;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalAxis + transform.forward * verticalAxis;

        character.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        character.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(foots.position, radius);
    }


}
