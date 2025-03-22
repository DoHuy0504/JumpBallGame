using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY = 9f;
    void Start()
    {
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;

                Debug.LogError("Thấy Player trong Scene!");
            }

            else
                Debug.LogError("Không tìm thấy Player trong Scene!");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y + offsetY, transform.position.z);
        }
    }
}
