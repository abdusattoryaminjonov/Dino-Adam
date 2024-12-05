using UnityEngine;

public class Adam : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.081f * 2f;
    public float jumpForce = 8f;

    public AudioSource jumpSound;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetButton("Jump"))
            {
                jumpSound.Play();
                direction = Vector3.up * jumpForce;
            }
        }
        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
