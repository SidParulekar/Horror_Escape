using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField] private int keysRequiredtoTrigger = 1;

    private void OnEnable()
    {
        EventService.Instance.OnLightsOffByGhostEvent.AddListener(GhostGiggle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerView>() != null && keysRequiredtoTrigger == GameService.Instance.GetPlayerController().KeysEquipped)
        {
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            keysRequiredtoTrigger++;
        }
    }

    private void GhostGiggle()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SpookyGiggle);
    }

    private void OnDisable()
    {
        EventService.Instance.OnLightsOffByGhostEvent.RemoveListener(GhostGiggle);
    }



}