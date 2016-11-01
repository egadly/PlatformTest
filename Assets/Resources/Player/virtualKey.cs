using UnityEngine;
using System.Collections;

public class virtualKey : MonoBehaviour {

	public bool[] cur_vKeys;
	public bool[] prev_vKeys;

	public int jumpButton;
	public static bool jumpDown;
	public static bool jumpPos;
	public static bool jumpNeg;
	public int rightButton;
	public static bool rightDown;
	public static bool rightPos;
	public static bool rightNeg;
	public int leftButton;
	public static bool leftDown;
	public static bool leftPos;
	public static bool leftNeg;
	public bool polling = false;
	public int pollBuffer = 0;
	public int pollIndex = 0;

/////////////Added code/////////////////////////
    public int downButton;
    public static bool downDown;
    public static bool downPos;
    public static bool downNeg;

    public int enterButton;
    public static bool enterDown;
    public static bool enterPos;
    public static bool enterNeg;
///////////////////////////////////////////////

	// Use this for initialization
	void Start () {
		cur_vKeys = new bool[509];
		prev_vKeys = new bool[509];
		jumpButton = 106;
		rightButton = 100;
		leftButton = 97;

        //"S" key, used on the door to complete the level///////
        downButton = 115;

        //Enter key, used to skip clicking continue button with mouse///
        enterButton = 13;
		
	}
	
	// Update is called once per frame
	void Update () {
		bool[] temp_vKeys = prev_vKeys;
		prev_vKeys = cur_vKeys;
		cur_vKeys = temp_vKeys;
		for (int i = 0; i < 509; i++) {
			cur_vKeys [i] = Input.GetKey ((KeyCode)i);
		}

		if (polling) {
			if (pollBuffer <= 0) {
				if (Input.anyKeyDown) {
					if (pollIndex == 2) polling = false;
					for (int i = 0; i < 509; i++) {
						if (cur_vKeys [i]) {
							if (pollIndex == 0)
								jumpButton = i;
							if (pollIndex == 1)
								rightButton = i;
							if (pollIndex == 2)
								leftButton = i;
            ///////////////////added code///////////////////////////////////
                            if (pollIndex == 3)
                                downButton = i;
                            if (pollIndex == 4)
                                enterButton = i;
							break;
						}
					}
					pollIndex++;
				}
			} else
				pollBuffer--;
		} else {		
			
			if (cur_vKeys [jumpButton])
				jumpDown = true;
			else
				jumpDown = false;

			if (prev_vKeys [jumpButton] != cur_vKeys [jumpButton]) {
				jumpNeg = prev_vKeys [jumpButton];
				jumpPos = cur_vKeys [jumpButton];
			} else {
				jumpNeg = jumpPos = false;
			}

			rightDown = cur_vKeys [rightButton];
			if (prev_vKeys [rightButton] != cur_vKeys [rightButton]) {
				rightNeg = prev_vKeys [rightButton];
				rightPos = cur_vKeys [rightButton];
			} else {
				rightNeg = rightPos = false;
			}

			leftDown = cur_vKeys [leftButton];
			if (prev_vKeys [leftButton] != cur_vKeys [leftButton]) {
				leftNeg = prev_vKeys [leftButton];
				leftPos = cur_vKeys [leftButton];
			} else {
				leftNeg = leftPos = false;
			}

///////////////////////////Added code//////////////////////////////////////////////
            downDown = cur_vKeys[downButton];
            if (prev_vKeys[downButton] != cur_vKeys[downButton])
            {
                downNeg = prev_vKeys[downButton];
                downPos = cur_vKeys[downButton];
            }
            else
            {
                downNeg = downPos = false;
            }

            enterDown = cur_vKeys[enterButton];
            if (prev_vKeys[enterButton] != cur_vKeys[enterButton])
            {
                enterNeg = prev_vKeys[enterButton];
                enterPos = cur_vKeys[enterButton];
            }
            else
            {
                downNeg = downPos = false;
            }
        }

		if (Input.GetKeyDown (KeyCode.Q)) {
			polling = true;
			pollBuffer = 60;
			pollIndex = 0;
		}


	}
}
