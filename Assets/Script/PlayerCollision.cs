using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController playerController; // Tham chiếu đến PlayerController

    private void Awake()
    {
        playerController = GetComponent<PlayerController>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Debug.Log("Nhặt chìa khóa! Chuyển ải...");
        }
        else if (collision.CompareTag("SpringPush"))
        {
            playerController.JumpPush();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("GroundBreak"))
        {
            //Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("WallBreak"))
        {
            //playerController.ReverseDirection();
            Destroy(collision.gameObject);
            Debug.Log("Đã va chạm với wall break");
        }
    }
}
