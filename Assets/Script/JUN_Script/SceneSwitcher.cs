using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;



/// <summary>
/// To use the demo just add all three scenes to your build settings making sure the BoostrapScene is scene 0
/// </summary>

/// <summary>
///	このスクリプト1つでシーン遷移兼その際の暗転アニメーション兼タイトル画面からシーン遷移時の音の再生を行っています。
///	逆にこのスクリプトの責任が重いので取り扱い注意（）
/// </summary>

public class SceneSwitcher : MonoBehaviour
{
	[SerializeField] int RetryCheck;

	public AudioSource audioSource;
	public AudioClip audioClip;
	public static SceneSwitcher instance;

	private static  int currentIndex; // 現在のシーンが何番目なのか格納



	/// <summary>
	/// staticにするところとして合ってるか分からんやつ
	/// これらをstatic化するとインスペクター上から入れられずNullになってしまう。
	/// </summary>
	/// <returns></returns>

	public  static JUN_SEManagerScript seManager; //SEManagerを画面遷移時も保持
	public  static JUN_BGMManagerScript bgmManager;

	public Texture2D maskTexture;

	//private bool _isUiVisible = true;


	//シーン遷移時にボタンが壊れないように追加部分

	void Start()
	{
		currentIndex = SceneManager.GetActiveScene().buildIndex; // 現在のシーンの順番を取得


	}

    private void Awake()
    {
		instance = this;
    }


	public   void JUN_SceneTransion()
	{
		//YMN_UIManager.startUp = false;

		if (currentIndex <= 1) //現在のシーンが最後のシーンじゃない場合
		{

			JUN_BGMManagerScript.instance.JUN_TransitionBGM(currentIndex);
            
			if (currentIndex ==  0)
            {
				JUN_SEManagerScript.instance.JUN_SettingPlaySE(0);//「スタート」「タイトルへ」「リトライ」音
			}
            else
            {
				// JUN_SEManagerScript.instance.JUN_SettingPlaySE(5);// タイムアップ音
			}
			
			//次のシーンへ遷移
			JUN_OnMaskToScene(currentIndex);
			Debug.Log("←");

		}

		else if(currentIndex ==2 ) //現在が最後のシーンの場合かつリトライするとき
		{
			JUN_SEManagerScript.instance.JUN_SettingPlaySE(0);//「スタート」「タイトルへ」「リトライ」音
			JUN_OnMaskToScene(currentIndex);
		}
        

		// sceneCanvas = YMN_UIManager.waitUI(sceneCanvas);
	}
	
	

	

	/// <summary>
	/// 元々入っていたスクリプトをコメントアウトしたもの。中身は特にはいじっていない。
	/// この部分は各種類のシーン遷移についてのスクリプト
	/// </summary>
	/// <returns>The for level to load.</returns>
	#region

