//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "QueueActions.h"
#include "QueueCreation.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
List lst;
Queue qu1;
Queue qu2;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button1Click(TObject *Sender)
{
	lst.DeleteQueue();
	ListBox1->Clear();
	srand(time(0));
	int quantity =StrToInt(Edit1->Text);
	int rand1;
	for (int i = 0; i < quantity; i++)
	{
		rand1=rand() % 200 - 100;
		lst.Add(rand1);
		ListBox1->Items->Add(IntToStr(i + 1) + ".  "+rand1);
	}
	Label7->Caption = lst.GetMax();
	Label8->Caption = lst.GetMin();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
	Node* ptr=lst.head;
	int i=0;


	qu1.DeleteQueue();
	ListBox2->Clear();
	qu2.DeleteQueue();
	ListBox3->Clear();

	while(ptr!=NULL)
	{
		if(lst.indexMax>lst.indexMin)
		{
			if(i>lst.indexMin && i<lst.indexMax)
			{
				qu1.Add(ptr->numbers);
				qu1.LoopBack();
				ListBox2->Items->Add(IntToStr(ptr->numbers));
			}
			else
			{
				qu2.Add(ptr->numbers);
				qu2.LoopBack();
				ListBox3->Items->Add(IntToStr(ptr->numbers));
			}
		}
		else
		{
			if(i<lst.indexMin && i>lst.indexMax)
			{
				qu1.Add(ptr->numbers);
				qu1.LoopBack();
				ListBox2->Items->Add(IntToStr(ptr->numbers));
			}
			else
			{
				qu2.Add(ptr->numbers);
				qu2.LoopBack();
				ListBox3->Items->Add(IntToStr(ptr->numbers));
			}
		}

		i++;
		ptr=ptr->next;
	}

	qu1.SetCurrent();
	PrintEdit();
	qu2.SetCurrent();
	PrintEdit2();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
	Edit1->Text = 10;
}
//---------------------------------------------------------------------------


void __fastcall TForm1::Button3Click(TObject *Sender)
{
	PrintEdit();
}
//---------------------------------------------------------------------------

void TForm1 :: PrintEdit()
{
	int result = qu1.PrintNode();

	Edit2->Text = IntToStr(result);

}

void TForm1 :: PrintEdit2()
{
	int num = qu2.PrintNode();

	Edit3->Text = IntToStr(num);
}

void __fastcall TForm1::Button4Click(TObject *Sender)
{
	PrintEdit2();
}
//---------------------------------------------------------------------------

