using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

[System.Serializable]
public class PlayerInfo
{
    public string language;
    public int maxRecord;
    public int maxHp = 3;
}

public class Player : MonoBehaviour
{
    public int hp = 3;
    [SerializeField] private Text hpText;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    public PlayerInfo playerInfo;
    [SerializeField] private allScripts scripts;

    private Rigidbody rb;

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public void LoadInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LoadExtern();
        if (playerInfo == null)
            playerInfo = new PlayerInfo();
        hpText.text = hp.ToString() + "/" + playerInfo.maxHp;
    }

    public void UpdateHP()
    {
        hp--;
        hpText.text = hp.ToString() + "/" + playerInfo.maxHp;
        if (hp == 0)
            scripts.endMenu.ActivateEnd();
    }

    void Update()
    {
        Vector3 direction = Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical;
        rb.velocity = direction * moveSpeed;

        if (direction != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("run", true);
            Quaternion newRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
        else
            GetComponent<Animator>().SetBool("run", false);
    }
}