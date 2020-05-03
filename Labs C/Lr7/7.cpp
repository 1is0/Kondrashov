#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <conio.h>
#include <string.h>

struct List
{
	struct List* prev;
	struct List* next;
	int id;
	char data[100];
	char topic[100];
	char proglang[100];
	char source[100];
	char article[100];
	char comments[100];
};

struct List* head = NULL;
struct List* tail = NULL;
int size = 0;
int current = 0;

void Add(struct List);
void Delete();
void ShowList();
int FileSave();
void TopicSearch();
void ProgLangSearch();
void ReadAnother(char [100]);
void DopMenu(struct List*);
char* CorrectComments(struct List*);
char* AddComments();
int LoadFile();

// Вывести меню пользователю и вернуть номер варианта
int PromptMenuItem()
{
	// Выбранный вариант меню
	int variant;
	printf("Выберите вариант\n");
	printf("1. Просмотреть базу данных\n"
		"2. Поиск исходника по тематике\n"
		"3. Поиск исходника по языку программирования\n"
		"4. Выход из программы\n");
	printf(">>> ");
	scanf_s("%d", &variant);

	return variant;
}


int main(void)
{
	system("chcp 1251");
	system("cls");

	int variant;

	int a = LoadFile();

	do
	{
		system("cls");
		variant = PromptMenuItem();

		switch (variant)
		{
			case 1:
			{
				ShowList();
				int b = _getch();
				break;
			}
			case 2:
			{
				TopicSearch();
				int m = _getch();
				break;
			}
			case 3:
			{
				ProgLangSearch();
				int n = _getch();
				break;
			}
			case 4:
			{
				int q = FileSave();
				if (q == 0)
				{
					printf("Файл успешно сохранен!\n");
				}
				else
				{
					printf("Файл не сохранен!\n");
				}
				break;
			}
		
		}

	} while (variant != 4);

	int r = getchar();
	return 0;
}

void Add(struct List lst)
{
	struct List* temp = (struct List*)malloc(sizeof(List));
	temp->id = lst.id;
	strcpy_s(temp->data, lst.data);
	strcpy_s(temp->topic, lst.topic);
	strcpy_s(temp->proglang, lst.proglang);
	strcpy_s(temp->source, lst.source);
	strcpy_s(temp->article, lst.article);
	strcpy_s(temp->comments, lst.comments);
	temp->next = NULL;
	temp->prev = tail;
	if (tail)
	{
		tail->next = temp;
	}
	tail = temp;
	if (!head)
	{
		head = temp;
	}
	size++;
	current++;
}

void Delete()
{
	if (head)
	{
		head->prev = NULL;
	}
	if (tail)
	{
		tail->next = NULL;
	}
	while (head)
	{
		List* temp = head->next;
		free(temp);
		head = temp;
	}
	tail = NULL;
	size = 0;
}


void  ShowList()
{
	struct List* temp = NULL;
	temp = head;

	while (temp!=NULL)
	{
		printf("%d\t%s\t%s\t%s\t%s\t%s\t%s", temp->id, temp->data, temp->topic, temp->proglang, temp->source, temp->article, temp->comments);
		temp = temp->next;
	}
}

int FileSave()
{
	FILE* fp;
	struct List* temp = head;
	int err = fopen_s(&fp, "database.txt", "w");
	if (err == 0 && fp)
	{
		while (temp != NULL)
		{
			fprintf(fp, "%d\t%s\t%s\t%s\t%s\t%s\t%s", temp->id, temp->data, temp->topic, temp->proglang, temp->source, temp->article, temp->comments);
			temp = temp->next;
		}

		fclose(fp);
		return 0;
	}
	else
	{
		return -1;
	}
}

void TopicSearch()
{
	struct List* temp = NULL;
	struct List* found = NULL;
	temp = head;
	char str[256];
	bool flag = false;
	int current;
	
	printf("Введите тему для поиска: ");
	scanf_s("%s",str,100);
	
	while (temp != NULL)
	{
		if (strcmp(temp->topic, str) == 0)
		{
			printf("%d\t%s\t%s\t%s\t%s\t%s\t%s\n", temp->id, temp->data, temp->topic, temp->proglang, temp->source, temp->article, temp->comments);
			flag = true;
			found = temp;
		}
		temp = temp->next;
	}
	if (flag == false)
	{
		printf("Совпадение не найдено!");
	}

	DopMenu(found);

}

