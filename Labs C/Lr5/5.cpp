#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <conio.h>

struct List
{
	struct List* prev;
	struct List* next;
	int field;
};

struct List* Init(int);
struct List* AddUzel(List* , int);

int main()
{
	system("chcp 1251");
	system("cls");
	int f = 0;
	printf("Введите десятичное число f: ");
	scanf_s("%d",&f);



	List* spisok = Init('b');
	int count = 0;//счетчик кол-ва узлов
	int residue=0;
	int quotient=f;
	while(quotient>1)
	{	
		residue = quotient % 8;
		quotient = quotient / 8;
		spisok=AddUzel(spisok,residue);
		count++;
	}

	printf("Введенное число в восьмеричной системе: ");
	for (int i = 0; i < count; i++)
	{
		printf("%d",spisok->field);
		spisok=spisok->prev;
	}
	printf("\n\n");

	int r=_getch();

	return 0;
}

struct List* Init(int a)  // а- значение первого узла
{
	struct List* lst;
	// выделение памяти под корень списка
	lst = (struct List*)malloc(sizeof(struct List));
	lst->field = a;
	lst->next = NULL; // указатель на следующий узел
	lst->prev = NULL; // указатель на предыдущий узел
	return(lst);
}

struct List* AddUzel(List* lst, int number)
{
	struct List* temp = (struct List*)malloc(sizeof(List));
	struct List* p = lst->next; // сохранение указателя на следующий узел
	lst->next = temp; // предыдущий узел указывает на создаваемый
	temp->field = number; // сохранение поля данных добавляемого узла
	temp->next = p; // созданный узел указывает на следующий узел
	temp->prev = lst; // созданный узел указывает на предыдущий узел
	if (p != NULL)
	{
		p->prev = temp;
	}
	return(temp);
}