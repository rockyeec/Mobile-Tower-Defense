using UnityEngine;

public class PlaySfxOnEnable : MonoBehaviour
{
    [SerializeField] private string soundName = string.Empty;
    private void OnEnable()
    {
        AudioManager.PlaySFX(soundName, transform.position);
    }
}
