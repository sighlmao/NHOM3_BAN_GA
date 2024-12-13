using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject modeSelectionPanel;

    public void OnPlayButtonClick()
    {
        modeSelectionPanel.SetActive(true); // Hien bang chon 3 che do choi  
    }
    
    public void OnModeButtonClick(string mode)
    {
        Debug.Log("Selected mode : " + mode);
        modeSelectionPanel.SetActive(false); // Thuc hien an bang che do choi sau khi ng choi chon che do

    }
}
