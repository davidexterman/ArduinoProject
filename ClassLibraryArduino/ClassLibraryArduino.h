// ClassLibraryArduino.h

#pragma once

//using namespace System;
#include <string>
using std::string;

namespace ClassLibraryArduino {

	public ref class DesktopApp
	{
	public:
		void takeAction(int currMove);
		int mainFunc();
	};
}
