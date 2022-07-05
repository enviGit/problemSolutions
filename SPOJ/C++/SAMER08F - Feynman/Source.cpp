#include <iostream>

using namespace std;

int main()
{
    int kwadrat, n;

    while(cin >> n && n != 0)
    {
        kwadrat = n * (n + 1) * (2 * n + 1) / 6;

        cout << kwadrat << endl;
    }
    return 0;
}
