using TMPro;
using UnityEngine;

public class PlayerRecyclableObjectView : MonoBehaviour, IPlayerView
{
    [Header("References")] 
    [SerializeField] private TMP_Text _playerNameTMP;
    
    public void SetName(string playerName)
    {
        _playerNameTMP.SetText(playerName);
    }
    
    public void Init()
    {
        
        gameObject.SetActive(true);
    }

    public void Recycle()
    {
        gameObject.SetActive(false);
    }
}