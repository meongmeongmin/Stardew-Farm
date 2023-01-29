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
        if (Input.GetButtonDown("Cancel")) // 키보드 Esc를 누르면 메뉴창이 열림
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
            
    }

    public void GameSave()
    {
        // PlayerPrefs : 간단한 데이터 저장 기능을 지원하는 클래스
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();

        // 인벤토리 상태

        menuSet.SetActive(false);
    }

    public void GameLoad() // 게임 불러오기
    {
        if (!PlayerPrefs.HasKey("PlayerX")) // 게임을 한 번도 세이브 한 적이 있는지 물어봄, 최초 게임 실행할 때는 데이터가 없으므로 예외처리
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        // 인벤토리 상태

        player.transform.position = new Vector3(x, y, 0);
    }

    public void GameExit()
    {
        Application.Quit(); // 당연히 에디터 내에서는 종료가 안됩니다
    }
}
