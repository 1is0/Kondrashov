//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "HashTableAction.h"
#include "HashTableCreate.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
HashTable hash;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
	hash.CreateHash();
	srand(time(0));
	Memo1->Lines->Clear();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button3Click(TObject *Sender)
{
		int key = rand() % 100;
		int number = rand() % 100;
		hash.Add(key, number);
		hash.ShowHash(Memo1);
}


//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
	try
	{
		int key = StrToInt(Edit1->Text);
		if(key < 0)
		{
			ShowMessage("Введите корректный ключ");
		}
		else
		{
			int result = hash.DeleteHash(key);
			if(!result)
			{
				ShowMessage("Нет элемента с таким ключом");
			}
			hash.ShowHash(Memo1);
		}
	}
	catch(...)
	{
		ShowMessage("Введите корректный ключ");
	}
}


//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
	Memo1->Clear();

	try
	{
		int key = StrToInt(Edit1->Text);
		if(key < 0)
		{
			ShowMessage("Введите корректный ключ");
		}
		else
		{
			Stack* res=hash.SearchElement(key);
			if(res!=NULL)
			{
				Memo1->Lines->Add("Элемент найден");
				Memo1->Lines->Add("Ключ: " + IntToStr(res->key) + "   Значение: " + IntToStr(res->number));
				Memo1->Lines->Add("\n");
			}
			else
				ShowMessage("Нет элемента с таким ключом");
		}
	}
	catch(...)
	{
		ShowMessage("Введите корректный ключ");
	}
}
//---------------------------------------------------------------------------


void __fastcall TForm1::Button4Click(TObject *Sender)
{
	hash.ShowHash(Memo1);
	Memo1->Lines->Add("\n");
	int num = 0;
	Stack* res = hash.FindStackNumber(num);
	if(res!=NULL)
	{
	Memo1->Lines->Add("Номер стека, с минимальным ключом: " + IntToStr(num));
	AnsiString str = "Минимальный элемент: ";
	str=str + "(" + IntToStr(res->key) + ", " + IntToStr(res->number) + ")";
	Memo1->Lines->Add(str);
	Memo1->Lines->Add("\n");
	}
	else
	{
		ShowMessage("Ни один элемент не найден");
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button5Click(TObject *Sender)
{
	hash.ShowHash(Memo1);
}
//---------------------------------------------------------------------------

