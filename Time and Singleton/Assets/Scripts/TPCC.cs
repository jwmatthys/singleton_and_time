using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TPCC : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    public float walkingSpeed = 2f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 60f;
    private bool isSprinting;
    private float rotation;
    private CharacterController characterController;
    private Animator anim;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Rotate with A-D
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * rotationSpeed;
        transform.Rotate(0, turn * Time.deltaTime, 0);

        // Move with W-S
        // Sprint with Left Shift
        float pace = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkingSpeed;
        float speed = pace * Input.GetAxis("Vertical");
        if (speed < -walkingSpeed) speed = -walkingSpeed;
        Vector3 movement = speed * transform.forward;
        characterController.SimpleMove(movement);
        anim.SetFloat(Speed, speed);
    }
}