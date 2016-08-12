#include "Stdafx.h"
#include "Keyboards.h"

void PressKey(UINT Key)
{
	INPUT Input;

	ZeroMemory(&Input, sizeof(Input));
	Input.type = INPUT_KEYBOARD; // keyboard
	Input.ki.dwFlags = KEYEVENTF_EXTENDEDKEY;
	//	  Input.ki.dwFlags = 0;
	Input.ki.wVk = (WORD)Key; // Virtual Key
	SendInput(1, &Input, sizeof(INPUT));
}

void ReleaseKey(UINT Key)
{
	INPUT Input;

	Input.type = INPUT_KEYBOARD;
	Input.ki.dwFlags = KEYEVENTF_KEYUP;
	Input.ki.wVk = (WORD)Key;

	Sleep(100);
	SendInput(1, &Input, sizeof(INPUT));
}

void PressAndReleaseKey(UINT Key)
{
	PressKey(Key);
	Sleep(100);
	ReleaseKey(Key);
}

