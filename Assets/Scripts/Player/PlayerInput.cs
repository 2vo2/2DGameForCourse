using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool LeftInput { get; private set; }
    public bool RightInput { get; private set; }
    public bool SpaceInput { get; private set; }
    public bool LeftMouseButtonInput { get; private set; }

    private void FixedUpdate()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        RightInput = Input.GetKeyDown(KeyCode.D);
        LeftInput = Input.GetKeyDown(KeyCode.A);
        SpaceInput = Input.GetKeyDown(KeyCode.Space);
        LeftMouseButtonInput = Input.GetMouseButtonDown(0);
    }
}