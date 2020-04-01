#include<string>
#include <stdarg.h>
using namespace std;

__declspec(dllexport)
 extern "C" __declspec(dllexport)int __stdcall Add(int a, int b)
{
	return a+b;
}

extern "C" __declspec(dllexport) int __stdcall Sub(int a, int b)
{
	return a - b;
}

extern "C" __declspec(dllexport)double __cdecl Average(int n, double a, ...)
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