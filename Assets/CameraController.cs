using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f; // Tốc độ di chuyển camera
    public float boundaryZone = 50f; // Kích thước vùng lề màn hình (px)
    public float boundaryX = 20f; // Giới hạn di chuyển của camera trên trục X

    void Update()
    {
        HandleKeyboardInput();
        HandleMouseEdgeMovement();
    }

    // Điều khiển bằng bàn phím (phím mũi tên hoặc A/D)
    void HandleKeyboardInput()
    {
        // Lấy đầu vào từ phím mũi tên trái/phải hoặc A/D
        float horizontalInput = Input.GetAxis("Horizontal");

        // Tính toán vị trí mới của camera
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;

        // Giới hạn camera trong phạm vi boundaryX
        newPosition.x = Mathf.Clamp(newPosition.x, -boundaryX, boundaryX);

        // Cập nhật vị trí của camera
        transform.position = newPosition;
    }

    // Điều khiển bằng chuột khi chuột ở lề màn hình
    void HandleMouseEdgeMovement()
    {
        // Lấy vị trí ngang của chuột trên màn hình
        float mouseX = Input.mousePosition.x;

        // Nếu chuột ở lề trái của màn hình
        if (mouseX <= boundaryZone)
        {
            // Di chuyển camera sang trái
            Vector3 newPosition = transform.position - Vector3.right * moveSpeed * Time.deltaTime;

            // Giới hạn camera trong phạm vi boundaryX
            newPosition.x = Mathf.Clamp(newPosition.x, -boundaryX, boundaryX);

            // Cập nhật vị trí của camera
            transform.position = newPosition;
        }
        // Nếu chuột ở lề phải của màn hình
        else if (mouseX >= Screen.width - boundaryZone)
        {
            // Di chuyển camera sang phải
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;

            // Giới hạn camera trong phạm vi boundaryX
            newPosition.x = Mathf.Clamp(newPosition.x, -boundaryX, boundaryX);

            // Cập nhật vị trí của camera
            transform.position = newPosition;
        }
    }
}
