using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    public List<Sprite> images;
    public List<AudioClip> audios;// ������ ��������, ������� ����� ����������
    public Image imageDisplay;
    public AudioSource AudioSource;// ��������� Image �� �����, ������� ����� ���������� ��������
    public float timeBetweenImages = 2.0f; // ����� ����� ������ ��������
    public GameObject panel;
    private int currentImageIndex = 0; // ������ ������� ��������
    bool OneTime;
    public int spheretime;
    public int spheretime2;
    public SphereShooter bullet1;
    public SphereShooter bullet2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && currentImageIndex == 0)
        {
            Starting();
            imageDisplay.gameObject.SetActive(true);
        }
    }
    void Starting()
    {
        // ��������� ������ ��������
        imageDisplay.sprite = images[currentImageIndex];
        AudioSource.clip = audios[currentImageIndex];
        AudioSource.Play();
        // �������� ��������, ������� ����� ������ �������� � �������� ����������� �������
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        while (true)
        {
            // ���� �������� �����
            yield return new WaitForSeconds(timeBetweenImages);

            // ����������� ������ ������� ��������
            currentImageIndex++;

            // ���� �������� ����� ������, �������� �������
            if (currentImageIndex >= images.Count)
            {
                currentImageIndex = 0;
            }

            // ������������� ����� ��������
            imageDisplay.sprite = images[currentImageIndex];
            AudioSource.clip = audios[currentImageIndex];
            AudioSource.Play();
            if (currentImageIndex == images.Count - 1)
            {
                yield return new WaitForSeconds(timeBetweenImages);
                imageDisplay.enabled = false;
                panel.SetActive(true);
                break;
            }
            if(currentImageIndex == spheretime)
            {
                bullet1.StartAnim();
            }
            if(currentImageIndex == spheretime2)
            {
                bullet2.StartAnim();
            }
        }
    }
}
