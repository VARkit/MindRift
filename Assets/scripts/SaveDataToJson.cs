using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UltimateXR.Mechanics.Weapons;

public class SaveDataToJson : MonoBehaviour
{
    public int mark;
    public string Name;
    public string Gender;
    public int age;
    public string baloons;
    public string[] normals;
    public string[] crackens;
    public int sceneIndex;
    public void SaveToJson()
    {
        // ������� ������, ������� ����� ��������� ���� ������
        
        // ����������� ������ � ������ JSON


        // ���������� ������ � ����
        if(sceneIndex == 0)
        {
            string filePath = Application.dataPath + "/1STLVL.json";
            var LVL1DATA = new SaveData
            {
                age = "������� �����������: " + age.ToString(),
                Name = "��� �����������: " + Name,
                Mark = "������ �� ���������� �����������: " + mark.ToString(),
                Gender = "��� �����������: " + Gender,
                baloons = "����� �� ������� ���� �����8 �����: " + baloons.ToString(),
            };
            string jsonData = JsonConvert.SerializeObject(LVL1DATA,  Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
        else if (sceneIndex == 1)
        {
            string filePath = Application.dataPath + "/2NdLVL.json";
            var LVL2DATA = new LVL2DATA
            {
                b1 = "������� ���� ��������� ��� ������� 1): " + normals[0],
                b2 = "������� ���� ��������� ��� ������� 2): " + normals[1],
                b3 = "������� ���� ��������� ��� ������� 3): " + normals[2],
                b4 = "������� ���� ��������� ��� ������� 4): " + normals[3],
                b5 = "������� ���� ��������� ��� ������� 5): " + normals[4],
                b6 = "������� ���� ��������� ��� ������� 6): " + normals[5],
                b7 = "������� ���� ��������� ��� ������� 7): " + normals[6],
                b8 = "������� ���� ��������� ��� ������� 8): " + normals[7],
                b9 = "������� ���� ��������� ��� ������� 9): " + normals[8],
                b10 = "������� ���� ��������� ��� ������� 10): " + normals[9],

                bFalse1 = "����� ������ ����� �� ������� ��� ������� 1: " + crackens[0],
                bFalse2 = "����� ������ ����� �� ������� ��� ������� 2: " + crackens[1],
                bFalse3 = "����� ������ ����� �� ������� ��� ������� 3: " + crackens[2],
                bFalse4 = "����� ������ ����� �� ������� ��� ������� 4: " + crackens[3],
                bFalse5 = "����� ������ ����� �� ������� ��� ������� 5: " + crackens[4],

            };
            string LVL2 = JsonConvert.SerializeObject(LVL2DATA, Formatting.Indented);
            File.WriteAllText(filePath, LVL2);
        }
        
    }
    private void Start()
    {
        SaveToJson();
    }
    private class SaveData
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Mark { get; set; }
        public string age { get; set; }
        public string baloons { get; set; }

    }
    private class LVL2DATA
    {
        public string b1 { get; set; }
        public string b2 { get; set; }
        public string b3 { get; set; }
        public string b4 { get; set; }
        public string b5 { get; set; }
        public string b6 { get; set; }
        public string b7 { get; set; }
        public string b8 { get; set; }
        public string b9 { get; set; }
        public string b10 { get; set; }
        public string bFalse1 { get; set; }
        public string bFalse2 { get; set; }
        public string bFalse3 { get; set; }
        public string bFalse4 { get; set; }
        public string bFalse5 { get; set; }
    }
}