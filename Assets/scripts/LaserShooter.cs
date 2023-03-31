using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject laserPrefab; // ������ ������
    public float laserSpeed = 0.001f; // �������� ������
    bool wasPressed;
    void Update()
    {
        if (wasPressed) // ���� ������ ����� ������ ����
        {
            ShootLaser(); // �������� ������� ��������
        }
        wasPressed = UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Trigger);
    }

    void ShootLaser()
    {
        // ������� ��������� ������ �� �������a
        GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);

        // ������ �������� ������
        Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
        laserRigidbody.velocity = transform.up * laserSpeed;
    }
}
