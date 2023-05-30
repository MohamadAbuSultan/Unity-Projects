using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5;
    Transform cam;
    float gravity = 10;
    float verticalVelocity = 10;
    public float jumpValue = 7;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isSprint = Input.GetKey(KeyCode.LeftShift);
        float sprint = isSprint ? 1.7f : 1;
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (characterController.isGrounded)
        {
            if (Input.GetAxis("Jump") > 0)
                verticalVelocity = jumpValue;
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;

        if (moveDirection.magnitude > 0.1)
        {
            // magnitude طول المتجه
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // Atan ظل الزاوية
            // Rad2Deg : Radians-to-degrees درجة
            //  cam.eulerAngles.y زاوية الكاميرا على محور y
            // euler / eulerAngles مصطلحات رياضية تدل على زواياً لمجسم ثلاثي الأبعاد وفق معادلة معينة
            transform.rotation = Quaternion.Euler(0, angle, 0);

        }
        moveDirection = cam.TransformDirection(moveDirection);

        moveDirection = new Vector3(moveDirection.x * speed * sprint
                        , verticalVelocity,
                        moveDirection.z * speed * sprint);
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
