//---------------------------------------------------------------------------


#pragma hdrstop

#include "Unit2.h"

int HashTable :: HashFunction(int numer)
{
	if(!numer)
	{
		 return numer % size + 10;
	}
	else
	{
		 return numer % size;
	}
}

void HashTable :: CreateHash()
{
	elements = (Stack**)calloc(size, sizeof(Stack));
	for(int i = 0; i < size; i++)
	{
		elements[i] = (Stack*)calloc(1, sizeof(Stack));
		elements[i] = NULL;
	}
}

void HashTable :: Add(int n, int m)
{
	int i = HashFunction(n);
	if(!elements[i])
	{
		elements[i] = new Stack(n, m);
	}
	else
	{
		Stack *temp = elements[i];
		while(temp->next)
		{
			 temp = temp->next;
		}
		temp->next = new Stack(n, m);
	}
}

int HashTable :: DeleteHash(int numer)
{
	int i = HashFunction(numer);
	int result = 0;
	Stack *del, *temp = NULL;
	for(del = elements[i]; del; del = del->next)
	{
		if(del->key == numer)
		{
			if(!temp)
			{
				elements[i] = del->next;
			}
			else
			{
				temp->next = del->next;
			}
			del = NULL;
			result = 1;
			break;
		}
		temp = del;
	}
	return result;
}

void HashTable :: ShowHash(TMemo *Memo)
{
	Memo->Lines->Clear();
	Memo->Lines->Add("Хэш-таблица:");
	Memo->Lines->Add("\n");
	AnsiString str="";
	for(int  i = 0; i < size; i++)
	{
		if(elements[i])
		{
			str = "(" + IntToStr(elements[i]->key) + ", " + IntToStr(elements[i]->number) + ")";
			if(!elements[i]->next)
			{
				Memo->Lines->Add(IntToStr(i+1) + ": " + str);
			}
			else
			{
				AnsiString s = "";
				Stack *temp = elements[i]->next;
				while(temp)
				{
					s += "   (" + IntToStr(temp->key) +", " + IntToStr(temp->number) + ")";
					temp = temp->next;
				}
				str += s;
				Memo->Lines->Add(IntToStr(i+1) + ": " + str);
			}
		}
	}
	Memo->Lines->Add("\n");
}

Stack* HashTable :: SearchElement(int numer)
{
	int i = HashFunction(numer);
	Stack* result=NULL;

	if(!elements[i])
	{
		ShowMessage("Нет элемента с таким ключом");
		return NULL;
	}
	if(elements[i]->key == numer)
	{
		result=elements[i];
	}
	else
	{
		int marker = 0;
		Stack *temp = NULL;
		for(temp = elements[i]->next; temp; temp = temp->next)
		{
			if(temp->key == numer)
			{
				result=temp;
				break;
			}
		}
	}

	return result;
}
Stack *HashTable :: FindStackNumber(int &stacknum)
{
	int min = 100000;
	stacknum = 0;
	Stack *result = NULL;
	for(int  i = 0; i < size; i++)
	{
		if(elements[i])
		{
			if(!elements[i]->next)
			{
				if(elements[i]->key < min)
				{
					min = elements[i]->key;
					stacknum = i + 1;
					result = elements[i];
				}
			}
			else
			{
				Stack *temp = elements[i]->next;
				while(temp)
				{
					if(temp->key < min)
					{
						min = temp->key;
						stacknum = i + 1;
						result = temp;
					}
					temp = temp->next;
				}
			}
		}
	}
	return result;
}
//---------------------------------------------------------------------------

#pragma package(smart_init)
