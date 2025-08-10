using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalAxis;
    [SerializeField] float verticalAxis;
    [SerializeField] float speed;
    //[SerializeField] CharacterController character;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform foots;
    [SerializeField] float radius;
    [SerializeField] int jumpHeight;

    public bool isMovementEnabled;

    [SerializeField] Rigidbody rigid;


    private void Awake()
    {
        //character = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
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

        if (isMovementEnabled)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            horizontalAxis = Input.GetAxis("Horizontal");
            verticalAxis = Input.GetAxis("Vertical");

            Vector3 direction = (transform.forward * verticalAxis) + (transform.right * horizontalAxis);
            direction.Normalize(); // Normaliza para que la velocidad sea constante en diagonales

            // Aplicar la velocidad manteniendo la componente Y (gravedad/salto)
            rigid.linearVelocity = new Vector3(
                direction.x* speed,
                rigid.linearVelocity.y,
                direction.z* speed
            );
            //character.Move(move * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        //Vector3 direction = transform.forward;
        //rigid.linearVelocity = new Vector3(direction.x, rigid.linearVelocity.y, direction.y);

        //character.Move(velocity * Time.deltaTime);

        if (transform.position.y < -15)
        {
            Invoke("DestroyDistance", 2);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(foots.position, radius);
    }

    private void DestroyDistance()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Death");
    }


}
