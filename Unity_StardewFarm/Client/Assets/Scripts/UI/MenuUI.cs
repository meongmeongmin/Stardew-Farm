using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject player;

    void Start()
    {
        GameLoad();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) // Ű���� Esc�� ������ �޴�â�� ����
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
            
    }

    public void GameSave()
    {
        // PlayerPrefs : ������ ������ ���� ����� �����ϴ� Ŭ����
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();

        // �κ��丮 ����

        menuSet.SetActive(false);
    }

    public void GameLoad() // ���� �ҷ�����
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // ������ �� ���� ���̺� �� ���� �ִ��� ���, ���� ���� ������ ���� �����Ͱ� �����Ƿ� ����ó��
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        // �κ��丮 ����

        player.transform.position = new Vector3(x, y, 0);
    }

    public void GameExit()
    {
        Application.Quit(); // �翬�� ������ �������� ���ᰡ �ȵ˴ϴ�
    }
}
