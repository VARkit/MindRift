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
    void Start()
    {
        ballRenderer = GetComponent<Renderer>(); // �������� ��������� Renderer ����
    }

    public void Sumbit()
    {
        weight = Int32.Parse(inputField.text);
        transforming = true;
    }
    void Update()
    {   
        if(transforming)
        {   
            float dif2 = size - weight;
            
            if(dif2 > 100)
            {
                point.transform.localPosition = new Vector3(0, 5, 0);
            }
            else if(dif2 < -100)
            {
                point.transform.localPosition = new Vector3(0, -5, 0);
            }
            else
            {
                point.localPosition = new Vector3(0, -3 * dif2 / 100, 0);
            }
            gameObject.transform.position = Vector3.Lerp(transform.position, point.position, speed);
            difference = Mathf.Abs(size - weight); // ��������� ������ �������� ����� �������� � ����� ����-
            print(dif2);
            razn += " " + difference.ToString();

            // ���� �������� ����� 50, ������������� ������� ����
            if (difference == 0)
            {
                ballRenderer.material.SetColor("_EmissionColor", Color.green);
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
       
    }
}
