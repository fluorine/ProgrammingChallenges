// RomanNumerals.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

string toRomanNumeral(int);

// Constants
const int MAX = 3500;
const int MIN = 1;

// Roman symbols and equivalent decimal values
const int    symbolsCount = 13;

const int    decimalNumerals[] = { 1000,
                                   900, 500, 400,  100, 
                                   90,   50,  40,   10, 
                                   9,    5,   4,    1};

const string romanNumerals[]   = { "M",
                                   "CM", "D", "CD", "C",
                                   "XC", "L", "XL", "X", 
                                   "IX", "V", "IV", "I"};

int _tmain(int argc, _TCHAR* argv[])
{
	int input;
	string romanNumber;

	while(true) {
		// Get decimal number to convert
		cout << "Insert a decimal number greater than " << MIN 
			 << " and under " << MAX << "." << endl;

		cout << "> ";
		cin >> input;

		if(input > 0 && input < 3500) {
			cout << endl
				 << "  Roman number: "
			     << toRomanNumeral(input);
		} else {
			cout << endl << "  Invalid number for conversion.";
		}

		cout << endl << endl;
	}

	return 0;
}

// Using recursion to convert a decimal integer
// to its equivalent roman numeral
string toRomanNumeral(int dec) {
	if(dec <= 0) {
		return "";
	} else {
		for(int i = 0; i < symbolsCount; i++) {
			if(dec - decimalNumerals[i] >= 0) {
				return romanNumerals[i] + toRomanNumeral(dec - decimalNumerals[i]);
			}
		}

		return "";
	}
}