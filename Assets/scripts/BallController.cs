using UnityEngine;
using UnityEngine.Pool;
using TMPro;
using System;

public class BallController : MonoBehaviour
{
    public float size; // ������ ����
    public int weight; // ��� ����

    private float difference; // �������� ����� �������� � ����� ����
    private float colorValue; // �������� ����� ����

    private Renderer ballRenderer; // ��������� Renderer ����
    public float speed;
    public Transform point;
    public TMP_InputField inputField;
    public bool transforming;
    public bool isobmanka;
    public int NumSphere;
    public string razn;
    public SaveDataToJson SaveDataToJson;
    bool SendData;
    void Start()
    {
        ballRenderer = GetComponent<Renderer>(); // �������� ��������� Renderer ����
    }

    public void Sumbit()
    {
        weight = Int32.Parse(inputField.text);
        transforming = true;
        SendData = true;
    }
    void Update()
    {   
        
        if(transforming)
        {
            if(SendData)
            {
            razn += " " + difference.ToString();
            SaveDataToJson.normals[NumSphere] = razn;
            SendData = false;
            }
            if(weight >=0 && weight <= 100)
            {
                float dif2 = size - weight;
                print(dif2);
                if (dif2 < 0)
                {
                    point.localPosition = new Vector3(0, -3 * dif2 / 100, 0);
                }
                else
                {
                    point.localPosition = new Vector3(0, -3 * dif2 / 100, 0);
                }
                gameObject.transform.position = Vector3.Lerp(transform.position, point.position, speed);
                difference = Mathf.Abs(size - weight); // ��������� ������ �������� ����� �������� � ����� ����-
                // ���� �������� ����� 50, ������������� ������� ����
                if (difference == 0)
                {
                    ballRenderer.material.SetColor("_EmissionColor", Color.green * 2);
                }
                // ���� �������� ������ 50 � ������ ��� ����� 30, ��������� ������������� �������� ����� ������� � ������ ������
                else if (difference > 0 && difference <= 20)
                {
                    colorValue = Mathf.InverseLerp(0, 40, difference);
                    ballRenderer.material.SetColor("_EmissionColor", new Color(colorValue, 1 - colorValue, 0f));
                }
                // ���� �������� ������ 30 � ������ ��� ����� 10, ��������� ������������� �������� ����� ������ � ������� ������
                else if (difference > 20 && difference <= 40)
                {
                    colorValue = Mathf.InverseLerp(40, 20, difference);
                    ballRenderer.material.SetColor("_EmissionColor", new Color(1f, colorValue, 0f));
                }
                // ���� �������� ������ 10 � ������ ��� ����� 1, ��������� ������������� �������� ����� ������� � ������ ������
                else if (difference > 40 && difference <= 49)
                {
                    colorValue = Mathf.InverseLerp(40, 50, difference);
                    ballRenderer.material.SetColor("_EmissionColor", new Color(1f, 1 - colorValue, colorValue));
                }
                // ���� �������� ������ 1, ������������� ������ ����
                else
                {
                    ballRenderer.material.SetColor("_EmissionColor", Color.black);
                }
            }
            else
            {
                inputField.text = "";
                weight = 0;
                transforming = false;
            }
        }
       
    }
}
