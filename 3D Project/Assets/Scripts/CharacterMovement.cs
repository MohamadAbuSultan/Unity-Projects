using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5;
    Transform cam;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horziontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        // Atan ظل الزاوية
        // Rad2Deg : Radians-to-degrees درجة
        //  cam.eulerAngles.y زاوية الكاميرا على محور y
        // euler / eulerAngles مصطلحات رياضية تدل على زواياً لمجسم ثلاثي الأبعاد وفق معادلة معينة

        transform.rotation = Quaternion.Euler(0, angle, 0);

        characterController.Move(new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed);
    }
}
