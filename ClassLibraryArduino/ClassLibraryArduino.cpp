
#include "stdafx.h"
#include "ClassLibraryArduino.h"
#include <tchar.h>
#include "SerialClass.h"	// Library described above
#include "Util.h"

#define NUM_OF_PORTS 1

// application reads from the specified serial port and reports the collected data
int ClassLibraryArduino::DesktopApp::mainFunc()
{
	Serial* SParray[NUM_OF_PORTS];
	char* portsArray[NUM_OF_PORTS] = {  "\\\\.\\COM6"}; // , "\\\\.\\COM4" , "\\\\.\\COM11"
	printf("Welcome to the SWAG!\n\n");

	initSerialPorts(NUM_OF_PORTS, portsArray, SParray);

	if (areSerialPortsConnected(NUM_OF_PORTS, SParray))
		printf("We're connected \n");

	char incomingDataSPs[NUM_OF_PORTS][MOVES_ARR_SIZE] = { "" }; //  , "" , "" 
	string sIncomingDataSPs[NUM_OF_PORTS];
	int dataLength = 255;
	int readResults[NUM_OF_PORTS] = { 0 };

	//Sleep(10000);
	printf("after sleep \n");
	//if (SP->WriteData("l", 1) == false)
	//	printf("write error");
	//SP2->WriteData("l", 1);
	//printf("after SP2 \n");
	//
	int bytesReadTotal = 0;
	bool status = true;
	while (areSerialPortsConnected(NUM_OF_PORTS, SParray))
	{
		bytesReadTotal = readDataFromSPs(NUM_OF_PORTS, dataLength, SParray, incomingDataSPs, readResults);

		if (bytesReadTotal == 0) {
			continue;
		}
		
		for (int i = 0; i < NUM_OF_PORTS; ++i) {
			incomingDataSPs[i][(readResults[i])] = 0;
		}
		for (int i = 0; i < NUM_OF_PORTS; ++i) { 
			if (!takeActions(incomingDataSPs[i]))
			{
				status = false;
			}
		}
		if (!status)
			break;
	}

	printf("Lost connection with one of the devices");
	unInitSerialPorts(NUM_OF_PORTS, SParray);
	return 0;
}