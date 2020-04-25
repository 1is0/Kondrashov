//---------------------------------------------------------------------------


#pragma hdrstop

#include "TreeCreation.h"
#include <string>


Node* Tree :: TreeCreate(std::string name,int data)
{
	Node* item = new Node;
	if(!item)
	{
		return NULL;
	}
	item->left = NULL;
	item->right = NULL;
	item->cvc = data;
	item->bank = name;

	return item;
}

Node* Tree :: TreeAdd(Node* tree,std::string bank,int cvc)
{
	if (!tree)
	{
		return TreeCreate(bank,cvc);
	}

	Node* root = tree;
	while (1)
	{
		if (root->cvc == cvc)
		{
			return tree;
		}

		if (cvc < root->cvc)
		{
			if (root->left)
			{
				root = root->left;
			}
			else
			{
				root->left = TreeCreate(bank,cvc);
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
				root->right = TreeCreate(bank,cvc);
				return tree;
			}
		}
	}
}


int Tree :: NodeCount(Node* root)
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

void Tree :: PrintTree(Node* temp, TTreeView *TreeView, int &index)
{
	int i = index;

	if(temp->left)
	{
		TreeView->Items->AddChild(TreeView->Items->Item[i], (temp->left->bank).c_str());
		PrintTree(temp->left, TreeView, ++index);
	}
	if(temp->right)
	{
		TreeView->Items->AddChild(TreeView->Items->Item[i], (temp->right->bank).c_str());
		PrintTree(temp->right, TreeView, ++index);
	}
}

void Tree :: ShowTree(TTreeView *TreeView)
{
	int index = 0;
	TreeView->Items->Clear();
	if(root)
	{
		TreeView->Items->Add(NULL, (root->bank).c_str());
		PrintTree(root, TreeView, index);
	}
}


int TreeCalculation ::  CountOnLevel(Node* root, int N)
{
	if (root == 0)
	{
		return 0;
	}
	if (N == 0)
	{
		return root->bank.length();
	}

	int left = CountOnLevel(root->left, N - 1);
	int right = CountOnLevel(root->right, N - 1);

	return left + right;
}

void Tree :: DirectBypass(TMemo *Memo1, Node* ptr)
{
	if(ptr)
	{
		Memo1->Lines->Add((ptr->bank).c_str());
		DirectBypass(Memo1, ptr->left);
		DirectBypass(Memo1, ptr->right);
	}
}

void Tree :: BackwardBypass(TMemo *Memo1, Node* ptr)
{
	if(ptr)
	{
		BackwardBypass(Memo1, ptr->left);
		BackwardBypass(Memo1, ptr->right);
		Memo1->Lines->Add((ptr->bank).c_str());
	}
}

void Tree :: KeyBypass(TMemo *Memo1, Node* ptr)
{
	if(ptr)
	{
		KeyBypass(Memo1, ptr->left);
		Memo1->Lines->Add((ptr->bank).c_str());
		KeyBypass(Memo1, ptr->right);
	}
}

void Tree :: TreeClear(Node *root)
{
	if (!root)
	{
		return;
	}

	TreeClear(root->left);
	TreeClear(root->right);

	delete root;
}

void Tree :: DeleteNode(int numer)
{
	Node *del, *prevdel, *node, *prevnode;
	del = root;
	prevdel = NULL;
	while(del->cvc != numer)
	{
		prevdel = del;
		if(numer < del->cvc)
		{
			del = del->left;
		}
		else
		{
			del = del->right;
		}
	}
	if(!del)
	{
		return;
	}
	if(!del->right)
	{
		node = del->left;
	}
	else
	{
		if(!del->left)
		{
			node = del->right;
		}

		else
		{
			prevnode = del;
			node = del->left;
			while(node->right)
			{
				prevnode = node;
				node = node->right;
			}
			if(prevnode == del)
			{
				node->right = del->right;
			}
			else
			{
				node->right = del->right;
				prevnode->right = node->left;
				node->left = prevnode;
			}
		}
	}
	if(!prevdel)
	{
		 root = prevdel = node;
	}
	else
	{
		 if(del->cvc < prevdel->cvc)
		 {
			 prevdel->left = node;
		 }

		 else
		 {
			 prevdel->right = node;
		 }
	}
	delete del;
	nodescol--;
}

AnsiString Tree :: GetBank(int numer)
{
	Node *temp = root;
	while(temp->cvc != numer)
	{
		if(numer < temp->cvc)
		{
			temp = temp->left;
		}
		else
		{
			temp = temp->right;
		}
	}
	if(temp)
	{
		return (temp->bank).c_str();
	}
	else
	{
		return "";
	}
}

//---------------------------------------------------------------------------

#pragma package(smart_init)
