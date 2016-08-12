#pragma once


#include <windows.h>
#include <algorithm>

#define LEFT 0x25
#define RIGHT 0x27

#define JUMP VK_UP
#define DOWN VK_DOWN

#define LIGHT_KICK 0x4F
#define MEDIUM_KICK 0x50
#define HEAVY_KICK 0xDB
#define LIGHT_PUNCH 0x39
#define MEDIUM_PUNCH 0x30
#define HEAVY_PUNCH 0xBD

#define FOCUS_ATTACK 0xBA

void PressKey(UINT Key);
void ReleaseKey(UINT Key);
void PressAndReleaseKey(UINT Key);

                             

