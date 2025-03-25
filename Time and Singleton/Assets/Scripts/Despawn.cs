using UnityEngine;

public class Despawn : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -10) Destroy(gameObject);
    }
}
