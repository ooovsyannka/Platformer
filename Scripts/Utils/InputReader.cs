using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public float HorizontalInput {  get; private set; }
    public bool IsJump {  get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw(Horizontal);
        IsJump = Input.GetKey(KeyCode.UpArrow);
    }
}