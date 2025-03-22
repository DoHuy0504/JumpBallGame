using UnityEngine;

public class JumpZone : MonoBehaviour
{
    private void Update()
    {
        Vector2 clickPosition = Vector2.zero;
        bool isClick = false;

        // Kiểm tra nếu là PC (chuột)
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isClick = true;
        }
        // Kiểm tra nếu là Mobile (cảm ứng)
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            isClick = true;
        }

        // Nếu có click hoặc touch
        if (isClick)
        {
            Collider2D hit = Physics2D.OverlapPoint(clickPosition);
            if (hit != null && hit.gameObject == gameObject)
            {
                //Debug.Log("JumpZone Clicked! Player Jump!");
                FindFirstObjectByType<PlayerController>()?.Jump();
            }
            else
            {
                //Debug.Log("Clicked Outside JumpZone");
            }
        }
    }
}
