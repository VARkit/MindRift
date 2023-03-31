using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject laserPrefab; // ������ ������
    public float laserSpeed = 0.001f; // �������� ������

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���� ������ ����� ������ ����
        {
            ShootLaser(); // �������� ������� ��������
        }
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
