using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *  작성자 : 세상
 *  게임 진행 GUI 총체 제작
 *  참고 http://gold_metal.blog.me/220888867221?Redirect=Log&from=postView
 */
public class GameManager : MonoBehaviour {
    public GameObject player;
    Vector3 startingPosition;
    Quaternion startingRotation;
    Vector3 clearPosition;
    bool isStarted = false; //세상 : 시작했는지 확인하는 값
    static bool isCleared = false; // 세상 : 끝났는지 확인하는 값

    static int stageLevel = 0;

    public const int clearStageLevel = 2; // 세상: 맨 끝 스테이지
    const string startPointTag = "StartPoint";
    const string clearPointTag = "ClearPoint";
    private void Awake()
    {
        if (stageLevel == 0) {
            Time.timeScale = 0f; //세상 : 처음 시작할 시에 움직이지 않는다.

        }else
        {
            isStarted = true;
            Time.timeScale = 1f;
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        GUILayout.Label("Stage " + (stageLevel + 1));
        GUILayout.Space(5);

        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


        if (!isStarted && stageLevel == 0) //시작하지 않았을 때 설정
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            GUILayout.Label("준비 되었으면 시작");
            if (GUILayout.Button("Start !"))
            {
                isStarted = true;
                StartGame();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

        }
        else if (isCleared  && stageLevel == clearStageLevel)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            GUILayout.Label("클리어를 축하드립니다. 다음 데모를 기대해 주세요 :)");
            if (GUILayout.Button("리플레이하기 ! "))
            {
                isCleared = false;
                stageLevel = 0;
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        

    }
    void StartGame()
    {
        Time.timeScale = 1f;
        GameObject standingCamera = GameObject.FindGameObjectWithTag("MainCamera");
        standingCamera.SetActive(false);
        startingPosition = new Vector3(startingPosition.x, startingPosition.y + 2f, startingPosition.z);
        Instantiate(player, startingPosition, startingRotation);
    }
    public static void ClearStage()
    {
        //
        Time.timeScale = 0f;
        stageLevel++;
        if (SavePointTrigger.Plag == true)
        {
            SavePointTrigger.Plag = false;
        }
        if (stageLevel == clearStageLevel) //클리어 성공
        {
            isCleared = true;
        }else
        {
            SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
        }
    }
    public static void Reset()
    {
        SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);

    }
    // Use this for initialization
    void Start () {
        startingPosition = GameObject.FindGameObjectWithTag(startPointTag).transform.position;
        startingRotation = GameObject.FindGameObjectWithTag(startPointTag).transform.rotation;
        clearPosition = GameObject.FindGameObjectWithTag(clearPointTag).transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
