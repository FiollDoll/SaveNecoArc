using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class endMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [SerializeField] private GameObject menuEnd;
    [SerializeField] private Text textTotalRecord;
    [SerializeField] private Text textMaxRecord;
    [SerializeField] private allScripts scripts;


    public void ActivateEnd()
    {
        menuEnd.gameObject.SetActive(true);
        GameObject.Find("Dynamic Joystick").gameObject.SetActive(false);
        scripts.level.pointsLock = true;
        textTotalRecord.text = scripts.level.totalLvl.ToString();
        if (scripts.level.totalLvl > scripts.player.playerInfo.maxRecord)
            scripts.player.playerInfo.maxRecord = scripts.level.totalLvl;
        textMaxRecord.text = scripts.player.playerInfo.maxRecord.ToString();
        string jsonString = JsonUtility.ToJson(scripts.player.playerInfo);
        SaveExtern(jsonString);
    }

    public void Retry() => SceneManager.LoadScene("SampleScene");

    public void Menu() => SceneManager.LoadScene("Main");
}
