// =========================================================================================
// ======================================================================Number :1
// =========================================================================================
// =========================================================================================
// #include <iostream>
// using namespace std;

// int main() {
//     cout<<"Hello, World!";
//     return 0;
// }
// =========================================================================================
// ======================================================================Number :2
// =========================================================================================
// =========================================================================================
// #include <iostream>
// #include <string>

// using namespace std;

// int main() 
// {
//     string name;
//     int age;
    
//     std::cout << "enter name and age" << std::endl;
//     cin>> name >> age;
//     cout<< "my name is "<<name << " and my age : " << age;
//       return 0; 
// }
// =========================================================================================
// ======================================================================Number :3
// =========================================================================================
// =========================================================================================
// #include <iostream>

// using namespace std;

// int main() 
// {
//     int x,y,z;
    

//     cin>> x >> y >> z;
//     cout<< x+y+z;
//       return 0; 
// }
// =========================================================================================
// ======================================================================Number :4
// =========================================================================================
// =========================================================================================
// #include <iostream>

// using namespace std;

// int main(void) 
// {
//     // Declare variables for each input type
//     int i;
//     long l;
//     char c;
//     float f;
//     double d;

//     // Read input values
//     cin >> i >> l >> c >> f >> d;

//     // Print each element on a new line
//     cout << i << endl;
//     cout << l << endl;
//     cout << c << endl;
//     cout << f << endl;  
//     cout << d << endl;  
//     cout << "========================" << endl;  


// }

// =========================================================================================
// ======================================================================Number :5
// =========================================================================================
// =========================================================================================
// #include <iostream>
// using namespace std;

// int main() {
//     int n;
//     cin >> n;  // Read the input integer
    
//     // Check the value of n and print the corresponding output
//     if (n >= 1 && n <= 9) {
//         // Print the number in words
//         switch (n) {
//             case 1: cout << "one"; break;
//             case 2: cout << "two"; break;
//             case 3: cout << "three"; break;
//             case 4: cout << "four"; break;
//             case 5: cout << "five"; break;
//             case 6: cout << "six"; break;
//             case 7: cout << "seven"; break;
//             case 8: cout << "eight"; break;
//             case 9: cout << "nine"; break;
//         }
//     } else {
//         // Print "Greater than 9" for numbers 10 and above
//         cout << "Greater than 9";
//     }

//     return 0;
// }
// =========================================================================================
// ======================================================================Number :6
// =========================================================================================
// =========================================================================================
// #include <iostream>
// using namespace std;
// int main(){
// int a,d;
//     cout<<"enter number start"<<endl;
//     cin>>a;
//     cout<<"enter number end"<<endl;
//     cin >> d; 

// for (int i = a; i < d; i++)
// {
//     if (i >= 1 && i <= 9)
//     {
//         switch (i)
//         {
//         case 1 : cout<< "one"<<endl ;break;
//         case 2 : cout<< "two"<<endl; break;
//         case 3 : cout<< "three"<<endl; break;
//         case 4 : cout<< "four"<<endl ;break;
//         case 5 : cout<< "five"<<endl ;break;
//         case 6 : cout<< "six"<<endl; break;
//         case 7 : cout<< "seven"<<endl; break;
//         case 8 : cout<< "eight" <<endl;break;
//         case 9 : cout<< "nine"<<endl; break;
//         }
//         }

//         else
//         {
//             if (i%2==0)
//             {
//                 cout<<"number is even";
//             }
//             else if (i%2!=0)
//             {
//                 cout<<"number is odd";
//             }
//         } 
//     } }

// =========================================================================================
// ======================================================================Number :7
// =========================================================================================
// =========================================================================================
// #include <iostream>
// #include <algorithm> 
// using namespace std;

// int main() { 
//     int a, b, c, d;
    
//     cin >> a >> b >> c >> d;
    
//     int x = max(a, b);
//     int y = max(c, d);

//     cout << max(x, y) << endl;

//     return 0;
// }
// =========================================================================================
// ======================================================================Number :8
// =========================================================================================
// =========================================================================================
// #include <iostream>
// using namespace std;


// int summ(int a ,int d){
//     return a+d;
// }
// int subb(int a ,int d){
//     return a-d;
// }

// int main() { 

// int a,d;
// cin>>a>>d;

// cout<< summ(a,d) << endl;
// cout<< subb(a,d) <<  endl;
// }

//=======================================
//=======================================
// #include <iostream>
// #include <cmath> 
// using namespace std;

// void update(int *a, int *b) {
//     int sum = *a + *b;
//     int diff = abs(*a - *b);
//     *a = sum;
//     *b = diff;
// }

// int main() {
//     int a, b;
//     cout << "Enter two integers: ";
//     cin >> a >> b;

//     update(&a, &b);

//     cout << "Sum: " << a << endl;
//     cout << "Absolute Difference: " << b << endl;

//     return 0;
// }
// =========================================================================================
// ======================================================================Number :9
// =========================================================================================
// =========================================================================================
#include <iostream>
#include <vector>

using namespace std;

int main() {
    int n;
    cin >> n;

    vector<int> arr(n);
    for (int i = 0; i < n; i++) {
        cin >> arr[i];
    }

    // Reverse the array using a loop
    for (int i = 0, j = n - 1; i < j; i++, j--) {
        swap(arr[i], arr[j]);
    }

    // Print the reversed array
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    return 0;
}
// =========================================================================================
// ======================================================================Number :10
// =========================================================================================
// =========================================================================================
#include <iostream>
#include <vector>

using namespace std;

int main() {
    int n, q;
    cin >> n >> q;

    vector<vector<int>> a(n);
    for (int i = 0; i < n; i++) {
        int k;
        cin >> k;
        a[i].resize(k);
        for (int j = 0; j < k; j++) {
            cin >> a[i][j];
        }
    }

    for (int i = 0; i < q; i++) {
        int x, y;
        cin >> x >> y;
        cout << a[x][y] << endl;
    }

    return 0;
}