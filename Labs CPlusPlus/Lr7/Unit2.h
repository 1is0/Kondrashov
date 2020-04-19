//---------------------------------------------------------------------------

#ifndef Unit2H
#define Unit2H
#include <vcl.h>
#include <string>
#include "Unit1.h"

class Stack
{
public:
	Stack* next;
	int key;
	int number;

	Stack(int k,int n)
	{
		next = NULL;
		key = k;
		number = n;
	}
};

class HashTable
{
	static const int size = 5;

public:
	Stack **elements;
	int HashFunction(int);
	void CreateHash();
	void Add(int,int);
	int DeleteHash(int);
	void ShowHash(TMemo*);
	Stack* SearchElement(int);
	Stack* FindStackNumber(int &);
};

//---------------------------------------------------------------------------
#endif
