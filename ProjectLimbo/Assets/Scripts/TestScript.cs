using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    
    public GameObject Player;
    public Vector2 ResetPosition = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Player.transform.position = new Vector3(ResetPosition.x, ResetPosition.y, 0);
            }
        }
    }
}
