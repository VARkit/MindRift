using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class VVOD_INFO : MonoBehaviour
{
    public GameObject[] help_texts;
    public TMP_InputField input_field_name;
    public TMP_InputField input_field_age;
    public TMP_Dropdown TMP_Dropdown_sex;
    public TMP_Dropdown dropdown_mark;
    public int item;
    public string name;
    public int mark;
    public int age;
    public string sex;
    public GameObject canv;
    public SaveDataToJson SaveDataToJson;
    public void EnterText()
    {
        if (item == 0)
        {
            name = input_field_name.text;
        }
        else if (item == 1)
        {
            mark = 5 - dropdown_mark.value;
        }
        else if (item == 2)
        {
            age = Int32.Parse(input_field_age.text);
        }
        else if (item == 3)
        {
            sex = TMP_Dropdown_sex.options[TMP_Dropdown_sex.value].text;
        }
        else if (item == 4)
        {
            check();
            canv.SetActive(false);
        }
        if (item < 4)
        {
            help_texts[item].SetActive(false);
            item += 1;
            help_texts[item].SetActive(true);
        }
    }
        public void check()
        {
            if (name == null | mark == 0 | age == 0 | sex == null)
            {
                item = 0;
                EnterText();
            }
            else
            {
                SaveDataToJson.age = age;
                SaveDataToJson.Gender = sex;
                SaveDataToJson.mark = mark;
                SaveDataToJson.name = name;
            }
        }
}

