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
    static Vector3 startingPosition;
    static Quaternion startingRotation;

    static Vector3 savedPosition;
    static Quaternion savedRotation;
    static Vector3 clearPosition;

    public static bool isStarted = false; //세상 : 시작했는지 확인하는 값
    public static bool isCleared = false; // 세상 : 끝났는지 확인하는 값
    public static bool isSaved = false; //세상 : 중간 저장했는지 확인하는 값

    static int stageLevel = 0;

    public const int clearStageLevel = 4; // 세상: 맨 끝 스테이지
    const string startPointTag = "StartPoint";
    const string clearPointTag = "ClearPoint";
    const string savedPointTag = "SavePoint";
    const string mainCameraTag = "MainCamera";
    private void Awake()
    {
        startingPosition = GameObject.FindGameObjectWithTag(startPointTag).transform.position;
        startingRotation = GameObject.FindGameObjectWithTag(startPointTag).transform.rotation;
        clearPosition = GameObject.FindGameObjectWithTag(clearPointTag).transform.position;
        savedPosition = GameObject.FindGameObjectWithTag(savedPointTag).transform.position;
        savedRotation = GameObject.FindGameObjectWithTag(savedPointTag).transform.rotation;

        Time.timeScale = 0f;
        if (isStarted)
        {
            //세상 : 처음 시작할 시에 움직이지 않는다.
            StartGame();
            Debug.Log("스타트 게임");

        }
        else
        {
            Debug.Log("응 아니야");

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

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("2단계로 워프"))
            {
                //
                isStarted = true;
                Time.timeScale = 1f;
                stageLevel = 1;
                isSaved = false; //담 스테이지로 가기 전에 세이브 하기
                SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);

            }
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("3단계로 워프"))
            {
                isStarted = true;
                Time.timeScale = 1f;
                stageLevel = 2;
                isSaved = false; //담 스테이지로 가기 전에 세이브 하기
                SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
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
                isSaved = false;
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

        GameObject standingCamera = GameObject.FindGameObjectWithTag(mainCameraTag);
        if (standingCamera != null) {
            standingCamera.SetActive(false);
        }

        if (!isSaved) {//세이브 했을 경우 세이브 포인트에서 시작
            Instantiate(player, new Vector3(startingPosition.x, startingPosition.y + 2f, startingPosition.z), startingRotation);
        }else{
            Instantiate(player, new Vector3(savedPosition.x, savedPosition.y + 2f, savedPosition.z), savedRotation);

        }

    }
    public static void SaveStage()
    {
        isSaved = true;
    }
    public static void ClearStage()
    {
        //
        Time.timeScale = 0f;
        stageLevel++;
        isSaved = false; //담 스테이지로 가기 전에 세이브 하기

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
  
	
	// Update is called once per frame
	void Update () {
		
	}
}
