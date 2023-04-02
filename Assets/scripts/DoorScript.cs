using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public string code = "78114"; // ��� �����
    private string inputCode = ""; // ��������� ������������� ���
    public GameObject door;
    AudioSource dver;
    AudioClip TryAgain;
    public bool Start;
    float time;
    bool predupr;
    public SaveDataToJson SaveDataToJson;
    // ������� �������� ���� �����
    private void CheckCode()
    {
        if (inputCode == code)
        {
            Debug.Log("��� ������, ����� �������!");
            // ������� �����
            gameObject.SetActive(false);
            SaveDataToJson.SaveToJson();
        }
        else
        {
            Debug.Log("��� ��������, ���������� ��� ���.");
            inputCode = ""; // �������� ��������� ���
            SaveDataToJson.SaveToJson();
        }
    }

    // ������� ��������� ����� � ����������
    public void InputCode(string digit)
    {
        // �������� ����� � ��������� ���
        inputCode += digit;

        // ��������� ���, ���� �� ��������� ������
        if (inputCode.Length == code.Length)
        {
            CheckCode();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Start = true;
    }

    private void Update()
    {
        if(Start)
        {
            time += Time.deltaTime;
            if(time >= 15 && time <= 40)
            {
                if(!predupr)
                {
                    predupr = true;
                    dver.Play();
                }
            }
            if (time >= 40)
            {
                Application.Quit();
            }
        }
    }
}