#include "Stdafx.h"
#include "Util.h"
#include "ClassLibraryArduino.h"
#include "keyboards.h"
#include <sstream>

#define END_ARR '\0'
#define SEPERATOR ':'

using std::stringstream;
using std::string;

bool rightPressed = false;
bool leftPressed = false;

void initSerialPorts(IN int numPorts, IN char** portsArray, OUT Serial* SParray[]) {
	for (int i = 0; i < numPorts; ++i)
	{
		SParray[i] = new Serial(portsArray[i], CBR_115200);
	}
}

void unInitSerialPorts(IN int numPorts, IN Serial* SParray[]) {
	for (int i = 0; i < numPorts; ++i)
	{
		delete SParray[i];
	}
}

bool areSerialPortsConnected(IN int numPorts, IN Serial* SParray[]) {
	for (int i = 0; i < numPorts; ++i)
	{
		if (!SParray[i]->IsConnected())
			return false;
	}
	return true;
}

int readDataFromSPs(IN int numPorts, IN int dataLength, IN Serial* SParray[], IN char incomingDataSPs[][MOVES_ARR_SIZE], OUT int readResults[]) {
	int sumReadResults = 0;
	for (int i = 0; i < numPorts; ++i)
	{
		readResults[i] = SParray[i]->ReadData(incomingDataSPs[i], dataLength);
		sumReadResults += readResults[i];
	}
	return sumReadResults;
}

const char * getMoveString(Moves move) {
	return EnumMoveStrings[move];
}

bool action(string currMove)
{
	int move = std::distance(EnumMovechar, std::find(EnumMovechar, EnumMovechar + EnumMovecharSize, currMove));
	switch (move)
	{
	case LightPunch:
		PressAndReleaseKey(LIGHT_PUNCH);
		break;
	case MediumPunch:
		PressAndReleaseKey(MEDIUM_PUNCH);
		break;
	case HeavyPunch:
		PressAndReleaseKey(HEAVY_PUNCH);
		break;
	case LightKick:
		PressAndReleaseKey(LIGHT_KICK);
		break;
	case MediumKick:
		PressAndReleaseKey(MEDIUM_KICK);
		break;
	case HeavyKick:
		PressAndReleaseKey(HEAVY_KICK);
		break;
	case Jump:
		PressAndReleaseKey(JUMP);
		break;
	case GoLeft:
		if (rightPressed) {
			ReleaseKey(RIGHT);
			rightPressed = false;
			PressAndReleaseKey(JUMP);
			Sleep(10);
			PressKey(LEFT);
			leftPressed = true;
			PressKey(RIGHT);
			rightPressed = true;
		}
		else {
			PressKey(LEFT);
			leftPressed = true;
		}
		break;
	case GoRight:
		if (leftPressed) {
			ReleaseKey(LEFT);
			leftPressed = false;
			PressAndReleaseKey(JUMP);
			Sleep(10);
			PressKey(LEFT);
			leftPressed = true;
			PressKey(RIGHT);
			rightPressed = true;
		}
		else {
			PressKey(RIGHT);
			rightPressed = true;
		}
		break;
	case Down:
		PressKey(DOWN);
		break;
	case StopLeft:
		ReleaseKey(LEFT);
		leftPressed = false;
		break;
	case StopRight:
		ReleaseKey(RIGHT);
		rightPressed = false;
		break;
	case StopDown:
		ReleaseKey(DOWN);
		break;
	case Stop:
		ReleaseKey(RIGHT);
		return false;
	default:
		return true;
		break;
	}
	printf("%s\n", getMoveString((Moves)move));
	return true;
}


bool takeActions(string moves)
{
	if (moves == "")
		return true;
	stringstream ss(moves);
	string currMove = "0";
	while (std::getline(ss, currMove, SEPERATOR))
	{
		if (currMove == "")
			continue;
		//	int temp = stoi(currMove);
		if (!action(currMove))
		{
			return false;
		}

	}
	return true;
}

void ClassLibraryArduino::DesktopApp::takeAction(int intMove)
{
	char currMove = char(intMove);
	string sCurrMove;
	sCurrMove = currMove;
	int move = std::distance(EnumMovechar, std::find(EnumMovechar, EnumMovechar + EnumMovecharSize, sCurrMove));
	switch (move)
	{
	case LightPunch:
		PressAndReleaseKey(LIGHT_PUNCH);
		break;
	case MediumPunch:
		PressAndReleaseKey(MEDIUM_PUNCH);
		break;
	case HeavyPunch:
		PressAndReleaseKey(HEAVY_PUNCH);
		break;
	case LightKick:
		PressAndReleaseKey(LIGHT_KICK);
		break;
	case MediumKick:
		PressAndReleaseKey(MEDIUM_KICK);
		break;
	case HeavyKick:
		PressAndReleaseKey(HEAVY_KICK);
		break;
	case Jump:
		PressAndReleaseKey(JUMP);
		break;
	case GoLeft:
		if (rightPressed) {
			ReleaseKey(RIGHT);
			rightPressed = false;
			PressAndReleaseKey(JUMP);
			Sleep(10);
			PressKey(LEFT);
			leftPressed = true;
			PressKey(RIGHT);
			rightPressed = true;
		}
		else {
			PressKey(LEFT);
			leftPressed = true;
		}
		break;
	case GoRight:
		if (leftPressed) {
			ReleaseKey(LEFT);
			leftPressed = false;
			PressAndReleaseKey(JUMP);
			Sleep(10);
			PressKey(LEFT);
			leftPressed = true;
			PressKey(RIGHT);
			rightPressed = true;
		}
		else {
			PressKey(RIGHT);
			rightPressed = true;
		}
		break;
	case Down:
		PressKey(DOWN);
		break;
	case StopLeft:
		ReleaseKey(LEFT);
		leftPressed = false;
		break;
	case StopRight:
		ReleaseKey(RIGHT);
		rightPressed = false;
		break;
	case StopDown:
		ReleaseKey(DOWN);
		break;
	case Stop:
		ReleaseKey(RIGHT);
	default:
		break;
	}
	printf("%s\n", getMoveString((Moves)move));
}