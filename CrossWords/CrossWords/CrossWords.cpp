// CrossWords.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

void writeX(string);

int _tmain(int argc, _TCHAR* argv[])
{
	string input;
	while(true) {
		// Print instructions and get word
		cout << "Write a word with an odd number of characters, between 3 and 13, inclusive." << endl;
		cin >> input;

		// Validate word
		if(input.length() < 3 || input.length() > 13 || input.length() % 2 == 0) {
			cout << "  Invalid word." << endl << endl;
		} else {
			break;
		}
	}

	// Write crossed words
	writeX(input);

	system("Pause");
	return 0;
}

void writeX(string word) {
	cout << endl;

	int left = 0;
	int right = word.length() - 1;

	// Write line
	for(int c = 0; c < word.length(); c++) {
		// Write starting spaces
		cout << "   ";

		// Write column
		for(int column = 0; column < word.length(); column++) {
			if(column == left || column == right)
				cout << word[c];
			else
				cout << " ";
		}

		// Move pointers to letters
		left++;
		right--;
		cout << endl;
	}

	cout << endl;
}