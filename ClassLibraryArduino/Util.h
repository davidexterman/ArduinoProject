#pragma once

#include <stdio.h>
#include <string>
#include "SerialClass.h"

#define MOVES_ARR_SIZE 256
using std::string;

enum Moves
{
	None,
	OnMove,
	LightPunch,
	MediumPunch,
	HeavyPunch,
	LightKick,
	MediumKick,
	HeavyKick,
	Jump,
	GoLeft,
	StopLeft,
	GoRight,
	StopRight,
	Down,
	StopDown,
	Stop
};

static const char * EnumMovechar[] = {
	"0",
	"1",
	"2",
	"3",
	"4",
	"5",
	"6",
	"7",
	"8",
	"9",
	"q",
	"r",
	"s",
	"d",
	"t",
	"y"
};

static const int EnumMovecharSize = 16;

static const char * EnumMoveStrings[] = {
	"None",
	"OnMove",
	"LightPunch",
	"MediumPunch",
	"HeavyPunch",
	"LightKick",
	"MediumKick",
	"HeavyKick",
	"Jump",
	"GoLeft",
	"StopLeft",
	"GoRight",
	"StopRight",
	"Down",
	"StopDown",
	"Stop"
};

void initSerialPorts(IN int numPorts, IN char** portsArray, OUT Serial* SParray[]);
void unInitSerialPorts(IN int numPorts, IN Serial* SParray[]);
bool areSerialPortsConnected(IN int numPorts, IN Serial* SParray[]);
int readDataFromSPs(IN int numPorts, IN int moveArrSize, IN Serial* SParray[], IN char incomingDataSPs[][MOVES_ARR_SIZE], OUT int readResults[]);

const char * getMoveString(Moves move);
bool action(string currMove);
bool takeActions(string moves);
