#include <stdio.h>
#include <stdlib.h>

typedef struct oe_ {
    int x;
    struct oe_* next;
}oe;

oe* CreateSingleLinkedList(int data) {
    oe* head = (oe*)malloc(sizeof(oe));
    if (head == NULL) {
        fprintf(stderr, "Memory allocation failed\n");
        return NULL;
    }
    
    head->next = NULL;
    head->x = data;
    return head;
}

oe* AddNode(oe* head, int data) {
    oe* node = (oe*)malloc(sizeof(oe));
    if (node == NULL) {
        // Handle allocation failure, e.g., return head unchanged or exit
        fprintf(stderr, "Memory allocation failed\n");
        return head;
    }
    node->x = data;
    node->next = head;
    return node;
}

void PrintList(oe* head) {
    oe* temp = head;
    while (temp != NULL) {
        printf("%d ", temp->x);
        temp = temp->next;
    }
}

int isListSortedAscending(oe* head)
{
    oe* temp = head;

    while (temp->next != NULL) {
        if (temp->x > temp->next->x) return 0;
        temp = temp->next;
    }
    return 1;
}

int listDemo()
{
    oe* head = CreateSingleLinkedList(10);
    head = AddNode(head, 5);
    head = AddNode(head, 6);
    PrintList(head);
    isListSortedAscending(head) ? printf("Yes\n") : printf("No\n");

    return 0;
}