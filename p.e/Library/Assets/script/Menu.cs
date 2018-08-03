using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public movement moveScript;
	public GameObject canvas;
	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public Dropdown resolutionDropdown;

	public Slider[] volumeSliders;
	public Resolution[] resolutions;
//	public Toggle[] resolutionToggles;
	public int[] screenWidths;
	int activeScreenResIndex;
	public GameObject button1;
	public GameObject button2;

	void Start(){

//		
		canvas = GameObject.Find ("Pause"); 
		mainMenuHolder = GameObject.Find ("PAUSE MENU");
		optionsMenuHolder = GameObject.Find ("OPTIONS MENU");
		resolutionDropdown = GameObject.Find ("RESOLUTION").GetComponent<Dropdown>();
		volumeSliders[0] = GameObject.Find ("MASTER VOLUME").GetComponent<Slider> ();
		volumeSliders[1] = GameObject.Find ("MUSIC VOLUME").GetComponent<Slider> ();
		volumeSliders[2] = GameObject.Find ("SFX VOLUME").GetComponent<Slider> ();
		optionsMenuHolder.SetActive(false);
		moveScript = GameObject.Find ("Character").transform.GetComponent<movement>();

		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions ();
		List<string> options = new List<string> ();

		//1280x720
		//1920x1080

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			if (resolutions [i].width < 1280 || resolutions [i].height < 720) {
				
			} else {
				string option = resolutions [i].width + " x " + resolutions [i].height;
				options.Add (option);
				if (resolutions [i].width == Screen.currentResolution.width &&
				   resolutions [i].height == Screen.currentResolution.height) {
					currentResolutionIndex = i;
				}
			}
		}
		resolutionDropdown.AddOptions (options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue ();

	//	activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
	//	bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1)?true:false;

		volumeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volumeSliders [1].value = AudioManager.instance.musicVolumePercent;
		volumeSliders [2].value = AudioManager.instance.sfxVolumePercent;

	//	SetFullscreen (isFullscreen);
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {			
			Pause ();
		}
	}

	public void Play(){
		SceneManager.LoadScene ("1");
	}

	public void Pause(){
		button1.SetActive (true);
		button2.SetActive (true);
		moveScript.CanControl = false;
		Time.timeScale = 0;
		mainMenuHolder.transform.position = canvas.transform.position;

	}

	public void Resume(){
		button1.SetActive (false);
		button2.SetActive (false);
		moveScript.CanControl = true;
		Time.timeScale = 1;
		mainMenuHolder.transform.position = new Vector3(0,0,9999);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void OptionsMenu(){
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}
	public void MainMenu(){
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
	}
/*	public void SetScreenResolution(int i){
		if (resolutionToggles[i].isOn) {
			activeScreenResIndex = i;
			float aspectRatio = 16 / 9f;
			Screen.SetResolution(screenWidths[i],(int)(screenWidths[i]/aspectRatio),false);
			PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
			PlayerPrefs.Save ();
		}		
	}
*/
	public void SetFullscreen(bool isFullscreen){
		Screen.fullScreen = isFullscreen;
	}
	public void SetMasterVolume(float value){
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Master);		
	}
	public void SetMusicVolume(float value){
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Music);	
	}
	public void SetSfxVolume(float value){
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Sfx);	
	}
	/*
	public void SetResolution(int resolutionIndex){
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}
*/
}