	/*
	void Awake()
	{

		//DontDestroyOnLoad( gameObject );
		//SceneManager.LoadScene( 0 );
		
	}

    
	void OnGUI()
	{
		
		// hide the UI during transitions
		if( !_isUiVisible )
			return;
		/*
		if( Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android )
		{
			// bigger buttons for higher res mobile devices
			if( Screen.width >= 1500 || Screen.height >= 1500 )
				GUI.skin.button.fixedHeight = 60;
		}

		if( GUILayout.Button( "Fade to Scene" ) )
		{
			var fader = new FadeTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				fadedDelay = 0.2f,
				fadeToColor = Color.black
			};
			TransitionKit.instance.transitionWithDelegate( fader );
		}


		if( GUILayout.Button( "Vertical Slices to Scene" ) )
		{
			var slices = new VerticalSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 3, 20 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
		}


		if( GUILayout.Button( "Triangle Slices to Scene" ) )
		{
			var slices = new TriangleSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 2, 10 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
		}


		if( GUILayout.Button( "Pixelate to Scene with Random Scale Effect" ) )
		{
			var enumValues = System.Enum.GetValues( typeof( PixelateTransition.PixelateFinalScaleEffect ) );
			var randomScaleEffect = (PixelateTransition.PixelateFinalScaleEffect)enumValues.GetValue( Random.Range( 0, enumValues.Length ) );

			var pixelater = new PixelateTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				finalScaleEffect = randomScaleEffect,
				duration = 1.0f
			};
			TransitionKit.instance.transitionWithDelegate( pixelater );
		}


		if( GUILayout.Button( "Twirl via Component with No Scene Change" ) )
		{
			TransitionKit.instance.transitionWithDelegate( GetComponent<TwirlTransition>() );
		}


		if( GUILayout.Button( "Blur to Scene" ) )
		{
			var blur = new BlurTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 2.0f,
				blurMax = 0.01f
			};
			TransitionKit.instance.transitionWithDelegate( blur );
		}


		if( GUILayout.Button( "Wacky Blur with No Scene Change" ) )
		{
			var blur = new BlurTransition()
			{
				duration = 1.0f,
				blurMax = 1f
			};
			TransitionKit.instance.transitionWithDelegate( blur );
		}


		if( GUILayout.Button( "Big Squares to Scene" ) )
		{
			var squares = new SquaresTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 2.0f,
				squareSize = new Vector2( 5f, 4f ),
				smoothness = 0.0f
			};
			TransitionKit.instance.transitionWithDelegate( squares );
		}


		if( GUILayout.Button( "Little Squares to Scene" ) )
		{
			var squares = new SquaresTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 2.0f,
				squareSize = new Vector2( 64f, 45f ),
				squareColor = Color.yellow,
				smoothness = 0.1f
			};
			TransitionKit.instance.transitionWithDelegate( squares );
		}


		if( GUILayout.Button( "Ripples to Scene" ) )
		{
			var ripple = new RippleTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 1.0f,
				amplitude = 1500f,
				speed = 20f
			};
			TransitionKit.instance.transitionWithDelegate( ripple );
		}


		if( GUILayout.Button( "Fish Eye to Scene" ) )
		{
			var fishEye = new FishEyeTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 1.0f,
				size = 0.08f,
				zoom = 10.0f,
				colorSeparation = 3.0f
			};
			TransitionKit.instance.transitionWithDelegate( fishEye );
		}


		if( GUILayout.Button( "Fish Eye (alternate params) to Scene" ) )
		{
			var fishEye = new FishEyeTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 2.0f,
				size = 0.2f,
				zoom = 100.0f,
				colorSeparation = 0.1f
			};
			TransitionKit.instance.transitionWithDelegate( fishEye );
		}


		if( GUILayout.Button( "Doorway to Scene" ) )
		{
			var doorway = new DoorwayTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 1.0f,
				perspective = 1.5f,
				depth = 3f,
				runEffectInReverse = false
			};
			TransitionKit.instance.transitionWithDelegate( doorway );
		}


		if( GUILayout.Button( "Doorway (reversed) to Scene" ) )
		{
			var doorway = new DoorwayTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 1.0f,
				perspective = 1.1f,
				runEffectInReverse = true
			};
			TransitionKit.instance.transitionWithDelegate( doorway );
		}


		if( GUILayout.Button( "Wind to Scene" ) )
		{
			var wind = new WindTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 1.0f,
				size = 0.3f
			};
			TransitionKit.instance.transitionWithDelegate( wind );
		}


		if( GUILayout.Button( "Curved Wind to Scene" ) )
		{
			var wind = new WindTransition()
			{
				useCurvedWind = true,
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 1.0f,
				size = 0.3f,
				windVerticalSegments = 300f
			};
			TransitionKit.instance.transitionWithDelegate( wind );
		}
		
		
		if( GUILayout.Button( "Mask to Scene" ) )
		{
			var mask = new ImageMaskTransition()
			{
				maskTexture = maskTexture,
				backgroundColor = Color.yellow,
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1
			};
			TransitionKit.instance.transitionWithDelegate( mask );
		}
		
	}
	*/
	#endregion

	public   void JUN_OnMaskToScene(int SceneNumBer)
    {

		var mask = new ImageMaskTransition()
		{

			maskTexture = maskTexture,
			backgroundColor = new Color32(50, 65, 255, 255),
			nextScene = 0
		};


		if (currentIndex == 2)
        {

			mask.nextScene = RetryCheck;
		}
		else
        {
			mask.nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % 3;
		}
		//mask.nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % 3

		TransitionKit.instance.transitionWithDelegate(mask);
	}


	/**
	public   void JUN_OnMaskToScene(int currentIndex){

		var mask = new ImageMaskTransition(){
			maskTexture = maskTexture,
			backgroundColor = Color.yellow,
			nextScene =  0  // 仮置きを置く
		};

		mask.nextScene = (SceneManager.GetActiveScene().buildIndex + 1)%3

		TransitionKit.instance.transitionWithDelegate(mask);
		Debug.Log(currentIndex);
	}


	**/

	/// <summary>
	/// 元々入っていたスクリプトをコメントアウトしたもの。中身は特にはいじっていない。
	/// 多分GUILayout.Buttonを見せたり見せなかったりするものかなと……
	/// </summary>
	/// <returns></returns>
	#region
	/*
	void OnEnable()
	{
		TransitionKit.onScreenObscured += onScreenObscured;
		TransitionKit.onTransitionComplete += onTransitionComplete;
	}


	void OnDisable()
	{
		// as good citizens we ALWAYS remove event handlers that we added
		TransitionKit.onScreenObscured -= onScreenObscured;
		TransitionKit.onTransitionComplete -= onTransitionComplete;
	}

	
	void onScreenObscured()
	{
		_isUiVisible = false;
	}


	void onTransitionComplete()
	{
		_isUiVisible = true;
	}
	*/
	#endregion

	//ここから追記します。スタートボタンからタイムラインを再生します。タイムラインオブジェクトにスクリプトがあるので、それを呼び出しています。
	
	
	
	
	public void ClickSrartButton() 
	{

		TimeLineManager.instance.PlayTimeline();



	}



}
