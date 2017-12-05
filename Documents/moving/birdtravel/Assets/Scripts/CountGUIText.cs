using UnityEngine;
using UnityEngine.UI; // Unity 4.6버전 부턴 이걸 써줘야 uGui에 접근이 가능하다.
using System.Collections;

public class CountGUIText : MonoBehaviour {
	public int count = 0; // 부딪힌 횟수
	Text CountText;

	void Start(){
		CountText = GetComponent<Text>();
		// 컴퍼넌트 멤버중 Text라는 멤버에 접근
	}

	void Update(){
		CountText.text = "현재 생명 : " + play.life;
		// GUI Text를 내부의 text를 스크립트상에서 설정가능하다.
		// "할말" + 변수 를 해주면 변수의 값이 같이 출력된다.
	}

	void CountUp(){
		count ++;
	}
}