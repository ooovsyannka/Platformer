using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public float HorizontalInput {  get; private set; }
    public bool IsPressUpArrow {  get; private set; }


    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw(Horizontal);
        IsPressUpArrow = Input.GetKey(KeyCode.UpArrow);
    }
}