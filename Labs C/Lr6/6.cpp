#include <malloc.h>
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>


struct Tree
{
	struct Tree* left;
	struct Tree* right;
	int data;
};

struct Tree* root = NULL;

struct Tree* TreeCreate(int );
void TreeInorder(struct Tree* root);
struct Tree* TreeAdd(struct Tree* tree, int data);
int NodeCount(struct Tree*);
int CountOnLevel(Tree* root, int N);

int main(void)
{
	system("chcp 1251");
	system("cls");
		
	FILE* fp;	
	int err = fopen_s(&fp, "bynarytree.txt", "r");//открываем файл
	if (err == 0 && fp)
	{
		int s = 0;
		printf("Целые числа из файла: \n");
		while ((fscanf_s(fp, "%d", &s) != EOF))
		{
			printf("%d ", s);
			root = TreeAdd(root, s);
		}
		printf("\n\nУпорядоченные целые числа из бинарного дерева поиска: \n");
		TreeInorder(root);

		int b = NodeCount(root);
		printf("\n\nКоличество узлов в бинарном дереве: %d\n\n", b);

		int count = 1;
		int level = 0;
		while (count != 0)
		{
			count = CountOnLevel(root, level);
			if (count > 0)
			{
				printf("На уровне %d дерева находится %d узлов.\n", level + 1, count);
			}
			level++;
		}
		
		fclose(fp);
	}
	
	int r = getchar();  //задержка консоли
	return 0;
}


int CountOnLevel(Tree* root, int N)
{
	if (root == 0)
	{
		return 0;
	}
	if (N == 0)
	{
		return 1;
	}

	int left = CountOnLevel(root->left, N - 1);
	int right = CountOnLevel(root->right, N - 1);

	return left + right;
}

struct Tree* TreeCreate(int data)
{
	struct Tree* item = (struct Tree*)
		malloc(sizeof(struct Tree));
	if (!item)
	{
		printf("Не хватает памяти\n");
		exit(0);
	}

	item->left = NULL;
	item->right = NULL;
	item->data = data;

	return item;
}


struct Tree* TreeAdd(struct Tree* tree, int data)
{
	if (!tree)
	{
		return TreeCreate(data);
	}

	struct Tree* root = tree;
	while (1)
	{
		if (root->data == data)
		{
			return tree;
		}

		if (data < root->data)
		{
			if (root->left)
			{
				root = root->left;
			}
			else
			{
				root->left = TreeCreate(data);
				return tree;
			}
		}
		else
		{
			if (root->right)
			{
				root = root->right;
			}
			else
			{
				root->right = TreeCreate(data);
				return tree;
			}
		}
	}
}


void TreeInorder(struct Tree* root)
{
	if (!root)
	{
		return;
	}

	TreeInorder(root->left);

	printf("%d ", root->data);

	TreeInorder(root->right);
}


int NodeCount(Tree* root)
{
	if (root->left == NULL && root->right == NULL)
	{
		return 1;
	}
	int left=0, right=0;
	if (root->left != NULL)
	{
		left = NodeCount(root->left);
	}
	else
	{
		left = 0;
	}
	if (root->right != NULL)
	{
		right = NodeCount(root->right);
	}
	else
	{
		right = 0;
	}

	return left + right + 1;
}