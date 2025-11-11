#include <iostream>
#include "lists.c"
//
//int povrh = 0;
//
//int Povrh(int a, int b) {
//	if (a == b || b == 0) {
//		povrh++;
//		return 1;
//	}
//	std::cout << povrh << std::endl;
//	return Povrh(a - 1, b - 1) + Povrh(a - 1, b);
//}
//
//void rek(int n) {
//	if (n < 10) return;
//	printf("%d ", n);
//	rek(n / 2);
//	printf("/");
//	rek(n / 2);
//	printf("[%d] ", n % 10);
//}
//
//int zbrojZnam(int n) {
//	n = std::abs(n);
//	if(n == 0) return 0;
//	return (n / 10) + zbrojZnam(n % 10);
//}
    int matrice[3][3] = {	{1, 2, 6},
							{3, 4, 7},
							{5, 8, 9} };

	int arr[9] = {};

	// 1 3 5  / 2 4 8  / 6 7 9

	// 1 2 3 5 8 / 6 7 9


	// Print sorted array, but the array's columns are
	// sorted in ascending order.
	// matrice 3x3 is an example, but it should work
	// with any NxN matrice.
	void sortedArr(int matrice[3][3]) {
		int helperArr1[3];
		int helperArr2[3];
		int helperArr3[3];

		for (int i = 0; i < 3; i++) {
			helperArr1[i] = matrice[i][0];
			helperArr2[i] = matrice[i][1];
			helperArr3[i] = matrice[i][3];
		}
	}

int main() {
	//std::cout << "Hello Worlds" << std::endl;

	//std::cout << Povrh(6, 3) << std::endl;
	//rek(128);
	//std::cout << zbrojZnam(234) << std::endl;
	
	/*listDemo();
	listDemo();
	listDemo();

	oe* head = CreateSingleLinkedList(202);
	head = AddNode(head, 130);
	head = AddNode(head, 54);
	head = AddNode(head, 932);
	PrintList(head);
	*/


	return 0;
}