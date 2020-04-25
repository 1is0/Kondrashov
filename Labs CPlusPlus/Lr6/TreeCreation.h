//---------------------------------------------------------------------------

#ifndef TreeCreationH
#define TreeCreationH
#include <string>
#include "TreeAction.h"
using namespace std;

class Node
{
public:
	std::string bank;
	int cvc;
	Node* left;
	Node* right;
};

class Tree
{
public:
	Node* root;
	int nodescol;

	Tree()
	{
		root = NULL;
		nodescol = 0;
	}

	Node* TreeCreate(std::string ,int);
	Node* TreeAdd(Node* ,std::string,int);
	int NodeCount(Node* );
	void PrintTree(Node* , TTreeView *, int &);
	void ShowTree(TTreeView *);
	void DirectBypass(TMemo*,Node*);
	void BackwardBypass(TMemo*,Node*);
	void KeyBypass(TMemo*, Node*);
	void TreeClear(Node *);
	void DeleteNode(int);
	AnsiString GetBank(int);
};

//По заданию создаем дочерний класс для реализации варианта
class TreeCalculation: public Tree
{
	public:
		int CountOnLevel(Node* , int );
};

//---------------------------------------------------------------------------
#endif
