using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jump = 15f;
    [SerializeField] float _jumpPush = 33f;
    Rigidbody2D _rigi;
    private int _direction = 1; // 1 là sang phải, -1 là sang trái
    JumpZone jumpZone; // Tham chiếu đến vùng nhấn

    private void Awake()
    {
        _rigi = GetComponent<Rigidbody2D>();
        jumpZone = FindFirstObjectByType<JumpZone>();
    }

    private void Update()
    {
        //Jump();
    }

    void FixedUpdate()
    {
        MoveBall();
        ReverseDirection();
    }

    private void MoveBall()
    {
        float _moveInput = _direction; // Giữ hướng di chuyển theo _direction

        _rigi.linearVelocity = new Vector2(_moveInput * _speed, _rigi.linearVelocity.y);

        if (_moveInput > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }

    public void Jump()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            _rigi.linearVelocity = new Vector2(_rigi.linearVelocity.x, _jump);
        }
    }
    public void JumpPush()
    {
        _rigi.linearVelocity = new Vector2(0, _jumpPush);
    }

    public void ReverseDirection()
    {
        float rayLength = 0.8f;
        Vector2 direction = _direction > 0 ? Vector2.right : Vector2.left;
        Vector2 rayOrigin = transform.position + new Vector3(_direction * 0.5f, 0, 0);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayLength);

        if (hit.collider != null && (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("WallBreak")))
        {
            _direction *= -1;
        }
        Debug.DrawRay(rayOrigin, direction * rayLength, Color.red);
    }
}
