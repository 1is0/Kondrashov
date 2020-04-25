//---------------------------------------------------------------------------


#pragma hdrstop

#include "QueueCreation.h"

void List :: Add(int a)
{
	Node *temp =  new Node();
	temp->numbers = a;
	temp->next = NULL;
	temp->prev = tail;
	if(tail)
	{
		tail->next = temp;
	}
	tail = temp;
	if(!head)
	{
		head = temp;
	}
	size++;
	current++;
}

int List :: GetMax()
{
	Node* ptr=head;
	int Max=-1000000;
	int i=0;
	while(ptr!=NULL)
	{
		if(ptr->numbers>Max)
		{
			Max=ptr->numbers;
			indexMax=i;
		}
		i++;
		ptr=ptr->next;
	}
	return Max;
}
int List :: GetMin()
{
	Node* ptr=head;
	int Min=1000000;
	int i=0;
	while(ptr!=NULL)
	{
		if(ptr->numbers<Min)
		{
			Min=ptr->numbers;
			indexMin=i;
		}
		i++;
		ptr=ptr->next;
	}
	return Min;
}
void List :: DeleteQueue()
{
	if(head)
	{
		head->prev=NULL;
	}
	if(tail)
	{
		tail->next=NULL;
	}
	while(head)
	{
		Node *temp = head->next;
		delete temp;
		head = temp;
	}
	tail=NULL;
	size=0;
}

void Queue :: LoopBack()
{
	if(head && tail)
	{
		head->prev = tail;
		tail->next = head;
	}
}

void Queue :: SetCurrent()
{
	if(head)
	{
		currentNode = head;
	}
	else
	{
		currentNode = NULL;
	}
}

int Queue :: PrintNode()
{
	int result = 0;

	if(currentNode)
	{
		result = currentNode->numbers;
		currentNode = currentNode->next;
	}

	return result;
}
//---------------------------------------------------------------------------

#pragma package(smart_init)
