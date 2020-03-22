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
	va_list p;             //--объ€вление указател€
	double sum = 0, count = 0;
	va_start(p, n);            //--инициализаци€ указател€
	while (n--)
	{
		sum += va_arg(p, double);        //--перемещение указател€ 
		count++;
	}
	va_end(p);                //--Ђзакрытиеї указател€
	return ((sum) ? sum / count : 0);
}