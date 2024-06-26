using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    
    public bool InGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, 0);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out Ground ground))
            {
                return true;
            }
        }

        return false;
    }
}
