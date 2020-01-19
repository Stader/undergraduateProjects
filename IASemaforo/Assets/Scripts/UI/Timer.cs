using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public GameObject cameraEspecial;
	public GameObject canvas1, canvas2;
	public Text timerText;
	private float _secondsCount;
	private int _minuteCount;
	private int _hourCount;

	private void Update(){
		UpdateTimerUi();
		if (cameraEspecial.gameObject.activeSelf)
		{
			canvas1.SetActive(false);
			canvas2.SetActive(false);
		}
		else
		{
			canvas1.SetActive(true);
			canvas2.SetActive(true);
		}
	}
	public void UpdateTimerUi(){
		_secondsCount += Time.deltaTime;
		if (_secondsCount < 10)
		{
			if (_minuteCount < 10)
			{
				timerText.text = "0"+ _hourCount +":0"+ _minuteCount +":0"+(int)_secondsCount + "  ";
			}
			else
			{
				timerText.text = "0"+ _hourCount +":"+ _minuteCount +":0"+(int)_secondsCount + "  ";
			}
		}
		else
		{
			if(_minuteCount < 10)
				timerText.text = "0"+ _hourCount +":0"+ _minuteCount +":"+(int)_secondsCount + "  ";
			else
			{
				timerText.text = "0"+ _hourCount +":"+ _minuteCount +":"+(int)_secondsCount + "  ";
			}
		}
		if(_secondsCount >= 60){
			_minuteCount++;
			_secondsCount = 0;
		}else if(_minuteCount >= 60){
			_hourCount++;
			_minuteCount = 0;
		}    
	}
}