void ProgLangSearch()
{
	struct List* temp = NULL;
	struct List* found = NULL;
	temp = head;
	char str[256];
	bool flag = false;

	printf("Введите язык программирования для поиска: ");
	scanf_s("%s", str, 100);

	while (temp != NULL)
	{
		if (strcmp(temp->proglang, str) == 0)
		{
			printf("%d\t%s\t%s\t%s\t%s\t%s\t%s\n", temp->id, temp->data, temp->topic, temp->proglang, temp->source, temp->article, temp->comments);
			flag = true;
			found = temp;
		}
		temp = temp->next;
	}
	if (flag == false)
	{
		printf("Совпадение не найдено!");
	}

	DopMenu(found);
}

void ReadAnother(char name[100])
{
	FILE* fp;
	char str[256];
	int err = fopen_s(&fp, name, "r");

	if (err == 0 && fp)
	{
		while ((fgets(str, 255, fp) != NULL))
		{
			printf("%s",str);
		}
		printf("\n");
	}
}

void DopMenu(struct List* found)
{
	int rgb;

	do
	{
		printf("1. Просмотреть исходник\n"
			"2. Просмотреть статью\n"
			"3. Редактировать комментарии\n"
			"4. Добавить комментарии\n"
			"5. Выход в главную программу\n");
		printf(">>> ");
		scanf_s("%d", &rgb);
		switch (rgb)
		{
			case 1:
			{
				if (found)
				{
					ReadAnother(found->source);
				}
				break;
			}
			case 2:
			{
				if (found)
				{
					ReadAnother(found->article);
				}
				break;
			}
			case 3:
			{
				if (found)
				{
					char* str = CorrectComments(found);
					char str2[256];
					int i = 0;
					while (str[i] != '\0')
					{
						str2[i] = str[i];
						i++;
					}
					str2[i] = '\n';
					str2[i + 1] = '\0';
					strcpy_s(found->comments, str2);
				}
				break;
			}
			case 4:
			{
				char* str = AddComments();
				char str2[256];
				int i = 0;
				while (str[i] != '\0')
				{
					str2[i] = str[i];
					i++;
				}
				str2[i] = '\n';
				str2[i + 1] = '\0';
				
				struct List lst;
				lst.id = current + 2;
				strcpy_s(lst.data, found->data);
				strcpy_s(lst.topic, found->topic);
				strcpy_s(lst.proglang, found->proglang);
				strcpy_s(lst.source, found->source);
				strcpy_s(lst.article, found->article);
				strcpy_s(lst.comments, str2);
				Add(lst);

				break;
			}
			case 5:
			{
				break;
			}
		}

	} while (rgb != 5);
}

char* CorrectComments(struct List* found)
{
	char temp[256];
	printf("Отредактируйте комментарий (" "%s" "):", found->comments);
	scanf_s("%s",temp,99);

	return temp;
}

char* AddComments()
{
	char temp[256];
	printf("Введите комментарий: ");
	scanf_s("%s", temp, 99);

	return temp;
}

int LoadFile()
{
	struct List lst;
	lst.id = 0;
	strcpy_s(lst.data, "");
	strcpy_s(lst.topic, "");
	strcpy_s(lst.proglang, "");
	strcpy_s(lst.source, "");
	strcpy_s(lst.article, "");
	strcpy_s(lst.comments, "");

	FILE* fp;
	char str[256];
	char* istr;
	char* token = NULL;
	char sep[10] = "	";
	int count = 0;
	int err = fopen_s(&fp, "database.txt", "r");

	if (err == 0 && fp)
	{
		while ((fgets(str, 255, fp) != NULL))
		{
			//printf("%s ", str);

			istr = strtok_s(str, sep, &token);
			//заполняем поле id, т.к после 1-ого вызова strtok это поле уже выделено из всего текста
			lst.id = atoi(str);
			count = 0;
			while (istr != NULL)
			{
				// Выделение очередной части строки
				istr = strtok_s(NULL, sep, &token);
				if (istr)
				{
					count++;
					switch (count)
					{
					case 1:
					{
						strcpy_s(lst.data, (const char*)istr);
						break;
					}
					case 2:
					{
						strcpy_s(lst.topic, (const	 char*)istr);
						break;
					}
					case 3:
					{
						strcpy_s(lst.proglang, (const char*)istr);
						break;
					}
					case 4:
					{
						strcpy_s(lst.source, (const char*)istr);
						break;
					}
					case 5:
					{
						strcpy_s(lst.article, (const char*)istr);
						break;
					}
					case 6:
					{
						strcpy_s(lst.comments, (const char*)istr);
						break;
					}
					}
				}
			}

			Add(lst);
		}

		fclose(fp);
		return 0;
	}

	else
	{
		return -1;
	}
}