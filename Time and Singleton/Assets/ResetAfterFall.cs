using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAfterFall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
