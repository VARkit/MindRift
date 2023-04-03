using System.Collections;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public string code = "78114"; // ��� �����
    private string inputCode = ""; // ��������� ������������� ���
    public GameObject door;
    public AudioSource dver;
    AudioClip TryAgain;
    public bool Start;
    float time;
    bool predupr;
    public SaveDataToJson SaveDataToJson;
    public TextMeshProUGUI TextMeshProUGUI;
    // ������� �������� ���� �����
    private void CheckCode()
    {
        if (inputCode == code)
        {
            TextMeshProUGUI.text = "��� ������!";
            gameObject.SetActive(false);
            SaveDataToJson.SaveToJson();
        }
        else
        {
            StartCoroutine(Wrong());
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

    IEnumerator Wrong()
    {
        TextMeshProUGUI.text = "�����������!";
        yield return new WaitForSeconds(1);
        inputCode = ""; // �������� ��������� ���
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