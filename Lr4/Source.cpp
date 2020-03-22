#include<string>
#include <stdarg.h>
using namespace std;

__declspec(dllexport)
int add(int a, int b)
{
	return a+b;
}

__declspec(dllexport)
int sub(int a, int b)
{
	return a - b;
}

extern "C" __declspec(dllexport)
double Average(int n, double a, ...)
{
	va_list p;             //--���������� ���������
	double sum = 0, count = 0;
	va_start(p, n);            //--������������� ���������
	while (n--)
	{
		sum += va_arg(p, double);        //--����������� ��������� 
		count++;
	}
	va_end(p);                //--��������� ���������
	return ((sum) ? sum / count : 0);
}